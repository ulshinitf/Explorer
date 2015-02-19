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
        string currListViewAdress = "";

        public MainForm()
        {
            InitializeComponent();

            listView1.ColumnClick += new ColumnClickEventHandler(ClickOnColumn);
            ColumnHeader c = new ColumnHeader();
            c.Text = "Name";
            c.Width = c.Width + 80;
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Size";
            c2.Width = c2.Width + 60;
            ColumnHeader c3 = new ColumnHeader();
            c3.Text = "Type";
            c3.Width = c3.Width + 60;            
            ColumnHeader c4 = new ColumnHeader();
            c4.Text = "Changed";
            c4.Width = c4.Width + 60;
            listView1.Columns.Add(c);
            listView1.Columns.Add(c2);
            listView1.Columns.Add(c3);
            listView1.Columns.Add(c4);

            string[] str = Environment.GetLogicalDrives();
            int n=1;
            foreach(string s in str)
            {
                try
                {
                    TreeNode tn = new TreeNode();
                    tn.Name = s;
                    tn.Text = "Local drive " + s;
                    treeView1.Nodes.Add(tn.Name, tn.Text, 2);
                    FileInfo f = new FileInfo(@s);
                    string t = "";
                    string[] str2 = Directory.GetDirectories(@s);
                    foreach (string s2 in str2)
                    {
                        t = s2.Substring(s2.LastIndexOf('\\')+1);
                        ((TreeNode)treeView1.Nodes[n - 1]).Nodes.Add(s2, t, 0);
                    }
                }
                catch { }
                n++;
            }
            foreach (TreeNode tn in treeView1.Nodes)
            {
                for (int i = 65; i < 91; i++)
                {
                    char sym = Convert.ToChar(i);
                    if (tn.Name == sym + ":\\")
                        tn.SelectedImageIndex = 2;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
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
            listView1.Items.Clear();
            currListViewAdress = e.Node.Name;
            addressTextBox.Text = currListViewAdress;
            //заполнение ListView
            try
            {
                if (listView1.View != View.Tile)
                {
                    FileInfo f = new FileInfo(@e.Node.Name);
                    string t = "";
                    string[] str2 = Directory.GetDirectories(@e.Node.Name);
                    ListViewItem lw = new ListViewItem();
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        string type = "Folder";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                    str2 = Directory.GetFiles(@e.Node.Name);
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        string type = "File";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                }
                else
                {
                    FileInfo f = new FileInfo(@e.Node.Name);
                    string t = "";
                    string[] str2 = Directory.GetDirectories(@e.Node.Name);
                    ListViewItem lw = new ListViewItem();
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t }, 0);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                    str2 = Directory.GetFiles(@e.Node.Name);
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                }
            }
            catch { }

        }

        private void iconsView_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void imagesView_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void tilesView_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
            listView1.Items.Clear();
            FileInfo f = new FileInfo(@currListViewAdress);
            string t = "";
            string[] str2 = Directory.GetDirectories(@currListViewAdress);
            ListViewItem lw = new ListViewItem();
            foreach (string s2 in str2)
            {
                f = new FileInfo(@s2);
                t = s2.Substring(s2.LastIndexOf('\\') + 1);
                lw = new ListViewItem(new string[] { t }, 0);
                lw.Name = s2;
                listView1.Items.Add(lw);
            }
            str2 = Directory.GetFiles(@currListViewAdress);
            foreach (string s2 in str2)
            {
                f = new FileInfo(@s2);
                t = s2.Substring(s2.LastIndexOf('\\') + 1);
                lw = new ListViewItem(new string[] { t }, 1);
                lw.Name = s2;
                listView1.Items.Add(lw);
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void tableView_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Items.Clear();
            FileInfo f = new FileInfo(@currListViewAdress);
            string t = "";
            string[] str2 = Directory.GetDirectories(@currListViewAdress);
            ListViewItem lw = new ListViewItem();
            foreach (string s2 in str2)
            {
                f = new FileInfo(@s2);
                string type = "Folder";
                t = s2.Substring(s2.LastIndexOf('\\') + 1);
                lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                lw.Name = s2;
                listView1.Items.Add(lw);
            }
            str2 = Directory.GetFiles(@currListViewAdress);
            foreach (string s2 in str2)
            {
                f = new FileInfo(@s2);
                string type = "File";
                t = s2.Substring(s2.LastIndexOf('\\') + 1);
                lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                lw.Name = s2;
                listView1.Items.Add(lw);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems[0].Text.IndexOf('.') == -1)
            {
                Adresses.Add(listView1.SelectedItems[0].Name);
                currIndex++;
                currListViewAdress = ((string)Adresses[currIndex]);
                if (currIndex + 1 == Adresses.Count)
                    buttonForward.Enabled = false;
                else
                    buttonForward.Enabled = true;
                if(currIndex - 1 == -1)
                    buttonBack.Enabled = false;
                else
                    buttonBack.Enabled = true;
                currListViewAdress = listView1.SelectedItems[0].Name;
                addressTextBox.Text = currListViewAdress;
                FileInfo f = new FileInfo(@listView1.SelectedItems[0].Name);
                string t = "";
                string[] str2 = Directory.GetDirectories(@listView1.SelectedItems[0].Name);
                string[] str3 = Directory.GetFiles(@listView1.SelectedItems[0].Name);
                listView1.Items.Clear();
                ListViewItem lw = new ListViewItem();
                if (listView1.View == View.Details)
                {
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        string type = "Folder";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                    foreach (string s2 in str3)
                    {
                        f = new FileInfo(@s2);
                        string type = "File";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
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
                        listView1.Items.Add(lw);
                    }
                    foreach (string s2 in str3)
                    {
                        f = new FileInfo(@s2);
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                }
            }
            else
            {
                System.Diagnostics.Process MyProc = new System.Diagnostics.Process();
                MyProc.StartInfo.FileName = @listView1.SelectedItems[0].Name;
                MyProc.Start();
            }
        }
        private void ClickOnColumn(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                if (listView1.Sorting == SortOrder.Descending)
                    listView1.Sorting = SortOrder.Ascending;
                else
                    listView1.Sorting = SortOrder.Descending;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Refresh();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
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
                currListViewAdress = ((string)Adresses[currIndex]);
                if (currIndex + 1 == Adresses.Count)
                    buttonForward.Enabled = false;
                else
                    buttonForward.Enabled = true;
                if (currIndex - 1 == -1)
                    buttonBack.Enabled = false;
                else
                    buttonBack.Enabled = true;
                addressTextBox.Text = currListViewAdress;
                FileInfo f = new FileInfo(@currListViewAdress);
                string t = "";
                string[] str2 = Directory.GetDirectories(@currListViewAdress);
                string[] str3 = Directory.GetFiles(@currListViewAdress);
                listView1.Items.Clear();
                ListViewItem lw = new ListViewItem();
                if (listView1.View == View.Details)
                {
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        string type = "Folder";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                    foreach (string s2 in str3)
                    {
                        f = new FileInfo(@s2);
                        string type = "File";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
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
                        listView1.Items.Add(lw);
                    }
                    foreach (string s2 in str3)
                    {
                        f = new FileInfo(@s2);
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                }
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (currIndex + 1 != Adresses.Count)
            {
                currIndex++;
                currListViewAdress = ((string)Adresses[currIndex]);
                if (currIndex + 1 == Adresses.Count)
                    buttonForward.Enabled = false;
                else
                    buttonForward.Enabled = true;
                if (currIndex - 1 == -1)
                    buttonBack.Enabled = false;
                else
                    buttonBack.Enabled = true;
                addressTextBox.Text = currListViewAdress;
                FileInfo f = new FileInfo(@currListViewAdress);
                string t = "";
                string[] str2 = Directory.GetDirectories(@currListViewAdress);
                string[] str3 = Directory.GetFiles(@currListViewAdress);
                listView1.Items.Clear();
                ListViewItem lw = new ListViewItem();
                if (listView1.View == View.Details)
                {
                    foreach (string s2 in str2)
                    {
                        f = new FileInfo(@s2);
                        string type = "Folder";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                    foreach (string s2 in str3)
                    {
                        f = new FileInfo(@s2);
                        string type = "File";
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
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
                        listView1.Items.Add(lw);
                    }
                    foreach (string s2 in str3)
                    {
                        f = new FileInfo(@s2);
                        t = s2.Substring(s2.LastIndexOf('\\') + 1);
                        lw = new ListViewItem(new string[] { t }, 1);
                        lw.Name = s2;
                        listView1.Items.Add(lw);
                    }
                }
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
                    currListViewAdress = addressTextBox.Text;
                    Adresses.Add(addressTextBox.Text);
                    if (currIndex + 1 == Adresses.Count)
                        buttonForward.Enabled = false;
                    else
                        buttonForward.Enabled = true;
                    if (currIndex - 1 == -1)
                        buttonBack.Enabled = false;
                    else
                        buttonBack.Enabled = true;
                    FileInfo f = new FileInfo(addressTextBox.Text);
                    string t = "";                    
                    listView1.Items.Clear();
                    ListViewItem lw = new ListViewItem();
                    if (listView1.View == View.Details)
                    {
                        foreach (string s2 in str2)
                        {
                            f = new FileInfo(@s2);
                            string type = "Folder";
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                            lw.Name = s2;
                            listView1.Items.Add(lw);
                        }
                        foreach (string s2 in str3)
                        {
                            f = new FileInfo(@s2);
                            string type = "File";
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                            lw.Name = s2;
                            listView1.Items.Add(lw);
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
                            listView1.Items.Add(lw);
                        }
                        foreach (string s2 in str3)
                        {
                            f = new FileInfo(@s2);
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            lw = new ListViewItem(new string[] { t }, 1);
                            lw.Name = s2;
                            listView1.Items.Add(lw);
                        }
                    }
                }
                catch
                {
                    addressTextBox.Text = currListViewAdress;
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
                    currListViewAdress = addressTextBox.Text;
                    if (currIndex + 1 == Adresses.Count)
                        buttonForward.Enabled = false;
                    else
                        buttonForward.Enabled = true;
                    if (currIndex - 1 == -1)
                        buttonBack.Enabled = false;
                    else
                        buttonBack.Enabled = true;
                    FileInfo f = new FileInfo(addressTextBox.Text + "\\");
                    string t = "";
                    listView1.Items.Clear();
                    ListViewItem lw = new ListViewItem();
                    if (listView1.View == View.Details)
                    {
                        foreach (string s2 in str2)
                        {
                            f = new FileInfo(@s2);
                            string type = "Folder";
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            lw = new ListViewItem(new string[] { t, "", type, f.LastWriteTime.ToString() }, 0);
                            lw.Name = s2;
                            listView1.Items.Add(lw);
                        }
                        foreach (string s2 in str3)
                        {
                            f = new FileInfo(@s2);
                            string type = "File";
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            lw = new ListViewItem(new string[] { t, f.Length.ToString() + " bytes", type, f.LastWriteTime.ToString() }, 1);
                            lw.Name = s2;
                            listView1.Items.Add(lw);
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
                            listView1.Items.Add(lw);
                        }
                        foreach (string s2 in str3)
                        {
                            f = new FileInfo(@s2);
                            t = s2.Substring(s2.LastIndexOf('\\') + 1);
                            lw = new ListViewItem(new string[] { t }, 1);
                            lw.Name = s2;
                            listView1.Items.Add(lw);
                        }
                    }
                }
                catch
                {
                    addressTextBox.Text = currListViewAdress;
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
    }
}
