using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TheseusAndTheMinotaur
{
    public partial class FrmNewMaze : Form
    {
        public FrmNewMaze()
        {
            InitializeComponent();
        }

        public int GetWidth()
        {
            return Convert.ToInt32(txtWidth.Text);
        }

        public int GetHeight()
        {
            return Convert.ToInt32(txtHeight.Text);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string pattern = "^[1-9]*$";
            if (Regex.IsMatch(txtHeight.Text, pattern) && Regex.IsMatch(txtWidth.Text, pattern))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a number from 1-9 for the height and width of the maze", "Invalid Height and Width", MessageBoxButtons.OK);
            }
        }
    }
}
