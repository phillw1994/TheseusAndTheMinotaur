using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace TheseusAndMinotaurLibrary
{
    public class Maze
    {
        private Tile[][] allTiles;
        private int height;
        private int width;
        private string name;
        private int locationIndex = 0;

        /// <summary>
        /// Creates a map from a Map String
        /// </summary>
        /// <param name="mapString"></param>
        public void CreateMap(string mapString)
        {
            //Gets height and width from map string and sets it
            int length = mapString.Length;
            string[] map = mapString.Split('\n');
            string pattern = "/[.|_XMT]/g";
            string mapString2 = "    .   .\n"
                            + "    | X |\n"
                            + ".___.   .___.___.___.___.\n"
                            + "|                   |   |\n"
                            + ".   .___.   .   .___.   .\n"
                            + "|           |           |\n"
                            + ".   .   .   .   .___.   .\n"
                            + "|           |       |   |\n"
                            + ".   .   .   .   .   .   .\n"
                            + "|   |           |   |   |\n"
                            + ".___.   .   .   .___.   .\n"
                            + "| M               T |   |\n"
                            + ".   .   .___.   .   .   .\n"
                            + "|                       |\n"
                            + ".___.___.___.___.___.___.";

    
            if (Regex.IsMatch(mapString2, pattern))
            {
                //instantiate the tile class to create a tile
                //Tile tile = new Tile();
            }
            else{
                //throw new InvalidMapStringException();
                Console.WriteLine("Invalid Map");
            }
            
        }

        /// <summary>
        /// Enter the width and height for the grid in squares
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void CreateMap(int width, int height)
        {
            this.allTiles = new Tile[height][];
            this.width = width;
            this.height = height;
            int column = 0;
            int row = 0;
            while (row <= height-1){
                this.allTiles[row] = new Tile[width];
                column = 0;
                while (column <= width-1){
                    
                    this.AddSpecial(row, column, '~');
                    column += 1;
                }
                row += 1;
            }
        }

        /*public bool ValidateMapString(string mapString)
        {
            //Needs Implementing
            return true;
        }*/

        public void AddSpecial(int row, int column, char type)
        {
            Tile tile = new Tile(row, column);
            if (type == 'T')
            {
                Location l = tile.GetLocation();
                l.SetSpecial(Specials.Theseus);
                allLocations[this.locationIndex] = l;
                this.locationIndex += 1;
            }
            else if (type == 'M')
            {
                Location l = tile.GetLocation();
                l.SetSpecial(Specials.Minotaur);
                allLocations[this.locationIndex] = l;
                this.locationIndex += 1;
            }
            else if (type == 'X')
            {
                Location l = tile.GetLocation();
                l.SetSpecial(Specials.Exit);
                allLocations[this.locationIndex] = l;
                this.locationIndex += 1;
            }
            this.allTiles[row][column] = tile;
        }

        /*public void LoadMap()
        {

        }

        public string ExtractMap()
        {
            return "";
        }*/

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public int GetHeight()
        {
            return this.height;
        }
    }
}
