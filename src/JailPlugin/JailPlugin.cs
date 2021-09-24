// Licensed to the Jail Plugin Contributors under one or more agreements.
// The Jail Plugin Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        readonly Regex _logRegex = new Regex(
            "^.{14} (00|1[56]):([0-9A-F]{8}|[0-9A-F]{4}):(Garuda|Titan):(2B6B|2B6C):[^:]*:[0-9A-F]{8}:(?<target>([^:]*)):?.*$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// The stopwatch
        /// </summary>
        readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>
        /// The list of matched playes
        /// </summary>
        readonly List<string> _matchedPlayers = new List<string>();

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
                _logTextBox.AppendText($"{ Environment.NewLine + Environment.NewLine }=======[RESET]=======");
                _stopwatch.Reset();
                _matchedPlayers.Clear();
            }

            _logTextBox.AppendText(Environment.NewLine + logInfo.logLine);
            _stopwatch.Start();

            if (_players.Contains(match.Groups["target"].Value))
            {
                _matchedPlayers.Add(match.Groups["target"].Value);
            }
            else
            {
                _logTextBox.AppendText($"{ Environment.NewLine }---[Player { match.Groups["target"].Value } is not in the priority list!]---");
                return;
            }

            if (_matchedPlayers.Count != 3)
            {
                return;
            }

            var tts = _players
                .Where(p => _matchedPlayers.Contains(p))
                .Select(p =>
                {
                    var number = _players.IndexOf(p) + 1;

                    if (_ttsUsesNamesCheckBox.Checked)
                    {
                        _logTextBox.AppendText($"{ Environment.NewLine }---[{ number }]---[{ p }]--->---{ p.Split(' ')[0] }---");
                        return p.Split(' ')[0];
                    }
                    else
                    {
                        _logTextBox.AppendText($"{ Environment.NewLine }---[{ number }]---[{ p }]--->---{ number }---");
                        return number.ToString();
                    }
                });

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
