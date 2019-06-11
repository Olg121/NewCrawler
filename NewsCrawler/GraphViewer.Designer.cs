namespace NewsCrawler
{
    partial class GraphViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphViewer));
            this.nDrawingDocument1 = new Nevron.Diagram.NDrawingDocument();
            this.nDrawingView1 = new Nevron.Diagram.WinForm.NDrawingView();
            this.nPanAndZoomControl1 = new Nevron.Diagram.WinForm.NPanAndZoomControl();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nDrawingDocument1
            // 
            this.nDrawingDocument1.DesignTimeState = ((Nevron.Diagram.NBinaryState)(resources.GetObject("nDrawingDocument1.DesignTimeState")));
            // 
            // nDrawingView1
            // 
            this.nDrawingView1.AllowDrop = true;
            this.nDrawingView1.DesignTimeState = ((Nevron.Diagram.NBinaryState)(resources.GetObject("nDrawingView1.DesignTimeState")));
            this.nDrawingView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nDrawingView1.Document = this.nDrawingDocument1;
            this.nDrawingView1.Location = new System.Drawing.Point(0, 0);
            this.nDrawingView1.Name = "nDrawingView1";
            this.nDrawingView1.RenderTechnology = Nevron.GraphicsCore.RenderTechnology.GDIPlus;
            this.nDrawingView1.Size = new System.Drawing.Size(1357, 524);
            this.nDrawingView1.TabIndex = 0;
            this.nDrawingView1.Text = "nDrawingView1";
            // 
            // nPanAndZoomControl1
            // 
            this.nPanAndZoomControl1.LargeZoomChangeFactor = ((uint)(10u));
            this.nPanAndZoomControl1.Location = new System.Drawing.Point(1137, 311);
            this.nPanAndZoomControl1.MasterView = this.nDrawingView1;
            this.nPanAndZoomControl1.Name = "nPanAndZoomControl1";
            this.nPanAndZoomControl1.Size = new System.Drawing.Size(201, 182);
            this.nPanAndZoomControl1.TabIndex = 1;
            this.nPanAndZoomControl1.Text = "nPanAndZoomControl1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1139, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1137, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 20);
            this.textBox1.TabIndex = 3;
            // 
            // GraphViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 524);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nPanAndZoomControl1);
            this.Controls.Add(this.nDrawingView1);
            this.Name = "GraphViewer";
            this.Text = "GraphViewer";
            this.Load += new System.EventHandler(this.GraphViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.Diagram.NDrawingDocument nDrawingDocument1;
        private Nevron.Diagram.WinForm.NDrawingView nDrawingView1;
        private Nevron.Diagram.WinForm.NPanAndZoomControl nPanAndZoomControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}