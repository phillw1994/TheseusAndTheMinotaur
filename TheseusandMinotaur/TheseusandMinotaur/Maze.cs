using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace TheseusAndMinotaurGameLibrary
{
    public class Maze
    {
        private List<Tile> tiles = new List<Tile>();
        private int height;
        private int width;
        private string name;
        private int locationIndex = 0;

        /// <summary>
        /// Creates a map from a Map String
        /// </summary>
        /// <param name="mapString"></param>
        public void LoadMap(string mapString)
        {
            int row = 0;
            int column = 0;
            /*string map =
            ".___.___.___." + "\n" +
            "|     M     |" + "\n" +
            ".   .___.   .___." + "\n" +
            "|       |     X  " + "\n" +
            ".   .___.   .___." + "\n" +
            "|     T     |" + "\n" +
            ".___.___.___.";*/

            string[] currentMap = mapString.Split('\n');
            int realRow = 0;

            while (row <= currentMap.Length - 1)
            {
                //Check First Row
                column = 0;
                Tile tile;
                for (int i = 0; i < currentMap[row].Length - 1; i += 4)
                {
                    if (currentMap[row].Substring(i, 5) == ".___.")
                    {
                        tile = new Tile(realRow, column);
                        tile.SetTopWall(true);
                        tiles.Add(tile);
                        column += 1;
                    }
                    if (currentMap[row].Substring(i, 5) == ".   .")
                    {
                        tile = new Tile(realRow, column);
                        tile.SetTopWall(false);
                        tiles.Add(tile);
                        column += 1;
                    }
                }
                tile = new Tile(realRow, column);
                tiles.Add(tile);
                row += 1;

                if (row == currentMap.Length)
                {
                    break;
                }

                //Check Second Row
                column = 0;

                for (int i = 0; i < currentMap[row].Length - 1; i += 4)
                {
                    if (currentMap[row].Substring(i, 5).Contains('|') && currentMap[row].Substring(i, 5).IndexOf('|') == 0)
                    {
                        tile = this.GetTile(realRow, column);
                        tile.SetLeftWall(true);
                        tile.SetSymbol((char)Specials.Floor);
                        column += 1;
                    }
                    else if (currentMap[row].Substring(i, 5).Contains('|') && currentMap[row].Substring(i, 5).IndexOf('|') == 4)
                    {
                        tile = this.GetTile(realRow, column + 1);
                        tile.SetLeftWall(true);
                        tile.SetSymbol((char)Specials.Floor);
                        column += 1;
                    }
                    else if (currentMap[row].Substring(i, 5).Contains('M'))
                    {
                        tile = this.GetTile(realRow, column);
                        tile.SetSymbol((char)Specials.Minotaur);
                        column += 1;
                    }
                    else if (currentMap[row].Substring(i, 5).Contains('T'))
                    {
                        tile = this.GetTile(realRow, column);
                        tile.SetSymbol((char)Specials.Theseus);
                        column += 1;
                    }
                    else if (currentMap[row].Substring(i, 5).Contains('X'))
                    {
                        tile = this.GetTile(realRow, column);
                        tile.SetSymbol((char)Specials.Exit);
                        column += 1;
                    }
                    else
                    {
                        tile = this.GetTile(realRow, column);
                        tile.SetSymbol((char)Specials.Floor);
                        column += 1;
                    }
                }
                realRow += 1;
                row += 1;
            }
            this.SetMapDimensions();
        }

        public bool ValidateMapString(string mapString)
        {
            bool result = false;
            string pattern = "/[.|_XMT]/g";
            if (Regex.IsMatch(mapString, pattern))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public void SetMapDimensions()
        {
            int width = 0;
            int height = 0;

            foreach (Tile t in tiles)
            {
                if (t.GetCoords()[0] >= height)
                {
                    height = t.GetCoords()[0];
                }
                if (t.GetCoords()[1] >= width)
                {
                    width = t.GetCoords()[1];
                }
            }
            this.width = width;
            this.height = height;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.height;
        }

        public Tile GetTile(int row, int column)
        {
            Tile tile = null;
            foreach (Tile t in tiles)
            {
                int[] coords = t.GetCoords();
                if (coords[0] == row && coords[1] == column)
                {
                    tile = t;
                }
            }
            return tile;
        }
    }
}
