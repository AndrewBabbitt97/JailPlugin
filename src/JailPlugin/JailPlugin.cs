// Licensed to the Chroma Control Contributors under one or more agreements.
// The Chroma Control Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Advanced_Combat_Tracker;

namespace JailPlugin
{
    /// <summary>
    /// The jail plugin
    /// </summary>
    public partial class JailPlugin : UserControl, IActPluginV1
    {
        /// <summary>
        /// The plugin status text
        /// </summary>
        Label _pluginStatusText;

        /// <summary>
        /// The settings file location
        /// </summary>
        readonly string _settingsFileLocation = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config", "JailPlugin.config.xml");

        /// <summary>
        /// The settings serializer
        /// </summary>
        SettingsSerializer _settingsSerializer;

        /// <summary>
        /// The list of players
        /// </summary>
        readonly List<string> _players = new List<string>();

        /// <summary>
        /// The log regex for jails
        /// </summary>
        readonly Regex _logRegex = new Regex(":(.*)?:2B6(B|C):.*?:.*?:", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// The number of successful matches
        /// </summary>
        int _matchCount = 0;

        /// <summary>
        /// The list of matched playes
        /// </summary>
        readonly List<string> _matchedPlayers = new List<string>();

        /// <summary>
        /// The stopwatch
        /// </summary>
        readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// The text to speach words for each player
        /// </summary>
        readonly List<string> _ttsNumbers = new List<string>()
        {
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight"
        };

        /// <summary>
        /// Creates an instance of the jail plugin
        /// </summary>
        public JailPlugin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when player text has changes
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The event arguments</param>
        private void PlayerTextChanged(object sender, EventArgs e)
        {
            _players.Clear();

            _players.Add(_player1TextBox.Text);
            _players.Add(_player2TextBox.Text);
            _players.Add(_player3TextBox.Text);
            _players.Add(_player4TextBox.Text);
            _players.Add(_player5TextBox.Text);
            _players.Add(_player6TextBox.Text);
            _players.Add(_player7TextBox.Text);
            _players.Add(_player8TextBox.Text);
        }

        /// <summary>
        /// Initializes the plugin
        /// </summary>
        /// <param name="pluginScreenSpace">The plugin screen space</param>
        /// <param name="pluginStatusText">The plugin status text</param>
        void IActPluginV1.InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _pluginStatusText = pluginStatusText;

            pluginScreenSpace.Controls.Add(this);
            Dock = DockStyle.Fill;

            _settingsSerializer = new SettingsSerializer(this);
            LoadSettings();

            ActGlobals.oFormActMain.OnLogLineRead += OnLogLineRead;

            _pluginStatusText.Text = "Plugin Started";
        }

        /// <summary>
        /// Deinitializes the plugin
        /// </summary>
        void IActPluginV1.DeInitPlugin()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= OnLogLineRead;

            SaveSettings();

            _pluginStatusText.Text = "Plugin Exited";
        }

        /// <summary>
        /// Occurs when a log line is read
        /// </summary>
        /// <param name="isImport">If the log is imported</param>
        /// <param name="logInfo">The log line event arguments</param>
        private void OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            var match = _logRegex.Match(logInfo.logLine);

            if (!match.Success)
            {
                return;
            }

            if (_stopwatch.ElapsedMilliseconds > 1000)
            {
                _logTextBox.Text += $"{ Environment.NewLine + Environment.NewLine }=======[RESET]=======";
                _stopwatch.Reset();
                _matchCount = 0;
                _matchedPlayers.Clear();
            }

            _logTextBox.Text += Environment.NewLine + logInfo.logLine;
            _stopwatch.Start();

            for (var i = 0; i < _players.Count; i++)
            {
                if (logInfo.logLine.Contains(_players[i]))
                {
                    _matchedPlayers.Add(_players[i]);
                }
            }

            _matchCount++;

            if (_matchCount != 3)
            {
                return;
            }

            if (_matchCount != _matchedPlayers.Count)
            {
                _logTextBox.Text += $"{ Environment.NewLine }---[Incorrect name(s) in the priority list!]---";
                return;
            }

            var tts = new List<string>();

            for (var i = 0; i < _players.Count; i++)
            {
                if (_matchedPlayers.Contains(_players[i]))
                {
                    if (_ttsUsesNamesCheckBox.Checked)
                    {
                        tts.Add(_players[i].Split(' ')[0]);
                        _logTextBox.Text += $"{ Environment.NewLine }---[{ i + 1 }]---[{ _players[i] }]--->---{ _players[i].Split(' ')[0] }---";
                    }
                    else
                    {
                        tts.Add(_ttsNumbers[i]);
                        _logTextBox.Text += $"{ Environment.NewLine }---[{ i + 1 }]---[{ _players[i] }]--->---{ _ttsNumbers[i] }---";
                    }
                }
            }

            ActGlobals.oFormActMain.TTS(string.Join(" ", tts));
        }

        /// <summary>
        /// Saves the settings
        /// </summary>
        void SaveSettings()
        {
            var fileStream = new FileStream(_settingsFileLocation, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            var xmlTextWriter = new XmlTextWriter(fileStream, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 4,
                IndentChar = ' '
            };

            xmlTextWriter.WriteStartDocument(true);
            xmlTextWriter.WriteStartElement("Config");
            xmlTextWriter.WriteStartElement("SettingsSerializer");
            _settingsSerializer.ExportToXml(xmlTextWriter);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();

            xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }

        /// <summary>
        /// Loads the settings
        /// </summary>
        void LoadSettings()
        {
            _settingsSerializer.AddControlSetting(_player1TextBox.Name, _player1TextBox);
            _settingsSerializer.AddControlSetting(_player2TextBox.Name, _player2TextBox);
            _settingsSerializer.AddControlSetting(_player3TextBox.Name, _player3TextBox);
            _settingsSerializer.AddControlSetting(_player4TextBox.Name, _player4TextBox);
            _settingsSerializer.AddControlSetting(_player5TextBox.Name, _player5TextBox);
            _settingsSerializer.AddControlSetting(_player6TextBox.Name, _player6TextBox);
            _settingsSerializer.AddControlSetting(_player7TextBox.Name, _player7TextBox);
            _settingsSerializer.AddControlSetting(_player8TextBox.Name, _player8TextBox);
            _settingsSerializer.AddControlSetting(_ttsUsesNamesCheckBox.Name, _ttsUsesNamesCheckBox);

            if (File.Exists(_settingsFileLocation))
            {
                var fileStream = new FileStream(_settingsFileLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var xmlTextReader = new XmlTextReader(fileStream);

                try
                {
                    while (xmlTextReader.Read())
                    {
                        if (xmlTextReader.NodeType == XmlNodeType.Element)
                        {
                            if (xmlTextReader.LocalName == "SettingsSerializer")
                            {
                                _settingsSerializer.ImportFromXml(xmlTextReader);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _pluginStatusText.Text = $"Error loading settings: { ex.Message }";
                }

                xmlTextReader.Close();
            }
        }
    }
}
