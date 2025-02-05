namespace NEXUS.Pages
{
    partial class NewsPage
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
            this.Downloads = new System.Windows.Forms.FlowLayoutPanel();
            this.cuiScrollbar1 = new CuoreUI.Controls.cuiScrollbar();
            this.SuspendLayout();
            // 
            // Downloads
            // 
            this.Downloads.AutoScroll = true;
            this.Downloads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.Downloads.ForeColor = System.Drawing.Color.White;
            this.Downloads.Location = new System.Drawing.Point(0, 0);
            this.Downloads.Name = "Downloads";
            this.Downloads.Size = new System.Drawing.Size(1101, 662);
            this.Downloads.TabIndex = 25;
            this.Downloads.Paint += new System.Windows.Forms.PaintEventHandler(this.Downloads_Paint);
            // 
            // cuiScrollbar1
            // 
            this.cuiScrollbar1.AutoScroll = true;
            this.cuiScrollbar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.cuiScrollbar1.Background = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.cuiScrollbar1.HoveredThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(50)))));
            this.cuiScrollbar1.Location = new System.Drawing.Point(1081, 0);
            this.cuiScrollbar1.MinimumSize = new System.Drawing.Size(20, 50);
            this.cuiScrollbar1.Name = "cuiScrollbar1";
            this.cuiScrollbar1.PressedThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.cuiScrollbar1.Rounding = 7;
            this.cuiScrollbar1.Size = new System.Drawing.Size(20, 662);
            this.cuiScrollbar1.TabIndex = 28;
            this.cuiScrollbar1.TargetControl = this.Downloads;
            this.cuiScrollbar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(50)))));
            this.cuiScrollbar1.ThumbHeight = 50;
            // 
            // NewsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.cuiScrollbar1);
            this.Controls.Add(this.Downloads);
            this.Name = "NewsPage";
            this.Size = new System.Drawing.Size(1101, 665);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel Downloads;
        private CuoreUI.Controls.cuiScrollbar cuiScrollbar1;
    }
}
