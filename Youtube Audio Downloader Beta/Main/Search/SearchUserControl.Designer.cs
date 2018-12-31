namespace YoutubeAudioDownloaderBeta.Main.Search
{
    partial class SearchUserControl
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelUploadDate = new System.Windows.Forms.Label();
            this.labelAverageRating = new System.Windows.Forms.Label();
            this.groupBoxVideo = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelVideo = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelShowOther = new System.Windows.Forms.LinkLabel();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelAudio = new System.Windows.Forms.FlowLayoutPanel();
            this.labelContainerEncoding = new System.Windows.Forms.Label();
            this.labelBitrate = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.webBrowserVideo = new System.Windows.Forms.WebBrowser();
            this.groupBoxVideo.SuspendLayout();
            this.flowLayoutPanelVideo.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            this.flowLayoutPanelAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(4, 4);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelAuthor.Size = new System.Drawing.Size(47, 20);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Autore";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(4, 24);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelTitle.Size = new System.Drawing.Size(42, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Titolo";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuration.Location = new System.Drawing.Point(4, 44);
            this.labelDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelDuration.Size = new System.Drawing.Size(48, 20);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "Durata";
            // 
            // labelUploadDate
            // 
            this.labelUploadDate.AutoSize = true;
            this.labelUploadDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUploadDate.Location = new System.Drawing.Point(3, 64);
            this.labelUploadDate.Name = "labelUploadDate";
            this.labelUploadDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelUploadDate.Size = new System.Drawing.Size(114, 20);
            this.labelUploadDate.TabIndex = 4;
            this.labelUploadDate.Text = "Data caricamento";
            // 
            // labelAverageRating
            // 
            this.labelAverageRating.AutoSize = true;
            this.labelAverageRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageRating.Location = new System.Drawing.Point(3, 84);
            this.labelAverageRating.Name = "labelAverageRating";
            this.labelAverageRating.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelAverageRating.Size = new System.Drawing.Size(119, 20);
            this.labelAverageRating.TabIndex = 5;
            this.labelAverageRating.Text = "Valutazione media";
            // 
            // groupBoxVideo
            // 
            this.groupBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVideo.AutoSize = true;
            this.groupBoxVideo.Controls.Add(this.flowLayoutPanelVideo);
            this.groupBoxVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVideo.Location = new System.Drawing.Point(375, 3);
            this.groupBoxVideo.Name = "groupBoxVideo";
            this.groupBoxVideo.Size = new System.Drawing.Size(147, 156);
            this.groupBoxVideo.TabIndex = 13;
            this.groupBoxVideo.TabStop = false;
            this.groupBoxVideo.Text = "Video";
            // 
            // flowLayoutPanelVideo
            // 
            this.flowLayoutPanelVideo.AutoSize = true;
            this.flowLayoutPanelVideo.Controls.Add(this.labelAuthor);
            this.flowLayoutPanelVideo.Controls.Add(this.labelTitle);
            this.flowLayoutPanelVideo.Controls.Add(this.labelDuration);
            this.flowLayoutPanelVideo.Controls.Add(this.labelUploadDate);
            this.flowLayoutPanelVideo.Controls.Add(this.labelAverageRating);
            this.flowLayoutPanelVideo.Controls.Add(this.linkLabelShowOther);
            this.flowLayoutPanelVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelVideo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelVideo.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanelVideo.Name = "flowLayoutPanelVideo";
            this.flowLayoutPanelVideo.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanelVideo.Size = new System.Drawing.Size(141, 135);
            this.flowLayoutPanelVideo.TabIndex = 0;
            // 
            // linkLabelShowOther
            // 
            this.linkLabelShowOther.AutoSize = true;
            this.linkLabelShowOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowOther.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelShowOther.Location = new System.Drawing.Point(3, 107);
            this.linkLabelShowOther.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.linkLabelShowOther.Name = "linkLabelShowOther";
            this.linkLabelShowOther.Size = new System.Drawing.Size(102, 16);
            this.linkLabelShowOther.TabIndex = 6;
            this.linkLabelShowOther.TabStop = true;
            this.linkLabelShowOther.Text = "Mostra altro...";
            this.linkLabelShowOther.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowOther_LinkClicked);
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAudio.AutoSize = true;
            this.groupBoxAudio.Controls.Add(this.flowLayoutPanelAudio);
            this.groupBoxAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAudio.Location = new System.Drawing.Point(375, 165);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Size = new System.Drawing.Size(147, 97);
            this.groupBoxAudio.TabIndex = 14;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "Audio";
            // 
            // flowLayoutPanelAudio
            // 
            this.flowLayoutPanelAudio.AutoSize = true;
            this.flowLayoutPanelAudio.Controls.Add(this.labelContainerEncoding);
            this.flowLayoutPanelAudio.Controls.Add(this.labelBitrate);
            this.flowLayoutPanelAudio.Controls.Add(this.labelSize);
            this.flowLayoutPanelAudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAudio.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAudio.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanelAudio.Name = "flowLayoutPanelAudio";
            this.flowLayoutPanelAudio.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanelAudio.Size = new System.Drawing.Size(141, 76);
            this.flowLayoutPanelAudio.TabIndex = 0;
            // 
            // labelContainerEncoding
            // 
            this.labelContainerEncoding.AutoSize = true;
            this.labelContainerEncoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContainerEncoding.Location = new System.Drawing.Point(4, 4);
            this.labelContainerEncoding.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContainerEncoding.Name = "labelContainerEncoding";
            this.labelContainerEncoding.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelContainerEncoding.Size = new System.Drawing.Size(126, 20);
            this.labelContainerEncoding.TabIndex = 1;
            this.labelContainerEncoding.Text = "Container/Encoding";
            // 
            // labelBitrate
            // 
            this.labelBitrate.AutoSize = true;
            this.labelBitrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBitrate.Location = new System.Drawing.Point(4, 24);
            this.labelBitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBitrate.Name = "labelBitrate";
            this.labelBitrate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.labelBitrate.Size = new System.Drawing.Size(46, 20);
            this.labelBitrate.TabIndex = 2;
            this.labelBitrate.Text = "Bitrate";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSize.Location = new System.Drawing.Point(4, 44);
            this.labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(80, 16);
            this.labelSize.TabIndex = 3;
            this.labelSize.Text = "Dimensione";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDownload.Location = new System.Drawing.Point(375, 268);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(87, 35);
            this.buttonDownload.TabIndex = 15;
            this.buttonDownload.Text = "Scarica";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // webBrowserVideo
            // 
            this.webBrowserVideo.Location = new System.Drawing.Point(3, 3);
            this.webBrowserVideo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserVideo.Name = "webBrowserVideo";
            this.webBrowserVideo.Size = new System.Drawing.Size(366, 300);
            this.webBrowserVideo.TabIndex = 16;
            this.webBrowserVideo.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowserVideo_NewWindow);
            // 
            // SearchUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.webBrowserVideo);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.groupBoxAudio);
            this.Controls.Add(this.groupBoxVideo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchUserControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.Size = new System.Drawing.Size(540, 306);
            this.Load += new System.EventHandler(this.SearchUserControl_LoadAsync);
            this.groupBoxVideo.ResumeLayout(false);
            this.groupBoxVideo.PerformLayout();
            this.flowLayoutPanelVideo.ResumeLayout(false);
            this.flowLayoutPanelVideo.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            this.flowLayoutPanelAudio.ResumeLayout(false);
            this.flowLayoutPanelAudio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelUploadDate;
        private System.Windows.Forms.Label labelAverageRating;
        private System.Windows.Forms.GroupBox groupBoxVideo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVideo;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAudio;
        private System.Windows.Forms.Label labelContainerEncoding;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.LinkLabel linkLabelShowOther;
        private System.Windows.Forms.WebBrowser webBrowserVideo;
    }
}
