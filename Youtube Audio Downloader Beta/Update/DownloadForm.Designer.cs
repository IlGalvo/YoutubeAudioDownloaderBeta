namespace YoutubeAudioDownloaderBeta.Update
{
    partial class UpdateForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTotalByte = new System.Windows.Forms.Label();
            this.labelCurrentByte = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.richTextBoxVersionHistory = new System.Windows.Forms.RichTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.coloredProgressBarDownload = new YoutubeAudioDownloaderBeta.ColoredProgressBar();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(10, 5);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(399, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "AGGIORNAMENTO TROVATO!";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalByte
            // 
            this.labelTotalByte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalByte.AutoSize = true;
            this.labelTotalByte.Location = new System.Drawing.Point(340, 59);
            this.labelTotalByte.Name = "labelTotalByte";
            this.labelTotalByte.Size = new System.Drawing.Size(69, 18);
            this.labelTotalByte.TabIndex = 2;
            this.labelTotalByte.Text = "00,00 Mb";
            // 
            // labelCurrentByte
            // 
            this.labelCurrentByte.AutoSize = true;
            this.labelCurrentByte.Location = new System.Drawing.Point(7, 59);
            this.labelCurrentByte.Name = "labelCurrentByte";
            this.labelCurrentByte.Size = new System.Drawing.Size(69, 18);
            this.labelCurrentByte.TabIndex = 1;
            this.labelCurrentByte.Text = "00,00 Mb";
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(7, 125);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(266, 18);
            this.labelInfo.TabIndex = 4;
            this.labelInfo.Text = "Premere \'Aggiorna\' per procedere.";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(281, 125);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 32);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "Aggiorna";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // richTextBoxVersionHistory
            // 
            this.richTextBoxVersionHistory.AcceptsTab = true;
            this.richTextBoxVersionHistory.AutoWordSelection = true;
            this.richTextBoxVersionHistory.Location = new System.Drawing.Point(10, 163);
            this.richTextBoxVersionHistory.Name = "richTextBoxVersionHistory";
            this.richTextBoxVersionHistory.ReadOnly = true;
            this.richTextBoxVersionHistory.Size = new System.Drawing.Size(399, 218);
            this.richTextBoxVersionHistory.TabIndex = 7;
            this.richTextBoxVersionHistory.Text = "";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(362, 125);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 32);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Esci";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // coloredProgressBarDownload
            // 
            this.coloredProgressBarDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coloredProgressBarDownload.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.coloredProgressBarDownload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coloredProgressBarDownload.Location = new System.Drawing.Point(10, 81);
            this.coloredProgressBarDownload.Margin = new System.Windows.Forms.Padding(4);
            this.coloredProgressBarDownload.Name = "coloredProgressBarDownload";
            this.coloredProgressBarDownload.ProgressColor = System.Drawing.Color.Red;
            this.coloredProgressBarDownload.ShowPercentageText = true;
            this.coloredProgressBarDownload.Size = new System.Drawing.Size(399, 37);
            this.coloredProgressBarDownload.TabIndex = 3;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(418, 388);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.richTextBoxVersionHistory);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.coloredProgressBarDownload);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelTotalByte);
            this.Controls.Add(this.labelCurrentByte);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UpdateForm";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aggiornamento";
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTotalByte;
        private System.Windows.Forms.Label labelCurrentByte;
        private System.Windows.Forms.Label labelInfo;
        private ColoredProgressBar coloredProgressBarDownload;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.RichTextBox richTextBoxVersionHistory;
        private System.Windows.Forms.Button buttonCancel;
    }
}