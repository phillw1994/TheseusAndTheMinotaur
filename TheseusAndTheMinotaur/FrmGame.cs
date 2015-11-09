using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheseusAndMinotaurGameLibrary;

namespace TheseusAndTheMinotaur
{
    public partial class FrmGame : Form, IView
    {
        private int sizeX;
        private int sizeY;
        private int squareSize;
        private Game game;
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

        public FrmGame()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p;
            this.sizeX = this.game.GetWidth();
            this.sizeY = this.game.GetHeight();
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

                while (row <= amountOfSquaresY)
                {
                    rectEndBottom += squareSize;
                    rectEndRight += squareSize;
                    while (column <= amountOfSquaresX-1)
                    {
                        Tile tile = this.game.GetTile(row, column);
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
                            }
                            checkChar(tile.GetSymbol(), g, rectStartLeft, rectEndRight, rectEndBottom, rectStartTop);
                            rectStartLeft = rectEndRight;
                            rectEndRight += squareSize;
                        }
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
            this.game = new Game(this);
            this.game.Go();
        }

        public void Start()
        {
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Visible = true;
        }


        private void FrmGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (game.GetGameWin() != true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    this.game.Movement("Up");
                    panel1.Invalidate();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    this.game.Movement("Left");
                    panel1.Invalidate();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    this.game.Movement("Right");
                    panel1.Invalidate();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    this.game.Movement("Down");
                    panel1.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Well done you have completed the maze", "Winner!!!", MessageBoxButtons.OK);
            }
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This App uses the keyboard Up, Down, Left, Right buttons to move Theseus around the maze", "Help", MessageBoxButtons.OK);
        }
    }
}
