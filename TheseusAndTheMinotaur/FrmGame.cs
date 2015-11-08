using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheseusAndMinotaurGameLibrary;
using System.Diagnostics;

namespace TheseusAndTheMinotaur
{
    public partial class FrmGame : Form
    {
        private int sizeX;
        private int sizeY;
        private int squareSize;
        private bool fileOpened;
        private List<Tile> tiles;
        private Maze maze;

        public FrmGame()
        {
            InitializeComponent();
            //this.fileOpened = false;
            //toolStripStatusLabel1.Text = "Ready";
            //this.Height = 550;
            //this.Width = 630;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p;
            SolidBrush sb;
            this.sizeX = this.maze.GetWidth();
            this.sizeY = this.maze.GetHeight();
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
                        Tile tile = this.maze.GetTile(row, column);

                        if(tile.GetLeftWall() == true)
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
                    //g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    g.DrawEllipse(p, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    g.FillEllipse(sb2, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    break;
                case 'T':
                    p = new Pen(Color.Lime);
                    sb = new SolidBrush(Color.LightGray);
                    sb2 = new SolidBrush(Color.Lime);
                    //g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    g.DrawEllipse(p, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    g.FillEllipse(sb2, left + 5, top + 5, this.squareSize - 10, this.squareSize - 10);
                    break;
                case 'X':
                    //p = new Pen(Color.Black);
                    sb = new SolidBrush(Color.LightGray);
                    //g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    break;
                case '-':
                    //p = new Pen(Color.Black);
                    sb = new SolidBrush(Color.LightGray);
                    //g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    break;
                case 'H':
                    break;
            }
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            string map =
            ".___.___.___." + "\n" +
            "|     M     |" + "\n" +
            ".   .___.   .___." + "\n" +
            "|       |     X  " + "\n" +
            ".   .___.   .___." + "\n" +
            "|     T     |" + "\n" +
            ".___.___.___.";

            this.maze = new Maze();
            this.maze.LoadMap(map);
            this.tiles = this.maze.GetTiles();
            foreach (Tile t in this.tiles)
            {
                if(t.GetSymbol() == '\0')
                {
                    t.SetSymbol((char)Specials.Hidden);
                }
            }
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Visible = true;
        }

        private void FrmGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Tile tile = this.maze.GetTile((char)Specials.Theseus);
                int[] coords = tile.GetCoords();
                Tile tile2 = maze.GetTile(coords[0] - 1, coords[1]);
                if (tile != null && tile2 != null)
                {
                    if (tile2.GetSymbol() != (char)Specials.Hidden)
                    {
                        tile2.SetSymbol((char)Specials.Theseus);
                        tile.SetSymbol((char)Specials.Floor);
                        panel1.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                Tile tile = this.maze.GetTile((char)Specials.Theseus);
                int[] coords = tile.GetCoords();
                Tile tile2 = maze.GetTile(coords[0], coords[1] - 1);
                if (tile != null && tile2 != null)
                {
                    if (tile2.GetSymbol() != (char)Specials.Hidden)
                    {
                        tile2.SetSymbol((char)Specials.Theseus);
                        tile.SetSymbol((char)Specials.Floor);
                        panel1.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                Tile tile = this.maze.GetTile((char)Specials.Theseus);
                int[] coords = tile.GetCoords();
                Tile tile2 = maze.GetTile(coords[0], coords[1] + 1);
                if (tile != null && tile2 != null)
                {
                    if (tile2.GetSymbol() != (char)Specials.Hidden)
                    {
                        tile2.SetSymbol((char)Specials.Theseus);
                        tile.SetSymbol((char)Specials.Floor);
                        panel1.Invalidate();
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                Tile tile = this.maze.GetTile((char)Specials.Theseus);
                int[] coords = tile.GetCoords();
                Tile tile2 = maze.GetTile(coords[0] + 1, coords[1]);
                if (tile != null && tile2 != null)
                {
                    if (tile2.GetSymbol() != (char)Specials.Hidden)
                    {
                        tile2.SetSymbol((char)Specials.Theseus);
                        tile.SetSymbol((char)Specials.Floor);
                        panel1.Invalidate();
                    }
                }
            }
        }
    }
}
