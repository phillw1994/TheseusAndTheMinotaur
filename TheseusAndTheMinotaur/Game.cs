using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheseusAndMinotaurGameLibrary;
using System.Diagnostics;
using System.IO;

namespace TheseusAndTheMinotaur
{
    class Game
    {
        IView view;
        Maze maze;
        int width;
        int height;
        List<Tile> tiles;

        public Game(IView theView)
        {
            this.view = theView;
        }
        public void Go()
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
                if (t.GetSymbol() == '\0')
                {
                    t.SetSymbol((char)Specials.Hidden);
                }
            }
            this.height = this.maze.GetHeight();
            this.width = this.maze.GetWidth();
            this.view.Start();
        }

        public void Movement(string type)
        {
            Tile tile, tile2;
            int[] coords;

            switch (type)
            {
                case "Up":
                    File.AppendAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log.txt", "Started Movement Code");
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    File.AppendAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log.txt", "Set Tile");
                    coords = tile.GetCoords();
                    File.AppendAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log.txt", "Got Tile Coords");
                    tile2 = maze.GetTile(coords[0] - 1, coords[1]);
                    File.AppendAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log.txt", "Set Tile 2");
                    if (tile != null && tile2 != null)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            tile2.SetSymbol((char)Specials.Theseus);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    break;
                case "Down":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    coords = tile.GetCoords();
                    tile2 = maze.GetTile(coords[0] + 1, coords[1]);
                    if (tile != null && tile2 != null)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            tile2.SetSymbol((char)Specials.Theseus);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    break;
                case "Left":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    coords = tile.GetCoords();
                    tile2 = maze.GetTile(coords[0], coords[1] - 1);
                    if (tile != null && tile2 != null)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            tile2.SetSymbol((char)Specials.Theseus);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    break;
                case "Right":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    coords = tile.GetCoords();
                    tile2 = maze.GetTile(coords[0], coords[1] + 1);
                    if (tile != null && tile2 != null)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            tile2.SetSymbol((char)Specials.Theseus);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    break;
            }
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.width;
        }

        public Tile GetTile(int row, int column)
        {
            return this.maze.GetTile(row, column);
        }

    }
}
