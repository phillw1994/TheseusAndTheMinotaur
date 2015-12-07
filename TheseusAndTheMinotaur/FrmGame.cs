using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheseusAndTheMinotaur.Library;
using System.IO;

namespace TheseusAndTheMinotaur
{
    public partial class FrmGame : Form, IView
    {
        private int sizeX;
        private int sizeY;
        private int squareSize;
        private Game game;
        private Filer filer;
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
            if (e.KeyCode != Keys.Enter) {
                if (game.GetGameWin() != true && game.GetGameLoss() != true)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        this.game.TheseusMovement("Up");
                        panel1.Invalidate();
                        this.game.MinotaurMovement("Up");
                        Timer timer2 = new Timer();
                        timer2.Interval = 800;
                        timer2.Tick += new EventHandler(MinotaurMove);
                        timer2.Enabled = true;
                        timer2.Start();
                    }
                    else if (e.KeyCode == Keys.Left)
                    {
                        this.game.TheseusMovement("Left");
                        panel1.Invalidate();
                        this.game.MinotaurMovement("Left");
                        Timer timer2 = new Timer();
                        timer2.Interval = 800;
                        timer2.Tick += new EventHandler(MinotaurMove);
                        timer2.Enabled = true;
                        timer2.Start();
                    }
                    else if (e.KeyCode == Keys.Right)
                    {
                        this.game.TheseusMovement("Right");
                        panel1.Invalidate();
                        this.game.MinotaurMovement("Right");
                        Timer timer2 = new Timer();
                        timer2.Interval = 800;
                        timer2.Tick += new EventHandler(MinotaurMove);
                        timer2.Enabled = true;
                        timer2.Start();
                        
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        this.game.TheseusMovement("Down");
                        panel1.Invalidate();
                        this.game.MinotaurMovement("Down");
                        Timer timer2 = new Timer();
                        timer2.Interval = 800;
                        timer2.Tick += new EventHandler(MinotaurMove);
                        timer2.Enabled = true;
                        timer2.Start();

                    }
                }
                else if(game.GetGameWin() == true)
                {
                    MessageBox.Show("Well done you have completed the maze", "Winner!!!", MessageBoxButtons.OK);
                }
                else if (game.GetGameLoss() == true)
                {
                    MessageBox.Show("You have failed to complete the maze. The Minotaur caught you\n\nPlease restart the level to continue", "You have failed!!!", MessageBoxButtons.OK);
                }
        }
        }


        private void MinotaurMove(object source, EventArgs e)
        {
            this.game.MinotaurMovement("Up");
            Timer timer = (Timer)source;
            timer.Stop();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This App uses the keyboard Up, Down, Left, Right buttons to move Theseus around the maze", "Help", MessageBoxButtons.OK);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            this.game = new Game(this);
            this.game.Go();
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
                        this.game.LoadMap(filelines);
                        this.panel1.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public void PanelRefresh()
        {
            panel1.Invalidate();
        }
    }
}
