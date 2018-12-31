namespace YoutubeAudioDownloaderBeta.Main.Search
{
    partial class InformationForm
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
            this.groupBoxDescription = new System.Windows.Forms.GroupBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelStatistics2 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelViews = new System.Windows.Forms.Label();
            this.labelVerified = new System.Windows.Forms.Label();
            this.flowLayoutPanelStatistics1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelLikes = new System.Windows.Forms.Label();
            this.labelDislikes = new System.Windows.Forms.Label();
            this.linkLabelVideo = new System.Windows.Forms.LinkLabel();
            this.groupBoxDescription.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.flowLayoutPanelStatistics2.SuspendLayout();
            this.flowLayoutPanelStatistics1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDescription
            // 
            this.groupBoxDescription.Controls.Add(this.richTextBoxDescription);
            this.groupBoxDescription.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDescription.Name = "groupBoxDescription";
            this.groupBoxDescription.Size = new System.Drawing.Size(429, 216);
            this.groupBoxDescription.TabIndex = 0;
            this.groupBoxDescription.TabStop = false;
            this.groupBoxDescription.Text = "Descrizione";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.AutoWordSelection = true;
            this.richTextBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDescription.Location = new System.Drawing.Point(6, 23);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.Size = new System.Drawing.Size(417, 187);
            this.richTextBoxDescription.TabIndex = 5;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.WordWrap = false;
            this.richTextBoxDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxDescription_LinkClicked);
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.flowLayoutPanelStatistics2);
            this.groupBoxStatistics.Controls.Add(this.flowLayoutPanelStatistics1);
            this.groupBoxStatistics.Location = new System.Drawing.Point(12, 234);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(429, 100);
            this.groupBoxStatistics.TabIndex = 3;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistiche";
            // 
            // flowLayoutPanelStatistics2
            // 
            this.flowLayoutPanelStatistics2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelStatistics2.Controls.Add(this.labelViews);
            this.flowLayoutPanelStatistics2.Controls.Add(this.labelVerified);
            this.flowLayoutPanelStatistics2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelStatistics2.Location = new System.Drawing.Point(216, 23);
            this.flowLayoutPanelStatistics2.Name = "flowLayoutPanelStatistics2";
            this.flowLayoutPanelStatistics2.Size = new System.Drawing.Size(207, 71);
            this.flowLayoutPanelStatistics2.TabIndex = 5;
            // 
            // labelViews
            // 
            this.labelViews.AutoSize = true;
            this.labelViews.Location = new System.Drawing.Point(3, 10);
            this.labelViews.Margin = new System.Windows.Forms.Padding(3, 10, 3, 7);
            this.labelViews.Name = "labelViews";
            this.labelViews.Size = new System.Drawing.Size(55, 18);
            this.labelViews.TabIndex = 1;
            this.labelViews.Text = "Views: ";
            // 
            // labelVerified
            // 
            this.labelVerified.AutoSize = true;
            this.labelVerified.Location = new System.Drawing.Point(3, 40);
            this.labelVerified.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelVerified.Name = "labelVerified";
            this.labelVerified.Size = new System.Drawing.Size(77, 18);
            this.labelVerified.TabIndex = 0;
            this.labelVerified.Text = "Verificato: ";
            // 
            // flowLayoutPanelStatistics1
            // 
            this.flowLayoutPanelStatistics1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanelStatistics1.Controls.Add(this.labelLikes);
            this.flowLayoutPanelStatistics1.Controls.Add(this.labelDislikes);
            this.flowLayoutPanelStatistics1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelStatistics1.Location = new System.Drawing.Point(6, 23);
            this.flowLayoutPanelStatistics1.Name = "flowLayoutPanelStatistics1";
            this.flowLayoutPanelStatistics1.Size = new System.Drawing.Size(207, 71);
            this.flowLayoutPanelStatistics1.TabIndex = 4;
            // 
            // labelLikes
            // 
            this.labelLikes.AutoSize = true;
            this.labelLikes.Location = new System.Drawing.Point(3, 10);
            this.labelLikes.Margin = new System.Windows.Forms.Padding(3, 10, 3, 7);
            this.labelLikes.Name = "labelLikes";
            this.labelLikes.Size = new System.Drawing.Size(51, 18);
            this.labelLikes.TabIndex = 1;
            this.labelLikes.Text = "Likes: ";
            // 
            // labelDislikes
            // 
            this.labelDislikes.AutoSize = true;
            this.labelDislikes.Location = new System.Drawing.Point(3, 40);
            this.labelDislikes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelDislikes.Name = "labelDislikes";
            this.labelDislikes.Size = new System.Drawing.Size(68, 18);
            this.labelDislikes.TabIndex = 0;
            this.labelDislikes.Text = "Dislikes: ";
            // 
            // linkLabelVideo
            // 
            this.linkLabelVideo.AutoSize = true;
            this.linkLabelVideo.Location = new System.Drawing.Point(56, 341);
            this.linkLabelVideo.Name = "linkLabelVideo";
            this.linkLabelVideo.Size = new System.Drawing.Size(76, 18);
            this.linkLabelVideo.TabIndex = 5;
            this.linkLabelVideo.TabStop = true;
            this.linkLabelVideo.Text = "Video Link";
            this.linkLabelVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelVideo_LinkClicked);
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(453, 367);
            this.Controls.Add(this.linkLabelVideo);
            this.Controls.Add(this.groupBoxStatistics);
            this.Controls.Add(this.groupBoxDescription);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informazioni";
            this.Load += new System.EventHandler(this.InformationForm_Load);
            this.groupBoxDescription.ResumeLayout(false);
            this.groupBoxStatistics.ResumeLayout(false);
            this.flowLayoutPanelStatistics2.ResumeLayout(false);
            this.flowLayoutPanelStatistics2.PerformLayout();
            this.flowLayoutPanelStatistics1.ResumeLayout(false);
            this.flowLayoutPanelStatistics1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDescription;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStatistics2;
        private System.Windows.Forms.Label labelViews;
        private System.Windows.Forms.Label labelVerified;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStatistics1;
        private System.Windows.Forms.Label labelLikes;
        private System.Windows.Forms.Label labelDislikes;
        private System.Windows.Forms.LinkLabel linkLabelVideo;
    }
}