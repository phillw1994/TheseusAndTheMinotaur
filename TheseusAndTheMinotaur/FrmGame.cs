using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheseusAndTheMinotaur
{
    public partial class FrmGame : Form
    {
        public int sizeX;
        public int sizeY;
        public int squareSize;
        public bool fileOpened;

        public FrmGame()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Visible = true;
            //this.fileOpened = false;
            //toolStripStatusLabel1.Text = "Ready";
            //this.Height = 550;
            //this.Width = 630;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            this.sizeX = 5;
            this.sizeY = 5;
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
                int row = 1;
                int x = 0;
                int y = 0;
                int rectStartLeft = columnLeft;
                int rectEndRight = rectStartLeft;
                int rectStartTop = columnTop;
                int rectEndBottom = rectStartTop;

                while (row <= amountOfSquaresY)
                {
                    rectEndBottom += squareSize;
                    rectEndRight += squareSize;
                    while (column <= amountOfSquaresX - 1)
                    {
                        checkChar('-', g, rectStartLeft, rectEndRight, rectEndBottom, rectStartTop);
                        rectStartLeft = rectEndRight;
                        rectEndRight += squareSize;
                        column += 1;
                        x += 1;
                    }
                    rectStartTop = rectEndBottom;
                    rectStartLeft = columnLeft;
                    rectEndRight = columnLeft;
                    column = 0;
                    x = 0;
                    row += 1;
                    y += 1;
                }
            }
        }

        public void checkChar(char character, Graphics g, int left, int right, int bottom, int top)
        {
            Pen p;
            SolidBrush sb;
            switch (character)
            {
                case '#':
                    p = new Pen(Color.Black);
                    sb = new SolidBrush(Color.Black);
                    g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left, top, this.squareSize, this.squareSize);
                    break;
                case '@':
                    p = new Pen(Color.Black);
                    sb = new SolidBrush(Color.Yellow);
                    g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillEllipse(sb, left + 2, top + 2, this.squareSize - 4, this.squareSize - 4);
                    break;
                case '$':
                    p = new Pen(Color.Black);
                    sb = new SolidBrush(Color.LightGreen);
                    g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 4, top + 4, this.squareSize - 6, this.squareSize - 6);

                    break;
                case '.':
                    p = new Pen(Color.Red);
                    sb = new SolidBrush(Color.Red);
                    g.DrawLine(p, left + 4, top + 4, right - 4, bottom - 4);
                    g.DrawLine(p, right - 4, top + 4, left + 4, bottom - 4);
                    break;
                case '-':
                    p = new Pen(Color.Black);
                    sb = new SolidBrush(Color.LightGray);
                    g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    break;
                case ' ':
                    p = new Pen(Color.White);
                    sb = new SolidBrush(Color.White);
                    g.DrawRectangle(p, left, top, this.squareSize, this.squareSize);
                    g.FillRectangle(sb, left + 1, top + 1, this.squareSize - 1, this.squareSize - 1);
                    break;
            }
        }
    }
}
