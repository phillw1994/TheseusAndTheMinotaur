using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusandMinotaur
{
    public enum Specials
    {
        Theseus,
        Minotaur,
        Exit
    };
    
    public class Location
    {
        Specials description;
        int row;
        int column;

        public Location(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public void SetSpecial(Specials s)
        {
            this.description = s;
        }

        public Specials GetSpecial()
        {
            return this.description;
        }
    }
}
