using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheseusAndTheMinotaur
{
    public partial class FrmMain : Form
    {
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
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            var prior = Form.ActiveForm;
            using (var dlg = new FrmGame())
            {
                dlg.FormClosing += delegate { prior.Show(); };
                prior.Hide();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("result");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //Add Close CHeck using example code
            /*
             DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNo);
             if(result == DialogResult.Yes){
                e.Cancel = false
                new CancelEventArgs().Cancel = false;
             
              }
             else if(result == DialogResult.No){
                e.Cancel = true;
                new CancelEventArgs().Cancel = false;
             }
             */
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen ss = new SplashScreen();
            ss.FormClosing += delegate { this.Show(); };
            ss.ShowDialog();
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            var prior = Form.ActiveForm;
            using (var dlg = new FrmEditor())
            {
                dlg.FormClosing += delegate { prior.Show(); };
                prior.Hide();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("result");
                }
            }
        }
    }
}
