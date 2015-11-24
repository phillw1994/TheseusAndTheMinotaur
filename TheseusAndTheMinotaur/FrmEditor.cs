using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TheseusAndTheMinotaur.Library;

namespace TheseusAndTheMinotaur
{
    public partial class FrmEditor : Form, IView
    {
        int sizeX;
        int sizeY;
        int squareSize;
        Editor editor;
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

        public FrmEditor()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            //Pen p;
            this.sizeX = this.editor.GetWidth();
            this.sizeY = this.editor.GetHeight();
            this.squareSize = 50;

            if (this.sizeX > 0 && this.sizeY > 0)
            {
                int squareSize = this.squareSize;
                int amountOfSquaresX = this.sizeX;
                int amountOfSquaresY = this.sizeY;
                int gridHeight = amountOfSquaresY * squareSize;
                int gridWidth = amountOfSquaresX * squareSize;

                int columnTop = (this.panel1.Height - gridHeight) / 2;
                int columnBottom = this.panel1.Height - columnTop;
                int columnLeft = (this.panel1.Width - gridWidth) / 2;
                int columnRight = this.panel1.Width - columnLeft;

                int column = 0;
                int row = 0;
                int rectStartLeft = columnLeft;
                int rectEndRight = rectStartLeft;
                int rectStartTop = columnTop;
                int rectEndBottom = rectStartTop;

                while (row <= amountOfSquaresY-1)
                {
                    rectEndBottom += squareSize;
                    rectEndRight += squareSize;
                    while (column <= amountOfSquaresX-1)
                    {
                        /*Tile tile = this.game.GetTile(row, column);
                        if (tile != null) {
                            if (tile.GetLeftWall() == true)
                            {
                                p = new Pen(Color.Black);
                                g.DrawLine(p, rectStartLeft, rectStartTop, rectStartLeft, rectEndBottom);
                            }
                            if (tile.GetTopWall() == true)
                            {
                                p = new Pen(Color.Black);
                                g.DrawLine(p, rectStartLeft, rectStartTop, rectEndRight, rectStartTop);
                            }*/
                            checkChar('-', g, rectStartLeft, rectEndRight, rectEndBottom, rectStartTop);
                            rectStartLeft = rectEndRight;
                            rectEndRight += squareSize;
                        //}
                        column += 1;
                    }
                    rectStartTop = rectEndBottom;
                    rectStartLeft = columnLeft;
                    rectEndRight = columnLeft;
                    column = 0;
                    row += 1;
                }
            }
        }

        public void checkChar(char character, Graphics g, int left, int right, int bottom, int top)
        {
            Pen p;
            SolidBrush sb, sb2;
            switch (character)
            {
                case 'M':
                    p = new Pen(Color.Red);
                    sb = new SolidBrush(Color.LightGray);
                    sb2 = new SolidBrush(Color.Red);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    g.DrawEllipse(p, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    g.FillEllipse(sb2, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    break;
                case 'T':
                    p = new Pen(Color.Lime);
                    sb = new SolidBrush(Color.LightGray);
                    sb2 = new SolidBrush(Color.Lime);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    g.DrawEllipse(p, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    g.FillEllipse(sb2, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    break;
                case 'X':
                    sb = new SolidBrush(Color.LightGray);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    break;
                case '-':
                    sb = new SolidBrush(Color.LightGray);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    break;
                case 'H':
                    break;
            }
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            this.editor = new Editor(this);
            this.sizeX = 0;
            this.sizeY = 0;
            this.squareSize = 0;
            this.editor.Go();
        }

        public void Start()
        {
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Visible = true;
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Editor\nWelcome to the game editor this is under construction", "Help", MessageBoxButtons.OK);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.editor = new Editor(this);
            FrmNewMaze frmNewMaze = new FrmNewMaze();
            frmNewMaze.FormClosing += delegate {  this.editor.SetWidth(frmNewMaze.GetWidth()); this.editor.SetHeight(frmNewMaze.GetHeight()); };
            frmNewMaze.ShowDialog();
            //this.editor.Go();
            panel1.Invalidate();
        }
    }
}
