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
        private Filer filer;
        private int count = 0;
        Dictionary<string, string[]> maps = new Dictionary<string, string[]>();
        public FrmFiler()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.filer = new Filer(this);
            //this.filer.Go();
            OpenFileDialog opfd = new OpenFileDialog();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            opfd.Filter = "Theseus and Minotaur Files (.tam)|*.tam|All files (*.*)|*.*";
            opfd.FilterIndex = 1;
            opfd.Multiselect = false;
            //theDialog.Title = "Open Text File";
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
                        textBox1.Visible = true;
                        listBox1.Visible = true;
                        listBox1.Items.Add("Map " + count);
                        maps.Add("Map " + count, filelines);
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
            string[] lines;
            foreach (var something in maps)
            {
                if (something.Key == this.listBox1.SelectedValue.ToString())
                {
                    lines = something.Value;
                }
            }
            return lines;
        }

    }
}
