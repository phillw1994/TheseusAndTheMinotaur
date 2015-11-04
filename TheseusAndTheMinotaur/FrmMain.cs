﻿using System;
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
        public FrmMain()
        {
            InitializeComponent();
            this.Hide();
            SplashScreen ss = new SplashScreen();
            ss.FormClosing += delegate { this.Show(); };
            ss.ShowDialog();
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
    }
}
