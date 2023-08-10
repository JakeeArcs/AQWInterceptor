namespace AQWInterceptor
{
    partial class Root
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "Hello";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(385, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(403, 394);
            this.treeView1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(367, 394);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startConnectionToolStripMenuItem,
            this.stopConnectionToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startConnectionToolStripMenuItem
            // 
            this.startConnectionToolStripMenuItem.Name = "startConnectionToolStripMenuItem";
            this.startConnectionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.startConnectionToolStripMenuItem.Text = "Start Connection";
            this.startConnectionToolStripMenuItem.Click += new System.EventHandler(this.startConnectionToolStripMenuItem_Click);
            // 
            // stopConnectionToolStripMenuItem
            // 
            this.stopConnectionToolStripMenuItem.Name = "stopConnectionToolStripMenuItem";
            this.stopConnectionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.stopConnectionToolStripMenuItem.Text = "Stop Connection";
            this.stopConnectionToolStripMenuItem.Click += new System.EventHandler(this.stopConnectionToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem,
            this.showClientToolStripMenuItem,
            this.showServerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "Logs";
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // showClientToolStripMenuItem
            // 
            this.showClientToolStripMenuItem.Checked = true;
            this.showClientToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showClientToolStripMenuItem.Name = "showClientToolStripMenuItem";
            this.showClientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showClientToolStripMenuItem.Text = "Show Client";
            this.showClientToolStripMenuItem.Click += new System.EventHandler(this.showClientToolStripMenuItem_Click);
            // 
            // showServerToolStripMenuItem
            // 
            this.showServerToolStripMenuItem.Checked = true;
            this.showServerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showServerToolStripMenuItem.Name = "showServerToolStripMenuItem";
            this.showServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showServerToolStripMenuItem.Text = "Show Server";
            this.showServerToolStripMenuItem.Click += new System.EventHandler(this.showServerToolStripMenuItem_Click);
            // 
            // Root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Root";
            this.Text = "AQW Packet Interceptor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Root_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showServerToolStripMenuItem;
    }
}

