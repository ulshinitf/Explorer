using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Explorer
{
    public partial class MainForm : Form
    {
        private ArrayList Adresses = new ArrayList();
        private int _currIndex = -1;
        private string _currListViewAddress = "";

        public MainForm()
        {
            InitializeComponent();
            InitializeColumns();
            InitializeTreeView();
        }

        #region Event Handlers

        private void mainTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Adresses.Count != 0)
            {
                string temp = ((string) Adresses[Adresses.Count - 1]);
                Adresses.Clear();
                Adresses.Add(temp);
                _currIndex = 0;
            }

            Adresses.Add(e.Node.Name);

            _currIndex++;

            CheckButtonsState();
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

            GetItems(_currListViewAddress);
        }

        private void listView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.List;
        }

        private void tableView_Click(object sender, EventArgs e)
        {
            mainListView.View = View.Details;
            mainListView.Items.Clear();
            GetItems(_currListViewAddress);
        }

        private void mainListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mainListView.SelectedItems[0].Text.IndexOf('.') == -1)
            {
                Adresses.Add(mainListView.SelectedItems[0].Name);
                _currIndex++;
                _currListViewAddress = ((string) Adresses[_currIndex]);

                CheckButtonsState();

                _currListViewAddress = mainListView.SelectedItems[0].Name;
                addressTextBox.Text = _currListViewAddress;

                GetItems(_currListViewAddress);
            }
            else
            {
                var process = new System.Diagnostics.Process {StartInfo = {FileName = mainListView.SelectedItems[0].Name}};
                process.Start();
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

            foreach (string[] strings in (from TreeNode tn in e.Node.Nodes select Directory.GetDirectories(@tn.Name)))
            {
                foreach (string name in strings)
                {
                    var temp = new TreeNode {Name = name, Text = name.Substring(name.LastIndexOf('\\') + 1)};
                    e.Node.Nodes[i].Nodes.Add(temp);
                }
                i++;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (_currIndex - 1 != -1)
            {
                _currIndex--;
                _currListViewAddress = ((string) Adresses[_currIndex]);

                CheckButtonsState();

                addressTextBox.Text = _currListViewAddress;

                GetItems(_currListViewAddress);
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (_currIndex + 1 != Adresses.Count)
            {
                _currIndex++;
                _currListViewAddress = ((string) Adresses[_currIndex]);

                CheckButtonsState();

                addressTextBox.Text = _currListViewAddress;

                GetItems(_currListViewAddress);
            }
        }

        private void addressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int) Keys.Enter)
            {
                try
                {
                    _currIndex++;
                    _currListViewAddress = addressTextBox.Text;
                    Adresses.Add(addressTextBox.Text);

                    CheckButtonsState();

                    GetItems(_currListViewAddress);
                }
                catch
                {
                    addressTextBox.Text = _currListViewAddress;
                }
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            int index = addressTextBox.Text.LastIndexOf('\\');
            if (index != -1)
            {
                addressTextBox.Text = addressTextBox.Text.Substring(0, index);
                try
                {
                    _currIndex--;
                    _currListViewAddress = addressTextBox.Text + "\\";

                    CheckButtonsState();

                    GetItems(_currListViewAddress);
                }
                catch
                {
                    addressTextBox.Text = _currListViewAddress;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Explorer © 2015", "About Explorer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    buttonBack_Click(buttonBack, null);
                    break;
            }
        }

        #endregion

        #region Initializers

        private void InitializeColumns()
        {
            mainListView.ColumnClick += ColumnNameClick;

            var header1 = new ColumnHeader {Text = "Name"};
            header1.Width += 60;
            var header2 = new ColumnHeader {Text = "Size"};
            header2.Width += 30;
            var header3 = new ColumnHeader {Text = "Type"};
            var header4 = new ColumnHeader {Text = "Changed"};
            header4.Width += 55;

            mainListView.Columns.Add(header1);
            mainListView.Columns.Add(header2);
            mainListView.Columns.Add(header3);
            mainListView.Columns.Add(header4);
        }

        private void InitializeTreeView()
        {
            string[] str = Environment.GetLogicalDrives();
            int count = 1;

            foreach (string name in str)
            {
                var treeNode = new TreeNode {Name = name, Text = "Local drive " + name};
                mainTreeView.Nodes.Add(treeNode.Name, treeNode.Text, 2);
                string[] directories = Directory.GetDirectories(name);
                
                foreach (string item in directories)
                {
                    string temp = item.Substring(item.LastIndexOf('\\') + 1);
                    mainTreeView.Nodes[count - 1].Nodes.Add(item, temp, 0);
                }    
                
                count++;
            }

            foreach (TreeNode tn in mainTreeView.Nodes)
            {
                for (int i = 65; i < 91; i++)
                {
                    char c = Convert.ToChar(i);
                    if (tn.Name == c + ":\\")
                        tn.SelectedImageIndex = 2;
                }
            }
        }

        #endregion

        private void GetItems(string address)
        {
            string temp;
            string[] directories = Directory.GetDirectories(address);
            string[] files = Directory.GetFiles(address);
            mainListView.Items.Clear();

            if (mainListView.View == View.Details)
            {
                ListViewItem listViewItem;
                FileInfo fileInfo;

                foreach (string item in directories)
                {
                    fileInfo = new FileInfo(item);
                    const string type = "Folder";
                    temp = item.Substring(item.LastIndexOf('\\') + 1);
                    listViewItem = new ListViewItem(new string[] {temp, "", type, fileInfo.LastWriteTime.ToString()}, 0) {Name = item};
                    mainListView.Items.Add(listViewItem);
                }

                foreach (string item in files)
                {
                    fileInfo = new FileInfo(item);
                    const string type = "File";
                    temp = item.Substring(item.LastIndexOf('\\') + 1);
                    listViewItem =
                        new ListViewItem(
                            new string[] {temp, fileInfo.Length.ToString() + " bytes", type, fileInfo.LastWriteTime.ToString()}, 1)
                            {
                                Name = item
                            };
                    mainListView.Items.Add(listViewItem);
                }
            }
            else
            {
                ListViewItem listViewItem;

                foreach (string item in directories)
                {
                    temp = item.Substring(item.LastIndexOf('\\') + 1);
                    listViewItem = new ListViewItem(new string[] {temp}, 0) {Name = item};
                    mainListView.Items.Add(listViewItem);
                }

                foreach (string item in files)
                {
                    temp = item.Substring(item.LastIndexOf('\\') + 1);
                    listViewItem = new ListViewItem(new string[] {temp}, 1) {Name = item};
                    mainListView.Items.Add(listViewItem);
                }
            }
        }

        private void GetItemsOnTreeViewSelect(TreeViewEventArgs e)
        {
            _currListViewAddress = e.Node.Name;
            addressTextBox.Text = _currListViewAddress;

            GetItems(_currListViewAddress);
        }

        private void ColumnNameClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                mainListView.Sorting = mainListView.Sorting == SortOrder.Descending 
                    ? SortOrder.Ascending 
                    : SortOrder.Descending;
            }
        }

        private void CheckButtonsState()
        {
            buttonForward.Enabled = (_currIndex + 1 != Adresses.Count);
            buttonBack.Enabled = (_currIndex - 1 != -1);
        }
    }
}