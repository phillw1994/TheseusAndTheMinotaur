using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusAndTheMinotaur.Library
{
    public class Tile
    {
        private int row;
        private int column;
        private bool topWall;
        private bool leftWall;
        private char symbol;

        public Tile(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public void SetTopWall(bool topWall)
        {
            this.topWall = topWall;
        }

        public bool GetTopWall()
        {
            return this.topWall;
        }

        public void SetLeftWall(bool leftWall)
        {
            this.leftWall = leftWall;
        }

        public bool GetLeftWall()
        {
            return this.leftWall;
        }

        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
        }

        public char GetSymbol()
        {
            return this.symbol;
        }

        public int[] GetCoords()
        {
            return new int[] { row, column };
        }
    }
}
