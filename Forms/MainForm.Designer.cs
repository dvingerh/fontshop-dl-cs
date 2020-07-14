namespace fontshop_dl_cs
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FontUrlLabel = new System.Windows.Forms.Label();
            this.FontUrlTextBox = new System.Windows.Forms.TextBox();
            this.SaveToLabel = new System.Windows.Forms.Label();
            this.SaveToTextBox = new System.Windows.Forms.TextBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FontUrlLabel
            // 
            this.FontUrlLabel.AutoSize = true;
            this.FontUrlLabel.Location = new System.Drawing.Point(12, 16);
            this.FontUrlLabel.Name = "FontUrlLabel";
            this.FontUrlLabel.Size = new System.Drawing.Size(54, 13);
            this.FontUrlLabel.TabIndex = 0;
            this.FontUrlLabel.Text = "Font URL";
            // 
            // FontUrlTextBox
            // 
            this.FontUrlTextBox.Location = new System.Drawing.Point(72, 12);
            this.FontUrlTextBox.Name = "FontUrlTextBox";
            this.FontUrlTextBox.Size = new System.Drawing.Size(400, 22);
            this.FontUrlTextBox.TabIndex = 1;
            this.FontUrlTextBox.TextChanged += new System.EventHandler(this.FontUrlTextBoxChanged);
            // 
            // SaveToLabel
            // 
            this.SaveToLabel.AutoSize = true;
            this.SaveToLabel.Location = new System.Drawing.Point(22, 44);
            this.SaveToLabel.Name = "SaveToLabel";
            this.SaveToLabel.Size = new System.Drawing.Size(44, 13);
            this.SaveToLabel.TabIndex = 2;
            this.SaveToLabel.Text = "Save to";
            // 
            // SaveToTextBox
            // 
            this.SaveToTextBox.Location = new System.Drawing.Point(72, 40);
            this.SaveToTextBox.Name = "SaveToTextBox";
            this.SaveToTextBox.Size = new System.Drawing.Size(337, 22);
            this.SaveToTextBox.TabIndex = 3;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(415, 40);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(57, 23);
            this.SelectButton.TabIndex = 4;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButtonClicked);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 126);
            this.ProgressBar.MarqueeAnimationSpeed = 1;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(368, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 5;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(386, 126);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(86, 23);
            this.DownloadButton.TabIndex = 6;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButtonClicked);
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusPanel.Controls.Add(this.StatusLabel);
            this.StatusPanel.Location = new System.Drawing.Point(130, 81);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(225, 25);
            this.StatusPanel.TabIndex = 7;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLabel.Location = new System.Drawing.Point(0, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(223, 23);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Waiting for font URL...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.SaveToTextBox);
            this.Controls.Add(this.SaveToLabel);
            this.Controls.Add(this.FontUrlTextBox);
            this.Controls.Add(this.FontUrlLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fontshop-dl-cs";
            this.StatusPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FontUrlLabel;
        private System.Windows.Forms.TextBox FontUrlTextBox;
        private System.Windows.Forms.Label SaveToLabel;
        private System.Windows.Forms.TextBox SaveToTextBox;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Label StatusLabel;
    }
}

