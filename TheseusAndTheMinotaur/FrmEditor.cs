using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TheseusAndTheMinotaur.Library;
using System.Diagnostics;

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
            panel1.Click += new System.EventHandler(this.panel_Click);

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
                this.panel1.Size = new System.Drawing.Size(gridWidth, gridHeight);
                int column = 0;
                int row = 0;
                int rectStartLeft = 0;
                int rectEndRight = rectStartLeft;
                int rectStartTop = 0;
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
                    rectStartLeft = 0;
                    rectEndRight = 0;
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
            this.btnHorizontalWall.Enabled = true;
            this.btnVerticalWall.Enabled = true;
            this.btnTheseus.Enabled = true;
            this.btnMinotaur.Enabled = true;
            this.btnExit.Enabled = true;
            panel1.Invalidate();
        }

        public void PanelRefresh()
        {
            panel1.Invalidate();
        }

        private void btnHorizontalWall_Click(object sender, EventArgs e)
        {
            this.btnHorizontalWall.Enabled = false;
            this.btnVerticalWall.Enabled = true;
            this.btnTheseus.Enabled = true;
            this.btnMinotaur.Enabled = true;
            this.btnExit.Enabled = true;
            this.btnCursor.Enabled = true;
        }

        private void btnVerticalWall_Click(object sender, EventArgs e)
        {
            this.btnHorizontalWall.Enabled = true;
            this.btnVerticalWall.Enabled = false;
            this.btnTheseus.Enabled = true;
            this.btnMinotaur.Enabled = true;
            this.btnExit.Enabled = true;
            this.btnCursor.Enabled = true;
        }

        private void btnTheseus_Click(object sender, EventArgs e)
        {
            this.btnHorizontalWall.Enabled = true;
            this.btnVerticalWall.Enabled = true;
            this.btnTheseus.Enabled = false;
            this.btnMinotaur.Enabled = true;
            this.btnExit.Enabled = true;
            this.btnCursor.Enabled = true;
        }

        private void btnMinotaur_Click(object sender, EventArgs e)
        {
            this.btnHorizontalWall.Enabled = true;
            this.btnVerticalWall.Enabled = true;
            this.btnTheseus.Enabled = true;
            this.btnMinotaur.Enabled = false;
            this.btnExit.Enabled = true;
            this.btnCursor.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.btnHorizontalWall.Enabled = true;
            this.btnVerticalWall.Enabled = true;
            this.btnTheseus.Enabled = true;
            this.btnMinotaur.Enabled = true;
            this.btnExit.Enabled = false;
            this.btnCursor.Enabled = true;
        }

        private void btnCursor_Click(object sender, EventArgs e)
        {
            this.btnHorizontalWall.Enabled = true;
            this.btnVerticalWall.Enabled = true;
            this.btnTheseus.Enabled = true;
            this.btnMinotaur.Enabled = true;
            this.btnExit.Enabled = true;
            this.btnCursor.Enabled = false;
        }

        private void panel_Click(object sender, EventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);
            int i = 0;
            int amountSquaresX = 0;
            while (i <= point.X)
            {
                if (i != 0)
                {
                    amountSquaresX += 1;
                }
                i += this.squareSize;
            }
            i = 0;
            int amountSquaresY = 0;
            while (i <= point.Y)
            {
                if (i != 0)
                {
                    amountSquaresY += 1;
                }
                i += this.squareSize;
            }

            //Needs to get currently selected tile to deselect it if needed
            //Draw the currently selected tile and others
            MessageBox.Show(point.ToString());
            Debug.WriteLine("Amount Squares X: " + amountSquaresX);
            Debug.WriteLine("Amount Squares Y: " + amountSquaresY);
        }
    }
}
