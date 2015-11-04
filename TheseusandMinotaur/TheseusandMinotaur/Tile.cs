using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusandMinotaur
{
    public class Tile
    {
        private int row;
        private int column;
        private bool topWall;
        private bool leftWall;
        private Location location;

        public Tile(int row, int column)
        {
            this.row = row;
            this.column = column;
            this.location = new Location(row, column);
        }

        public void SetTopWall(bool topWall){
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

        public void SetSpecial(Specials s)
        {
            this.location.SetSpecial(s);
        }

        public Specials GetSpecial()
        {
            return this.location.GetSpecial();
        }

        public Location GetLocation()
        {
            return this.location;
        }
    }
}