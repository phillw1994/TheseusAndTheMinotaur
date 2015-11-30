using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TheseusAndTheMinotaur
{
    public partial class FrmFiler : Form
    {
        private int count = 0;
        Dictionary<string, string[]> maps = new Dictionary<string, string[]>();
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public FrmFiler()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            opfd.Filter = "Theseus and Minotaur Files (.tam)|*.tam|All files (*.*)|*.*";
            opfd.FilterIndex = 1;
            opfd.Multiselect = false;
            opfd.Title = "Open Game File";
            opfd.InitialDirectory = @"C:\Users\" + userName + @"\Documents\";

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((opfd.OpenFile()) != null)
                    {
                        string filename = opfd.FileName;
                        string[] filelines = File.ReadAllLines(filename);
                        int i = 0;
                        while(i <= filelines.Length-1)
                        {
                            Debug.WriteLine(filelines[i]);
                            i += 1;
                        }
                        textBox1.Lines = filelines;
                        listBox1.Items.Add("Map " + count);
                        maps.Add("Map " + count, filelines);
                        listBox1.SelectedIndex = count;
                        saveAsToolStripMenuItem.Enabled = true;
                        btnSaveChanges.Enabled = true;
                        this.count += 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Lines = GetValueOfItem();
        }

        public string[] GetValueOfItem()
        {
            string[] lines = {};
            foreach (var something in maps)
            {
                if (this.listBox1.SelectedItem != null)
                {
                    if (something.Key == this.listBox1.SelectedItem.ToString())
                    {
                        lines = something.Value;
                    }
                }
            }
            return lines;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            sfd.Filter = "Theseus and Minotaur Files (.tam)|*.tam|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "Save Game File";
            sfd.InitialDirectory = @"C:\Users\" + userName + @"\Documents\";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filename = sfd.FileName;
                string[] lines = textBox1.Lines;
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach(string line in lines)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            MessageBox.Show(this,"The file has been saved successfully","Saving Completed",MessageBoxButtons.OK);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.btnReadOnly.Enabled = true;
            this.textBox1.ReadOnly = false;
            btnModify.Enabled = false;
        }

        private void btnReadOnly_Click(object sender, EventArgs e)
        {
            this.btnModify.Enabled = true;
            this.textBox1.ReadOnly = true;
            btnReadOnly.Enabled = false;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            this.maps[listBox1.SelectedItem.ToString()] = textBox1.Lines;
        }

    }
}
