using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Explorer
{
    public partial class MainForm : Form
    {
        ArrayList Adresses = new ArrayList();
        int currIndex =-1;
        string currListViewAddress = "";

        public MainForm()
        {
            InitializeComponent();

            InitializeColumns();

            InitializeTreeView();
        }

        #region Event Handlers

        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strtmp="";
            if (Adresses.Count != 0)
            {
                strtmp = ((string)Adresses[Adresses.Count - 1]);
                Adresses.Clear();
                Adresses.Add(strtmp);
                currIndex = 0;
            }            
            Adresses.Add(e.Node.Name);
            currIndex++;

            if (currIndex + 1 == Adresses.Count)
                buttonForward.Enabled = false;
            else
                buttonForward.Enabled = true;
            if (currIndex - 1 == -1)
                buttonBack.Enabled = false;
            else
                buttonBack.Enabled = true;
            mainListView.Items.Clear();

            GetItemsOnTreeViewSelect(e);
        }

        private void iconsView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.SmallIcon;
        }

        private void imagesView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.LargeIcon;
        }

        private void tilesView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.Tile;
            mainListView.Items.Clear();

            GetItems(currListViewAddress);
        }

        private void listView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.List;
        }

        private void tableView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.Details;
            mainListView.Items.Clear();
            GetItems(currListViewAddress);
        }

        private void mainListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mainListView.SelectedItems[0].Text.IndexOf('.') == -1)
            {
                Adresses.Add(mainListView.SelectedItems[0].Name);
                currIndex++;
                currListViewAddress = ((string)Adresses[currIndex]);
                if (currIndex + 1 == Adresses.Count)
                    buttonForward.Enabled = false;
                else
                    buttonForward.Enabled = true;
                if(currIndex - 1 == -1)
                    buttonBack.Enabled = false;
                else
                    buttonBack.Enabled = true;
                currListViewAddress = mainListView.SelectedItems[0].Name;
                addressTextBox.Text = currListViewAddress;

                GetItems(currListViewAddress);
            }
            else
            {
                System.Diagnostics.Process MyProc = new System.Diagnostics.Process();
                MyProc.StartInfo.FileName = mainListView.SelectedItems[0].Name;
                MyProc.Start();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainListView.Refresh();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            int i = 0;

            try
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    string[] str2 = Directory.GetDirectories(@tn.Name);
                    foreach (string str in str2)
                    {
                        TreeNode temp = new TreeNode();
                        temp.Name = str;
                        temp.Text = str.Substring(str.LastIndexOf('\\') + 1);
                        e.Node.Nodes[i].Nodes.Add(temp);
                    }
                    i++;
                }
            }
            catch { }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (currIndex - 1 != -1)
            {
                currIndex--;
                currListViewAddress = ((string)Adresses[currIndex]);
                if (currIndex + 1 == Adresses.Count)
                    buttonForward.Enabled = false;
                else
                    buttonForward.Enabled = true;
                if (currIndex - 1 == -1)
                    buttonBack.Enabled = false;
                else
                    buttonBack.Enabled = true;
                addressTextBox.Text = currListViewAddress;

                GetItems(currListViewAddress);
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (currIndex + 1 != Adresses.Count)
            {
                currIndex++;
                currListViewAddress = ((string)Adresses[currIndex]);
                if (currIndex + 1 == Adresses.Count)
                    buttonForward.Enabled = false;
                else
                    buttonForward.Enabled = true;
                if (currIndex - 1 == -1)
                    buttonBack.Enabled = false;
                else
                    buttonBack.Enabled = true;
                addressTextBox.Text = currListViewAddress;

                GetItems(currListViewAddress);
            }
        }

        private void addressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int) Keys.Enter)
            {
                try
                {
                    string[] str2 = Directory.GetDirectories(addressTextBox.Text);
                    string[] str3 = Directory.GetFiles(addressTextBox.Text);
                    currIndex++;
                    currListViewAddress = addressTextBox.Text;
                    Adresses.Add(addressTextBox.Text);
                    if (currIndex + 1 == Adresses.Count)
                        buttonForward.Enabled = false;
                    else
                        buttonForward.Enabled = true;
                    if (currIndex - 1 == -1)
                        buttonBack.Enabled = false;
                    else
                        buttonBack.Enabled = true;

                    GetItems(currListViewAddress);
                }
                catch
                {
                    addressTextBox.Text = currListViewAddress;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int lio = addressTextBox.Text.LastIndexOf('\\');
            if (lio != -1)
            {
                addressTextBox.Text = addressTextBox.Text.Substring(0, lio);
                try
                {
                    string[] str2 = Directory.GetDirectories(addressTextBox.Text + "\\");
                    string[] str3 = Directory.GetFiles(addressTextBox.Text + "\\");
                    currIndex--;
                    currListViewAddress = addressTextBox.Text;
                    if (currIndex + 1 == Adresses.Count)
                        buttonForward.Enabled = false;
                    else
                        buttonForward.Enabled = true;
                    if (currIndex - 1 == -1)
                        buttonBack.Enabled = false;
                    else
                        buttonBack.Enabled = true;

                    GetItems(currListViewAddress);
                }
                catch
                {
                    addressTextBox.Text = currListViewAddress;
                }
            }
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Explorer © 2015", "About Explorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back: buttonBack_Click(buttonBack, null);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Initializers

        private void InitializeColumns()
        {
            mainListView.ColumnClick += new ColumnClickEventHandler(ColumnNameClick);
            ColumnHeader c = new ColumnHeader();
            c.Text = "Name";
            c.Width = c.Width + 80;
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Size";
            c2.Width = c2.Width + 60;
            ColumnHeader c3 = new ColumnHeader();
            c3.Text = "Type";
            ColumnHeader c4 = new ColumnHeader();
            c4.Text = "Changed";
            c4.Width = c4.Width + 60;
            mainListView.Columns.Add(c);
            mainListView.Columns.Add(c2);
            mainListView.Columns.Add(c3);
            mainListView.Columns.Add(c4);
        }

        private void InitializeTreeView()
        {
            string[] str = Environment.GetLogicalDrives();
            int n = 1;
            foreach (string s in str)
            {
                try
                {
                    TreeNode tn = new TreeNode();
                    tn.Name = s;
                    tn.Text = "Local drive " + s;
                    mainTreeView.Nodes.Add(tn.Name, tn.Text, 2);
                    FileInfo f = new FileInfo(@s);
                    string t = "";
                    string[] str2 = Directory.GetDirectories(@s);
                    foreach (string s2 in str2)
                    {
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        ((TreeNode)mainTreeView.Nodes[n - 1]).Nodes.Add(s2, t, 0);
                    }
                }
                catch { }
                n++;
            }
            foreach (TreeNode tn in mainTreeView.Nodes)
            {
                for (int i = 65; i < 91; i++)
                {
                    char sym = Convert.ToChar(i);
                    if (tn.Name == sym + ":\\")
                        tn.SelectedImageIndex = 2;
                }
            }
        }

        #endregion

        private void GetItems(string address)
        {
            FileInfo f = new FileInfo(address);
            string t = "";
            string[] str2 = Directory.GetDirectories(address);
            string[] str3 = Directory.GetFiles(address);
            mainListView.Items.Clear();
            ListViewItem lw = new ListViewItem();
            if (mainListView.View == View.Details)
            {
                foreach (string s2 in str2)
                {
                    f = new FileInfo(@s2);
                    string type = "Folder";
                    t = s2.Substring(s2.LastIndexOf('\\') + 1);
                    lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                    lw.Name = s2;
                    mainListView.Items.Add(lw);
                }
                foreach (string s2 in str3)
                {
                    f = new FileInfo(@s2);
                    string type = "File";
                    t = s2.Substring(s2.LastIndexOf('\\') + 1);
                    lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                    lw.Name = s2;
                    mainListView.Items.Add(lw);
                }
            }
            else
            {
                foreach (string s2 in str2)
                {
                    f = new FileInfo(@s2);
                    t = s2.Substring(s2.LastIndexOf('\\') + 1);
                    lw = new ListViewItem(new string[] { t }, 0);
                    lw.Name = s2;
                    mainListView.Items.Add(lw);
                }
                foreach (string s2 in str3)
                {
                    f = new FileInfo(@s2);
                    t = s2.Substring(s2.LastIndexOf('\\') + 1);
                    lw = new ListViewItem(new string[] { t }, 1);
                    lw.Name = s2;
                    mainListView.Items.Add(lw);
                }
            }
        }

        private void GetItemsOnTreeViewSelect(TreeViewEventArgs e)
        {
            currListViewAddress = e.Node.Name;
            addressTextBox.Text = currListViewAddress;

            GetItems(@currListViewAddress);
        }

        private void ColumnNameClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                if (mainListView.Sorting == SortOrder.Descending)
                    mainListView.Sorting = SortOrder.Ascending;
                else
                    mainListView.Sorting = SortOrder.Descending;
            }
        }

    }
}
