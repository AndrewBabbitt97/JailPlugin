// Licensed to the Chroma Control Contributors under one or more agreements.
// The Chroma Control Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace JailPlugin
{
    /// <summary>
    /// The jail plugin
    /// </summary>
    partial class JailPlugin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._playerPanel = new System.Windows.Forms.Panel();
            this._player1Label = new System.Windows.Forms.Label();
            this._player2Label = new System.Windows.Forms.Label();
            this._player3Label = new System.Windows.Forms.Label();
            this._player4Label = new System.Windows.Forms.Label();
            this._player5Label = new System.Windows.Forms.Label();
            this._player6Label = new System.Windows.Forms.Label();
            this._player7Label = new System.Windows.Forms.Label();
            this._player8Label = new System.Windows.Forms.Label();
            this._player1TextBox = new System.Windows.Forms.TextBox();
            this._player2TextBox = new System.Windows.Forms.TextBox();
            this._player3TextBox = new System.Windows.Forms.TextBox();
            this._player4TextBox = new System.Windows.Forms.TextBox();
            this._player5TextBox = new System.Windows.Forms.TextBox();
            this._player6TextBox = new System.Windows.Forms.TextBox();
            this._player7TextBox = new System.Windows.Forms.TextBox();
            this._player8TextBox = new System.Windows.Forms.TextBox();
            this._logTextBox = new System.Windows.Forms.TextBox();
            this._ttsUsesNamesCheckBox = new System.Windows.Forms.CheckBox();
            this._playerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _playerPanel
            // 
            this._playerPanel.Controls.Add(this._player1Label);
            this._playerPanel.Controls.Add(this._player2Label);
            this._playerPanel.Controls.Add(this._player3Label);
            this._playerPanel.Controls.Add(this._player4Label);
            this._playerPanel.Controls.Add(this._player5Label);
            this._playerPanel.Controls.Add(this._player6Label);
            this._playerPanel.Controls.Add(this._player7Label);
            this._playerPanel.Controls.Add(this._player8Label);
            this._playerPanel.Controls.Add(this._player1TextBox);
            this._playerPanel.Controls.Add(this._player2TextBox);
            this._playerPanel.Controls.Add(this._player3TextBox);
            this._playerPanel.Controls.Add(this._player4TextBox);
            this._playerPanel.Controls.Add(this._player5TextBox);
            this._playerPanel.Controls.Add(this._player6TextBox);
            this._playerPanel.Controls.Add(this._player7TextBox);
            this._playerPanel.Controls.Add(this._player8TextBox);
            this._playerPanel.Location = new System.Drawing.Point(3, 27);
            this._playerPanel.Name = "_playerPanel";
            this._playerPanel.Size = new System.Drawing.Size(202, 211);
            this._playerPanel.TabIndex = 0;
            // 
            // _player1Label
            // 
            this._player1Label.AutoSize = true;
            this._player1Label.Location = new System.Drawing.Point(3, 14);
            this._player1Label.Name = "_player1Label";
            this._player1Label.Size = new System.Drawing.Size(16, 13);
            this._player1Label.TabIndex = 0;
            this._player1Label.Text = "1.";
            // 
            // _player2Label
            // 
            this._player2Label.AutoSize = true;
            this._player2Label.Location = new System.Drawing.Point(3, 37);
            this._player2Label.Name = "_player2Label";
            this._player2Label.Size = new System.Drawing.Size(16, 13);
            this._player2Label.TabIndex = 1;
            this._player2Label.Text = "2.";
            // 
            // _player3Label
            // 
            this._player3Label.AutoSize = true;
            this._player3Label.Location = new System.Drawing.Point(3, 60);
            this._player3Label.Name = "_player3Label";
            this._player3Label.Size = new System.Drawing.Size(16, 13);
            this._player3Label.TabIndex = 2;
            this._player3Label.Text = "3.";
            // 
            // _player4Label
            // 
            this._player4Label.AutoSize = true;
            this._player4Label.Location = new System.Drawing.Point(3, 83);
            this._player4Label.Name = "_player4Label";
            this._player4Label.Size = new System.Drawing.Size(16, 13);
            this._player4Label.TabIndex = 3;
            this._player4Label.Text = "4.";
            // 
            // _player5Label
            // 
            this._player5Label.AutoSize = true;
            this._player5Label.Location = new System.Drawing.Point(3, 106);
            this._player5Label.Name = "_player5Label";
            this._player5Label.Size = new System.Drawing.Size(16, 13);
            this._player5Label.TabIndex = 4;
            this._player5Label.Text = "5.";
            // 
            // _player6Label
            // 
            this._player6Label.AutoSize = true;
            this._player6Label.Location = new System.Drawing.Point(3, 129);
            this._player6Label.Name = "_player6Label";
            this._player6Label.Size = new System.Drawing.Size(16, 13);
            this._player6Label.TabIndex = 5;
            this._player6Label.Text = "6.";
            // 
            // _player7Label
            // 
            this._player7Label.AutoSize = true;
            this._player7Label.Location = new System.Drawing.Point(3, 152);
            this._player7Label.Name = "_player7Label";
            this._player7Label.Size = new System.Drawing.Size(16, 13);
            this._player7Label.TabIndex = 6;
            this._player7Label.Text = "7.";
            // 
            // _player8Label
            // 
            this._player8Label.AutoSize = true;
            this._player8Label.Location = new System.Drawing.Point(3, 175);
            this._player8Label.Name = "_player8Label";
            this._player8Label.Size = new System.Drawing.Size(16, 13);
            this._player8Label.TabIndex = 7;
            this._player8Label.Text = "8.";
            // 
            // _player1TextBox
            // 
            this._player1TextBox.Location = new System.Drawing.Point(25, 11);
            this._player1TextBox.Name = "_player1TextBox";
            this._player1TextBox.Size = new System.Drawing.Size(164, 20);
            this._player1TextBox.TabIndex = 8;
            this._player1TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player2TextBox
            // 
            this._player2TextBox.Location = new System.Drawing.Point(25, 34);
            this._player2TextBox.Name = "_player2TextBox";
            this._player2TextBox.Size = new System.Drawing.Size(164, 20);
            this._player2TextBox.TabIndex = 9;
            this._player2TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player3TextBox
            // 
            this._player3TextBox.Location = new System.Drawing.Point(25, 57);
            this._player3TextBox.Name = "_player3TextBox";
            this._player3TextBox.Size = new System.Drawing.Size(164, 20);
            this._player3TextBox.TabIndex = 10;
            this._player3TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player4TextBox
            // 
            this._player4TextBox.Location = new System.Drawing.Point(25, 80);
            this._player4TextBox.Name = "_player4TextBox";
            this._player4TextBox.Size = new System.Drawing.Size(164, 20);
            this._player4TextBox.TabIndex = 11;
            this._player4TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player5TextBox
            // 
            this._player5TextBox.Location = new System.Drawing.Point(25, 103);
            this._player5TextBox.Name = "_player5TextBox";
            this._player5TextBox.Size = new System.Drawing.Size(164, 20);
            this._player5TextBox.TabIndex = 12;
            this._player5TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player6TextBox
            // 
            this._player6TextBox.Location = new System.Drawing.Point(25, 126);
            this._player6TextBox.Name = "_player6TextBox";
            this._player6TextBox.Size = new System.Drawing.Size(164, 20);
            this._player6TextBox.TabIndex = 13;
            this._player6TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player7TextBox
            // 
            this._player7TextBox.Location = new System.Drawing.Point(25, 149);
            this._player7TextBox.Name = "_player7TextBox";
            this._player7TextBox.Size = new System.Drawing.Size(164, 20);
            this._player7TextBox.TabIndex = 14;
            this._player7TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _player8TextBox
            // 
            this._player8TextBox.Location = new System.Drawing.Point(25, 172);
            this._player8TextBox.Name = "_player8TextBox";
            this._player8TextBox.Size = new System.Drawing.Size(164, 20);
            this._player8TextBox.TabIndex = 15;
            this._player8TextBox.TextChanged += new System.EventHandler(this.PlayerTextChanged);
            // 
            // _logTextBox
            // 
            this._logTextBox.Location = new System.Drawing.Point(211, 38);
            this._logTextBox.MaxLength = 1000000;
            this._logTextBox.Multiline = true;
            this._logTextBox.Name = "_logTextBox";
            this._logTextBox.ReadOnly = true;
            this._logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._logTextBox.Size = new System.Drawing.Size(505, 223);
            this._logTextBox.TabIndex = 1;
            this._logTextBox.Text = "Started..";
            this._logTextBox.WordWrap = false;
            // 
            // _ttsUsesNamesCheckBox
            // 
            this._ttsUsesNamesCheckBox.AutoSize = true;
            this._ttsUsesNamesCheckBox.Location = new System.Drawing.Point(3, 244);
            this._ttsUsesNamesCheckBox.Name = "_ttsUsesNamesCheckBox";
            this._ttsUsesNamesCheckBox.Size = new System.Drawing.Size(110, 17);
            this._ttsUsesNamesCheckBox.TabIndex = 2;
            this._ttsUsesNamesCheckBox.Text = "TTS Uses Names";
            this._ttsUsesNamesCheckBox.UseVisualStyleBackColor = true;
            // 
            // JailPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._ttsUsesNamesCheckBox);
            this.Controls.Add(this._playerPanel);
            this.Controls.Add(this._logTextBox);
            this.Name = "JailPlugin";
            this.Size = new System.Drawing.Size(969, 493);
            this._playerPanel.ResumeLayout(false);
            this._playerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel _playerPanel;
        private System.Windows.Forms.Label _player1Label;
        private System.Windows.Forms.Label _player2Label;
        private System.Windows.Forms.Label _player3Label;
        private System.Windows.Forms.Label _player4Label;
        private System.Windows.Forms.Label _player5Label;
        private System.Windows.Forms.Label _player6Label;
        private System.Windows.Forms.Label _player7Label;
        private System.Windows.Forms.Label _player8Label;
        private System.Windows.Forms.TextBox _player1TextBox;
        private System.Windows.Forms.TextBox _player2TextBox;
        private System.Windows.Forms.TextBox _player3TextBox;
        private System.Windows.Forms.TextBox _player4TextBox;
        private System.Windows.Forms.TextBox _player5TextBox;
        private System.Windows.Forms.TextBox _player6TextBox;
        private System.Windows.Forms.TextBox _player7TextBox;
        private System.Windows.Forms.TextBox _player8TextBox;
        private System.Windows.Forms.TextBox _logTextBox;
        private System.Windows.Forms.CheckBox _ttsUsesNamesCheckBox;
    }
}
