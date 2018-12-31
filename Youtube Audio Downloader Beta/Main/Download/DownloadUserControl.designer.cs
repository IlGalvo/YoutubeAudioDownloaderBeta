using System.Threading;

namespace YoutubeAudioDownloaderBeta.Main.Download
{
    partial class DownloadUserControl
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (IsRunning)
            {
                audioInfo.CancelAsync();
                converterMp3.CancelAsync();

                lock (lockObject)
                {
                    Monitor.Wait(lockObject);
                }
            }

            converterMp3.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            actionToPerform?.Invoke();

            audioInfo.DownloadProgress -= AudioInfo_DownloadProgress;
            audioInfo.DownloadFinished -= AudioInfo_DownloadFinished;

            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonDownloadCancel = new System.Windows.Forms.Button();
            this.groupBoxDownloadMp3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelDownloadMp3 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelBitrateSize = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.coloredProgressBarPercentage = new YoutubeAudioDownloaderBeta.ColoredProgressBar();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.groupBoxDownloadMp3.SuspendLayout();
            this.flowLayoutPanelDownloadMp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBoxImage);
            this.panelImage.Location = new System.Drawing.Point(3, 2);
            this.panelImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(197, 128);
            this.panelImage.TabIndex = 3;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(197, 128);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonDownloadCancel
            // 
            this.buttonDownloadCancel.Location = new System.Drawing.Point(206, 102);
            this.buttonDownloadCancel.Name = "buttonDownloadCancel";
            this.buttonDownloadCancel.Size = new System.Drawing.Size(76, 28);
            this.buttonDownloadCancel.TabIndex = 14;
            this.buttonDownloadCancel.Text = "Scarica";
            this.buttonDownloadCancel.UseVisualStyleBackColor = true;
            this.buttonDownloadCancel.Click += new System.EventHandler(this.buttonDownloadCancel_Click);
            // 
            // groupBoxDownloadMp3
            // 
            this.groupBoxDownloadMp3.Controls.Add(this.flowLayoutPanelDownloadMp3);
            this.groupBoxDownloadMp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDownloadMp3.Location = new System.Drawing.Point(206, 2);
            this.groupBoxDownloadMp3.Name = "groupBoxDownloadMp3";
            this.groupBoxDownloadMp3.Size = new System.Drawing.Size(424, 98);
            this.groupBoxDownloadMp3.TabIndex = 16;
            this.groupBoxDownloadMp3.TabStop = false;
            this.groupBoxDownloadMp3.Text = "Download Mp3";
            // 
            // flowLayoutPanelDownloadMp3
            // 
            this.flowLayoutPanelDownloadMp3.Controls.Add(this.labelTitle);
            this.flowLayoutPanelDownloadMp3.Controls.Add(this.labelBitrateSize);
            this.flowLayoutPanelDownloadMp3.Controls.Add(this.labelInformation);
            this.flowLayoutPanelDownloadMp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelDownloadMp3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelDownloadMp3.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanelDownloadMp3.Name = "flowLayoutPanelDownloadMp3";
            this.flowLayoutPanelDownloadMp3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanelDownloadMp3.Size = new System.Drawing.Size(418, 77);
            this.flowLayoutPanelDownloadMp3.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(4, 4);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.labelTitle.Size = new System.Drawing.Size(410, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Titolo";
            // 
            // labelBitrateSize
            // 
            this.labelBitrateSize.AutoSize = true;
            this.labelBitrateSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBitrateSize.Location = new System.Drawing.Point(4, 29);
            this.labelBitrateSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBitrateSize.Name = "labelBitrateSize";
            this.labelBitrateSize.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelBitrateSize.Size = new System.Drawing.Size(76, 20);
            this.labelBitrateSize.TabIndex = 1;
            this.labelBitrateSize.Text = "Bitrate/Size";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformation.Location = new System.Drawing.Point(4, 49);
            this.labelInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.labelInformation.Size = new System.Drawing.Size(91, 23);
            this.labelInformation.TabIndex = 2;
            this.labelInformation.Text = "Informazioni";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(636, 0);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(25, 25);
            this.buttonRemove.TabIndex = 17;
            this.buttonRemove.Text = "X";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // coloredProgressBarPercentage
            // 
            this.coloredProgressBarPercentage.BackColor = System.Drawing.Color.Firebrick;
            this.coloredProgressBarPercentage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coloredProgressBarPercentage.Location = new System.Drawing.Point(288, 102);
            this.coloredProgressBarPercentage.Name = "coloredProgressBarPercentage";
            this.coloredProgressBarPercentage.ProgressColor = System.Drawing.Color.Red;
            this.coloredProgressBarPercentage.ShowPercentageText = true;
            this.coloredProgressBarPercentage.Size = new System.Drawing.Size(342, 28);
            this.coloredProgressBarPercentage.TabIndex = 12;
            // 
            // DownloadUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.groupBoxDownloadMp3);
            this.Controls.Add(this.buttonDownloadCancel);
            this.Controls.Add(this.coloredProgressBarPercentage);
            this.Controls.Add(this.panelImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 15, 4);
            this.Name = "DownloadUserControl";
            this.Size = new System.Drawing.Size(661, 133);
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.groupBoxDownloadMp3.ResumeLayout(false);
            this.flowLayoutPanelDownloadMp3.ResumeLayout(false);
            this.flowLayoutPanelDownloadMp3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private ColoredProgressBar coloredProgressBarPercentage;
        private System.Windows.Forms.Button buttonDownloadCancel;
        private System.Windows.Forms.GroupBox groupBoxDownloadMp3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDownloadMp3;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelBitrateSize;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Button buttonRemove;
    }
}
