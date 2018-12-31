namespace YoutubeAudioDownloaderBeta.Main
{
    partial class MainForm
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.labelInformation = new System.Windows.Forms.Label();
            this.numericUpDownSearch = new System.Windows.Forms.NumericUpDown();
            this.labelSearch = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelAutoDownload = new System.Windows.Forms.Label();
            this.toggleButtonAutoDownload = new YoutubeAudioDownloaderBeta.Main.ToggleButton();
            this.flowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMenuSearch = new YoutubeAudioDownloaderBeta.Main.HideTextButton();
            this.buttonMenuDownload = new YoutubeAudioDownloaderBeta.Main.HideTextButton();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.flowLayoutPanelDownload = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.buttonPath = new System.Windows.Forms.Button();
            this.folderBrowserDialogPath = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.textBoxPath = new YoutubeAudioDownloaderBeta.Main.OptimizedTextBox();
            this.textBoxSearch = new YoutubeAudioDownloaderBeta.Main.OptimizedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearch)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.flowLayoutPanelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SeaShell;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Location = new System.Drawing.Point(712, 10);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(59, 40);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Cerca";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_ClickAsync);
            // 
            // flowLayoutPanelSearch
            // 
            this.flowLayoutPanelSearch.AutoScroll = true;
            this.flowLayoutPanelSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelSearch.Location = new System.Drawing.Point(178, 85);
            this.flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            this.flowLayoutPanelSearch.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flowLayoutPanelSearch.Size = new System.Drawing.Size(593, 343);
            this.flowLayoutPanelSearch.TabIndex = 2;
            this.flowLayoutPanelSearch.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelContent_ControlRemoved);
            // 
            // labelInformation
            // 
            this.labelInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformation.Location = new System.Drawing.Point(178, 56);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(101, 18);
            this.labelInformation.TabIndex = 5;
            this.labelInformation.Text = "Informazioni";
            // 
            // numericUpDownSearch
            // 
            this.numericUpDownSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownSearch.Location = new System.Drawing.Point(712, 56);
            this.numericUpDownSearch.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSearch.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSearch.Name = "numericUpDownSearch";
            this.numericUpDownSearch.ReadOnly = true;
            this.numericUpDownSearch.Size = new System.Drawing.Size(59, 21);
            this.numericUpDownSearch.TabIndex = 6;
            this.numericUpDownSearch.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(593, 56);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(113, 18);
            this.labelSearch.TabIndex = 7;
            this.labelSearch.Text = "Risultati ricerca:";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.labelAutoDownload);
            this.panelMenu.Controls.Add(this.toggleButtonAutoDownload);
            this.panelMenu.Controls.Add(this.flowLayoutPanelMenu);
            this.panelMenu.Controls.Add(this.buttonMenu);
            this.panelMenu.Location = new System.Drawing.Point(9, 10);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(163, 450);
            this.panelMenu.TabIndex = 8;
            // 
            // labelAutoDownload
            // 
            this.labelAutoDownload.AutoSize = true;
            this.labelAutoDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutoDownload.Location = new System.Drawing.Point(5, 400);
            this.labelAutoDownload.Name = "labelAutoDownload";
            this.labelAutoDownload.Size = new System.Drawing.Size(152, 18);
            this.labelAutoDownload.TabIndex = 3;
            this.labelAutoDownload.Text = "Download Silenzioso:";
            // 
            // toggleButtonAutoDownload
            // 
            this.toggleButtonAutoDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toggleButtonAutoDownload.Location = new System.Drawing.Point(3, 424);
            this.toggleButtonAutoDownload.Name = "toggleButtonAutoDownload";
            this.toggleButtonAutoDownload.OffColor = System.Drawing.Color.Red;
            this.toggleButtonAutoDownload.OnColor = System.Drawing.Color.DodgerBlue;
            this.toggleButtonAutoDownload.Size = new System.Drawing.Size(41, 20);
            this.toggleButtonAutoDownload.TabIndex = 2;
            this.toggleButtonAutoDownload.ToggleColor = System.Drawing.Color.White;
            this.toggleButtonAutoDownload.ToggleState = true;
            // 
            // flowLayoutPanelMenu
            // 
            this.flowLayoutPanelMenu.AutoSize = true;
            this.flowLayoutPanelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMenu.Controls.Add(this.buttonMenuSearch);
            this.flowLayoutPanelMenu.Controls.Add(this.buttonMenuDownload);
            this.flowLayoutPanelMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMenu.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            this.flowLayoutPanelMenu.Size = new System.Drawing.Size(160, 94);
            this.flowLayoutPanelMenu.TabIndex = 1;
            // 
            // buttonMenuSearch
            // 
            this.buttonMenuSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMenuSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenuSearch.Image")));
            this.buttonMenuSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMenuSearch.Location = new System.Drawing.Point(3, 3);
            this.buttonMenuSearch.Name = "buttonMenuSearch";
            this.buttonMenuSearch.Size = new System.Drawing.Size(154, 41);
            this.buttonMenuSearch.TabIndex = 0;
            this.buttonMenuSearch.Text = "     Ricerca";
            this.buttonMenuSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMenuSearch.TextVisible = true;
            this.buttonMenuSearch.UseVisualStyleBackColor = false;
            this.buttonMenuSearch.Click += new System.EventHandler(this.buttonMenuSearch_Click);
            // 
            // buttonMenuDownload
            // 
            this.buttonMenuDownload.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMenuDownload.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenuDownload.Image")));
            this.buttonMenuDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMenuDownload.Location = new System.Drawing.Point(3, 50);
            this.buttonMenuDownload.Name = "buttonMenuDownload";
            this.buttonMenuDownload.Size = new System.Drawing.Size(154, 41);
            this.buttonMenuDownload.TabIndex = 1;
            this.buttonMenuDownload.Text = "     Download";
            this.buttonMenuDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMenuDownload.TextVisible = true;
            this.buttonMenuDownload.UseVisualStyleBackColor = false;
            this.buttonMenuDownload.Click += new System.EventHandler(this.buttonMenuDownload_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenu.Image = ((System.Drawing.Image)(resources.GetObject("buttonMenu.Image")));
            this.buttonMenu.Location = new System.Drawing.Point(3, 3);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(41, 41);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // flowLayoutPanelDownload
            // 
            this.flowLayoutPanelDownload.AutoScroll = true;
            this.flowLayoutPanelDownload.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanelDownload.Location = new System.Drawing.Point(178, 85);
            this.flowLayoutPanelDownload.Name = "flowLayoutPanelDownload";
            this.flowLayoutPanelDownload.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.flowLayoutPanelDownload.Size = new System.Drawing.Size(593, 343);
            this.flowLayoutPanelDownload.TabIndex = 3;
            this.flowLayoutPanelDownload.Visible = false;
            this.flowLayoutPanelDownload.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelContent_ControlRemoved);
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowAll.Location = new System.Drawing.Point(178, 434);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(106, 27);
            this.buttonShowAll.TabIndex = 9;
            this.buttonShowAll.Text = "Mostra tutti";
            this.buttonShowAll.UseVisualStyleBackColor = true;
            this.buttonShowAll.Click += new System.EventHandler(this.buttonShowAll_Click);
            // 
            // buttonPath
            // 
            this.buttonPath.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPath.Location = new System.Drawing.Point(741, 434);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(30, 26);
            this.buttonPath.TabIndex = 12;
            this.buttonPath.Text = "...";
            this.buttonPath.UseVisualStyleBackColor = false;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetAll.Location = new System.Drawing.Point(178, 434);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(106, 27);
            this.buttonResetAll.TabIndex = 14;
            this.buttonResetAll.Text = "Ripristina";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Visible = false;
            this.buttonResetAll.Click += new System.EventHandler(this.buttonResetAll_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(290, 434);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.PlaceholerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(452, 26);
            this.textBoxPath.TabIndex = 13;
            this.textBoxPath.Text = "C:\\Users\\Andre\\Music";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(178, 10);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.textBoxSearch.PlaceholderText = "Cerca un video o incolla un link...";
            this.textBoxSearch.PlaceholerFont = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Size = new System.Drawing.Size(535, 40);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(783, 469);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonPath);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.numericUpDownSearch);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.flowLayoutPanelSearch);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.flowLayoutPanelDownload);
            this.Controls.Add(this.buttonShowAll);
            this.Controls.Add(this.buttonResetAll);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::YoutubeAudioDownloaderBeta.Properties.Resources.Icon;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(799, 508);
            this.MinimumSize = new System.Drawing.Size(799, 508);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Audio Downloader Beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearch)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.flowLayoutPanelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OptimizedTextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSearch;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.NumericUpDown numericUpDownSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMenu;
        private HideTextButton buttonMenuSearch;
        private HideTextButton buttonMenuDownload;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDownload;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.Button buttonPath;
        private OptimizedTextBox textBoxPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPath;
        private System.Windows.Forms.Button buttonResetAll;
        private ToggleButton toggleButtonAutoDownload;
        private System.Windows.Forms.Label labelAutoDownload;
    }
}

