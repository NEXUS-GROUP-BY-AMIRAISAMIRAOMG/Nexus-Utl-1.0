namespace NEXUS
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cuiFormDrag1 = new CuoreUI.cuiFormDrag(this.components);
            this.windowTitle = new System.Windows.Forms.Label();
            this.Minimise = new System.Windows.Forms.Label();
            this.cuiFormRounder1 = new CuoreUI.Components.cuiFormRounder();
            this.exit = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.cuiPictureBox3 = new CuoreUI.Controls.cuiPictureBox();
            this.modulesPageIcon = new System.Windows.Forms.PictureBox();
            this.nexusIcon = new CuoreUI.Controls.cuiPictureBox();
            this.injectorPageicon = new System.Windows.Forms.PictureBox();
            this.aboutPageIcon = new System.Windows.Forms.PictureBox();
            this.cuiPictureBox2 = new CuoreUI.Controls.cuiPictureBox();
            this.newsPageIcon = new System.Windows.Forms.PictureBox();
            this.settingsPageIcon = new System.Windows.Forms.PictureBox();
            this.cuiPictureBox1 = new CuoreUI.Controls.cuiPictureBox();
            this.formBackground = new CuoreUI.Controls.cuiPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modulesPageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.injectorPageicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsPageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cuiFormDrag1
            // 
            this.cuiFormDrag1.TargetForm = this;
            // 
            // windowTitle
            // 
            this.windowTitle.BackColor = System.Drawing.Color.Transparent;
            this.windowTitle.Font = new System.Drawing.Font("Cascadia Mono", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowTitle.ForeColor = System.Drawing.Color.White;
            this.windowTitle.Location = new System.Drawing.Point(281, 6);
            this.windowTitle.Name = "windowTitle";
            this.windowTitle.Size = new System.Drawing.Size(607, 33);
            this.windowTitle.TabIndex = 1;
            this.windowTitle.Text = "NEXUS UTILITIES";
            this.windowTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.windowTitle.UseCompatibleTextRendering = true;
            this.windowTitle.Click += new System.EventHandler(this.windowTitle_Click);
            this.windowTitle.DragEnter += new System.Windows.Forms.DragEventHandler(this.windowTitle_DragEnter);
            this.windowTitle.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // Minimise
            // 
            this.Minimise.AutoSize = true;
            this.Minimise.BackColor = System.Drawing.Color.Transparent;
            this.Minimise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimise.Font = new System.Drawing.Font("Cascadia Code SemiLight", 18.25F);
            this.Minimise.ForeColor = System.Drawing.Color.White;
            this.Minimise.Location = new System.Drawing.Point(1116, 3);
            this.Minimise.Name = "Minimise";
            this.Minimise.Size = new System.Drawing.Size(30, 33);
            this.Minimise.TabIndex = 6;
            this.Minimise.Text = "-";
            this.Minimise.Click += new System.EventHandler(this.minimise);
            // 
            // cuiFormRounder1
            // 
            this.cuiFormRounder1.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cuiFormRounder1.Rounding = 10;
            this.cuiFormRounder1.TargetForm = this;
            // 
            // exit
            // 
            this.exit.AllowDrop = true;
            this.exit.AutoSize = true;
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Cascadia Code SemiLight", 18.25F);
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(1144, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(30, 33);
            this.exit.TabIndex = 19;
            this.exit.Text = "x";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainPanel.BackgroundImage")));
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainPanel.Controls.Add(this.cuiPictureBox3);
            this.mainPanel.Location = new System.Drawing.Point(66, 48);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1101, 665);
            this.mainPanel.TabIndex = 5;
            // 
            // cuiPictureBox3
            // 
            this.cuiPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cuiPictureBox3.Content = ((System.Drawing.Image)(resources.GetObject("cuiPictureBox3.Content")));
            this.cuiPictureBox3.CornerRadius = 10;
            this.cuiPictureBox3.ImageTint = System.Drawing.Color.White;
            this.cuiPictureBox3.Location = new System.Drawing.Point(0, 0);
            this.cuiPictureBox3.Name = "cuiPictureBox3";
            this.cuiPictureBox3.Size = new System.Drawing.Size(1101, 665);
            this.cuiPictureBox3.TabIndex = 21;
            // 
            // modulesPageIcon
            // 
            this.modulesPageIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.modulesPageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.modulesPageIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modulesPageIcon.Image = ((System.Drawing.Image)(resources.GetObject("modulesPageIcon.Image")));
            this.modulesPageIcon.Location = new System.Drawing.Point(18, 633);
            this.modulesPageIcon.Name = "modulesPageIcon";
            this.modulesPageIcon.Size = new System.Drawing.Size(32, 32);
            this.modulesPageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.modulesPageIcon.TabIndex = 16;
            this.modulesPageIcon.TabStop = false;
            this.modulesPageIcon.Click += new System.EventHandler(this.modulesPage);
            // 
            // nexusIcon
            // 
            this.nexusIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(64)))));
            this.nexusIcon.Content = ((System.Drawing.Image)(resources.GetObject("nexusIcon.Content")));
            this.nexusIcon.CornerRadius = 10;
            this.nexusIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nexusIcon.ImageTint = System.Drawing.Color.White;
            this.nexusIcon.Location = new System.Drawing.Point(7, 6);
            this.nexusIcon.Name = "nexusIcon";
            this.nexusIcon.Size = new System.Drawing.Size(28, 27);
            this.nexusIcon.TabIndex = 15;
            this.nexusIcon.Load += new System.EventHandler(this.nexusIcon_Load);
            this.nexusIcon.Click += new System.EventHandler(this.nexusClick);
            // 
            // injectorPageicon
            // 
            this.injectorPageicon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.injectorPageicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.injectorPageicon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.injectorPageicon.Image = ((System.Drawing.Image)(resources.GetObject("injectorPageicon.Image")));
            this.injectorPageicon.Location = new System.Drawing.Point(17, 99);
            this.injectorPageicon.Name = "injectorPageicon";
            this.injectorPageicon.Size = new System.Drawing.Size(32, 32);
            this.injectorPageicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.injectorPageicon.TabIndex = 13;
            this.injectorPageicon.TabStop = false;
            this.injectorPageicon.Click += new System.EventHandler(this.injectorPage);
            // 
            // aboutPageIcon
            // 
            this.aboutPageIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.aboutPageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.aboutPageIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutPageIcon.Image = ((System.Drawing.Image)(resources.GetObject("aboutPageIcon.Image")));
            this.aboutPageIcon.Location = new System.Drawing.Point(18, 672);
            this.aboutPageIcon.Name = "aboutPageIcon";
            this.aboutPageIcon.Size = new System.Drawing.Size(32, 32);
            this.aboutPageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.aboutPageIcon.TabIndex = 12;
            this.aboutPageIcon.TabStop = false;
            this.aboutPageIcon.Click += new System.EventHandler(this.aboutPage);
            // 
            // cuiPictureBox2
            // 
            this.cuiPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cuiPictureBox2.Content = ((System.Drawing.Image)(resources.GetObject("cuiPictureBox2.Content")));
            this.cuiPictureBox2.CornerRadius = 10;
            this.cuiPictureBox2.ImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.cuiPictureBox2.Location = new System.Drawing.Point(8, 584);
            this.cuiPictureBox2.Name = "cuiPictureBox2";
            this.cuiPictureBox2.Size = new System.Drawing.Size(52, 130);
            this.cuiPictureBox2.TabIndex = 11;
            // 
            // newsPageIcon
            // 
            this.newsPageIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.newsPageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newsPageIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsPageIcon.Image = ((System.Drawing.Image)(resources.GetObject("newsPageIcon.Image")));
            this.newsPageIcon.Location = new System.Drawing.Point(17, 595);
            this.newsPageIcon.Name = "newsPageIcon";
            this.newsPageIcon.Size = new System.Drawing.Size(32, 32);
            this.newsPageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.newsPageIcon.TabIndex = 10;
            this.newsPageIcon.TabStop = false;
            this.newsPageIcon.Click += new System.EventHandler(this.newsPage);
            // 
            // settingsPageIcon
            // 
            this.settingsPageIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.settingsPageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingsPageIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsPageIcon.Image = ((System.Drawing.Image)(resources.GetObject("settingsPageIcon.Image")));
            this.settingsPageIcon.Location = new System.Drawing.Point(17, 537);
            this.settingsPageIcon.Name = "settingsPageIcon";
            this.settingsPageIcon.Size = new System.Drawing.Size(32, 32);
            this.settingsPageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settingsPageIcon.TabIndex = 9;
            this.settingsPageIcon.TabStop = false;
            this.settingsPageIcon.Click += new System.EventHandler(this.settingsPage);
            // 
            // cuiPictureBox1
            // 
            this.cuiPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cuiPictureBox1.Content = ((System.Drawing.Image)(resources.GetObject("cuiPictureBox1.Content")));
            this.cuiPictureBox1.CornerRadius = 10;
            this.cuiPictureBox1.ImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.cuiPictureBox1.Location = new System.Drawing.Point(8, 48);
            this.cuiPictureBox1.Name = "cuiPictureBox1";
            this.cuiPictureBox1.Size = new System.Drawing.Size(50, 530);
            this.cuiPictureBox1.TabIndex = 4;
            // 
            // formBackground
            // 
            this.formBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(64)))));
            this.formBackground.Content = ((System.Drawing.Image)(resources.GetObject("formBackground.Content")));
            this.formBackground.CornerRadius = 10;
            this.formBackground.ImageTint = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.formBackground.Location = new System.Drawing.Point(0, 39);
            this.formBackground.Name = "formBackground";
            this.formBackground.Size = new System.Drawing.Size(1176, 771);
            this.formBackground.TabIndex = 0;
            this.formBackground.Load += new System.EventHandler(this.formBackground_Load);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1177, 723);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.modulesPageIcon);
            this.Controls.Add(this.nexusIcon);
            this.Controls.Add(this.injectorPageicon);
            this.Controls.Add(this.aboutPageIcon);
            this.Controls.Add(this.newsPageIcon);
            this.Controls.Add(this.settingsPageIcon);
            this.Controls.Add(this.Minimise);
            this.Controls.Add(this.cuiPictureBox1);
            this.Controls.Add(this.windowTitle);
            this.Controls.Add(this.cuiPictureBox2);
            this.Controls.Add(this.formBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1177, 723);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1078, 723);
            this.Name = "Form1";
            this.Text = "Nexus Main Window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modulesPageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.injectorPageicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsPageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CuoreUI.cuiFormDrag cuiFormDrag1;
        private CuoreUI.Controls.cuiPictureBox formBackground;
        private System.Windows.Forms.Label windowTitle;
        private CuoreUI.Controls.cuiPictureBox cuiPictureBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label Minimise;
        private System.Windows.Forms.PictureBox settingsPageIcon;
        private System.Windows.Forms.PictureBox newsPageIcon;
        private System.Windows.Forms.PictureBox aboutPageIcon;
        private CuoreUI.Controls.cuiPictureBox cuiPictureBox2;
        private System.Windows.Forms.PictureBox injectorPageicon;
        private CuoreUI.Controls.cuiPictureBox nexusIcon;
        private System.Windows.Forms.PictureBox modulesPageIcon;
        private CuoreUI.Components.cuiFormRounder cuiFormRounder1;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CuoreUI.Controls.cuiPictureBox cuiPictureBox3;
    }
}

