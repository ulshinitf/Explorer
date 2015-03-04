namespace Explorer
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressToolStrip = new System.Windows.Forms.ToolStrip();
            this.buttonBack = new System.Windows.Forms.ToolStripButton();
            this.buttonForward = new System.Windows.Forms.ToolStripButton();
            this.addressTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.viewsList = new System.Windows.Forms.ToolStripDropDownButton();
            this.iconsView = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesView = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesView = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ToolStripMenuItem();
            this.tableView = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUp = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainListView = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.addressToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 411);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(532, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.White;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.aboutToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(532, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.ExitMenuItem});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(35, 20);
            this.FileMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click+=new System.EventHandler(aboutToolStripMenuItem_Click);
            // 
            // addressToolStrip
            // 
            this.addressToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.addressToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonBack,
            this.buttonForward,
            this.addressTextBox,
            this.viewsList,
            this.buttonUp});
            this.addressToolStrip.Location = new System.Drawing.Point(0, 24);
            this.addressToolStrip.Name = "addressToolStrip";
            this.addressToolStrip.Size = new System.Drawing.Size(532, 25);
            this.addressToolStrip.TabIndex = 2;
            this.addressToolStrip.Text = "toolStrip1";
            // 
            // buttonBack
            // 
            this.buttonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBack.Enabled = false;
            this.buttonBack.Image = global::Explorer.Properties.Resources.back_e;
            this.buttonBack.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(23, 22);
            this.buttonBack.Text = "Назад";
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonForward.Enabled = false;
            this.buttonForward.Image = global::Explorer.Properties.Resources.next_e;
            this.buttonForward.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(23, 22);
            this.buttonForward.Text = "Вперёд";
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(413, 25);
            this.addressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addressTextBox_KeyDown);
            // 
            // viewsList
            // 
            this.viewsList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.viewsList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconsView,
            this.imagesView,
            this.tilesView,
            this.listView,
            this.tableView});
            this.viewsList.Image = ((System.Drawing.Image)(resources.GetObject("viewsList.Image")));
            this.viewsList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.viewsList.Name = "viewsList";
            this.viewsList.Size = new System.Drawing.Size(42, 22);
            this.viewsList.Text = "View";
            // 
            // iconsView
            // 
            this.iconsView.Name = "iconsView";
            this.iconsView.Size = new System.Drawing.Size(120, 22);
            this.iconsView.Text = "Icons";
            this.iconsView.Click += new System.EventHandler(this.iconsView_Click);
            // 
            // imagesView
            // 
            this.imagesView.Name = "imagesView";
            this.imagesView.Size = new System.Drawing.Size(120, 22);
            this.imagesView.Text = "Images";
            this.imagesView.Click += new System.EventHandler(this.imagesView_Click);
            // 
            // tilesView
            // 
            this.tilesView.Name = "tilesView";
            this.tilesView.Size = new System.Drawing.Size(120, 22);
            this.tilesView.Text = "Tiles";
            this.tilesView.Click += new System.EventHandler(this.tilesView_Click);
            // 
            // listView
            // 
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(120, 22);
            this.listView.Text = "List";
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // tableView
            // 
            this.tableView.Name = "tableView";
            this.tableView.Size = new System.Drawing.Size(120, 22);
            this.tableView.Text = "Table";
            this.tableView.Click += new System.EventHandler(this.tableView_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(24, 22);
            this.buttonUp.Text = "Up";
            this.buttonUp.Click+=new System.EventHandler(buttonUp_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(532, 362);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mainTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.mainListView);
            this.splitContainer2.Size = new System.Drawing.Size(532, 293);
            this.splitContainer2.SplitterDistance = 177;
            this.splitContainer2.TabIndex = 0;
            // 
            // mainTreeView
            // 
            this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTreeView.ImageIndex = 0;
            this.mainTreeView.ImageList = this.imageList1;
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.SelectedImageIndex = 0;
            this.mainTreeView.Size = new System.Drawing.Size(177, 293);
            this.mainTreeView.TabIndex = 0;
            this.mainTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.mainTreeView_BeforeExpand);
            this.mainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainTreeView_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "directory_mini.bmp");
            this.imageList1.Images.SetKeyName(1, "file_mini.bmp");
            this.imageList1.Images.SetKeyName(2, "localdriver.png");
            // 
            // mainListView
            // 
            this.mainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListView.LargeImageList = this.imageList2;
            this.mainListView.Location = new System.Drawing.Point(0, 0);
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(351, 293);
            this.mainListView.SmallImageList = this.imageList1;
            this.mainListView.TabIndex = 0;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mainListView_MouseDoubleClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "directory.bmp");
            this.imageList2.Images.SetKeyName(1, "file.bmp");
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.asdToolStripMenuItem.Text = "asd";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 433);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.addressToolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Explorer";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.addressToolStrip.ResumeLayout(false);
            this.addressToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStrip addressToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ToolStripDropDownButton viewsList;
        private System.Windows.Forms.ToolStripMenuItem iconsView;
        private System.Windows.Forms.ToolStripMenuItem imagesView;
        private System.Windows.Forms.ToolStripMenuItem tilesView;
        private System.Windows.Forms.ToolStripMenuItem listView;
        private System.Windows.Forms.ToolStripMenuItem tableView;
        private System.Windows.Forms.ToolStripButton buttonBack;
        private System.Windows.Forms.ToolStripButton buttonForward;
        private System.Windows.Forms.ToolStripTextBox addressTextBox;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton buttonUp;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

