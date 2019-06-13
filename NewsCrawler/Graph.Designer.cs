namespace NewsCrawler
{
    partial class Graph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.UpdateDrawingWhileLayouting = new System.Windows.Forms.CheckBox();
            this.document = new Nevron.Diagram.NDrawingDocument();
            this.view = new Nevron.Diagram.WinForm.NDrawingView();
            this.LayoutButton1 = new Nevron.UI.WinForm.Controls.NButton();
            this.nPanAndZoomControl1 = new Nevron.Diagram.WinForm.NPanAndZoomControl();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Left;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(156, 586);
            this.propertyGrid1.TabIndex = 1;
            // 
            // UpdateDrawingWhileLayouting
            // 
            this.UpdateDrawingWhileLayouting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateDrawingWhileLayouting.Location = new System.Drawing.Point(8, 778);
            this.UpdateDrawingWhileLayouting.Name = "UpdateDrawingWhileLayouting";
            this.UpdateDrawingWhileLayouting.Size = new System.Drawing.Size(931, 17);
            this.UpdateDrawingWhileLayouting.TabIndex = 8;
            this.UpdateDrawingWhileLayouting.Text = "Update drawing while layouting";
            this.UpdateDrawingWhileLayouting.UseVisualStyleBackColor = true;
            // 
            // document
            // 
            this.document.DesignTimeState = ((Nevron.Diagram.NBinaryState)(resources.GetObject("document.DesignTimeState")));
            // 
            // view
            // 
            this.view.AllowDrop = true;
            this.view.DesignTimeState = ((Nevron.Diagram.NBinaryState)(resources.GetObject("view.DesignTimeState")));
            this.view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view.Document = this.document;
            this.view.Location = new System.Drawing.Point(0, 0);
            this.view.Name = "view";
            this.view.RenderTechnology = Nevron.GraphicsCore.RenderTechnology.GDIPlus;
            this.view.Size = new System.Drawing.Size(971, 586);
            this.view.TabIndex = 9;
            this.view.Text = "nDrawingView1";
            // 
            // LayoutButton1
            // 
            this.LayoutButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LayoutButton1.Location = new System.Drawing.Point(156, 557);
            this.LayoutButton1.Name = "LayoutButton1";
            this.LayoutButton1.Size = new System.Drawing.Size(815, 29);
            this.LayoutButton1.TabIndex = 10;
            this.LayoutButton1.Text = "Layout";
            this.LayoutButton1.Click += new System.EventHandler(this.LayoutButton1_Click);
            // 
            // nPanAndZoomControl1
            // 
            this.nPanAndZoomControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.nPanAndZoomControl1.LargeZoomChangeFactor = ((uint)(10u));
            this.nPanAndZoomControl1.Location = new System.Drawing.Point(735, 0);
            this.nPanAndZoomControl1.MasterView = this.view;
            this.nPanAndZoomControl1.Name = "nPanAndZoomControl1";
            this.nPanAndZoomControl1.Size = new System.Drawing.Size(236, 557);
            this.nPanAndZoomControl1.TabIndex = 11;
            this.nPanAndZoomControl1.Text = "nPanAndZoomControl1";
            // 
            // Graph
            // 
            this.ClientSize = new System.Drawing.Size(971, 586);
            this.Controls.Add(this.nPanAndZoomControl1);
            this.Controls.Add(this.LayoutButton1);
            this.Controls.Add(this.UpdateDrawingWhileLayouting);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.view);
            this.Name = "Graph";
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.Diagram.NDrawingDocument document;
        private Nevron.Diagram.WinForm.NDrawingView view;
        private Nevron.UI.WinForm.Controls.NButton LayoutButton1;
        private System.Windows.Forms.CheckBox UpdateDrawingWhileLayouting;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Nevron.Diagram.WinForm.NPanAndZoomControl nPanAndZoomControl1;
    }
}