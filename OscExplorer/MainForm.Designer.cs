namespace OscExplorer
{
	partial class MainForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openWithToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.listView1 = new System.Windows.Forms.ListView();
			this.dirContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lainnyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addressBox = new System.Windows.Forms.TextBox();
			this.ImagePlacer = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.dirContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openWithToolStripMenuItem1});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem1.Text = "File";
			// 
			// openToolStripMenuItem1
			// 
			this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
			this.openToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.openToolStripMenuItem1.Text = "Open";
			// 
			// openWithToolStripMenuItem1
			// 
			this.openWithToolStripMenuItem1.Name = "openWithToolStripMenuItem1";
			this.openWithToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.openWithToolStripMenuItem1.Text = "Open With";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.Location = new System.Drawing.Point(0, 75);
			this.treeView1.Name = "treeView1";
			this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.treeView1.Size = new System.Drawing.Size(135, 375);
			this.treeView1.TabIndex = 2;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
			// 
			// listView1
			// 
			this.listView1.ContextMenuStrip = this.dirContextMenu;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(135, 75);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(665, 375);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// dirContextMenu
			// 
			this.dirContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openWithToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.refreshToolStripMenuItem});
			this.dirContextMenu.Name = "contextMenuStrip1";
			this.dirContextMenu.Size = new System.Drawing.Size(159, 202);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// openWithToolStripMenuItem
			// 
			this.openWithToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lainnyaToolStripMenuItem});
			this.openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
			this.openWithToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.openWithToolStripMenuItem.Text = "Open With";
			// 
			// lainnyaToolStripMenuItem
			// 
			this.lainnyaToolStripMenuItem.Name = "lainnyaToolStripMenuItem";
			this.lainnyaToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.lainnyaToolStripMenuItem.Text = "Lainnya";
			this.lainnyaToolStripMenuItem.Click += new System.EventHandler(this.LainnyaToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.folderToolStripMenuItem});
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.newToolStripMenuItem.Text = "New";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.fileToolStripMenuItem.Text = "&File";
			this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
			// 
			// folderToolStripMenuItem
			// 
			this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
			this.folderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.folderToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.folderToolStripMenuItem.Text = "Folde&r";
			this.folderToolStripMenuItem.Click += new System.EventHandler(this.FolderToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
			// 
			// addressBox
			// 
			this.addressBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addressBox.Location = new System.Drawing.Point(0, 49);
			this.addressBox.Name = "addressBox";
			this.addressBox.Size = new System.Drawing.Size(800, 26);
			this.addressBox.TabIndex = 4;
			// 
			// ImagePlacer
			// 
			this.ImagePlacer.Interval = 10;
			this.ImagePlacer.Tick += new System.EventHandler(this.ImagePlacer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.addressBox);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Explorer";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.dirContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.TextBox addressBox;
		private System.Windows.Forms.ContextMenuStrip dirContextMenu;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lainnyaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem1;
		private System.Windows.Forms.Timer ImagePlacer;
	}
}

