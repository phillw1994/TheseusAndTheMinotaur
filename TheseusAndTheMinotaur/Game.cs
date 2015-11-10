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
        private IView view;
        private Maze maze;
        private int width;
        private int height;
        private List<Tile> tiles;
        private bool gameWin = false;

        public Game(IView theView)
        {
            this.view = theView;
        }
        public void Go()
        {
            this.view.Start();
            this.maze = new Maze();
        }

        public void Movement(string type)
        {
            Tile tile, tile2;
            int[] coords;
            switch (type)
            {
                case "Up":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    if (tile.GetTopWall() != true) {
                        coords = tile.GetCoords();
                        tile2 = maze.GetTile(coords[0] - 1, coords[1]);
                        if (tile != null && tile2 != null)
                        {
                            if (tile2.GetSymbol() != (char)Specials.Hidden)
                            {
                                if (tile2.GetSymbol() == (char)Specials.Exit)
                                {
                                    this.gameWin = true;
                                }
                                tile2.SetSymbol((char)Specials.Theseus);
                                tile.SetSymbol((char)Specials.Floor);
                            }
                        }
                    }
                    break;
                case "Down":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    coords = tile.GetCoords();
                    tile2 = maze.GetTile(coords[0] + 1, coords[1]);
                    if (tile != null && tile2 != null && tile2.GetTopWall() != true)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            if (tile2.GetSymbol() == (char)Specials.Exit)
                            {
                                this.gameWin = true;
                            }
                            tile2.SetSymbol((char)Specials.Theseus);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    break;
                case "Left":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    coords = tile.GetCoords();
                    tile2 = maze.GetTile(coords[0], coords[1] - 1);
                    if (tile != null && tile2 != null && tile.GetLeftWall() != true)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            if (tile2.GetSymbol() == (char)Specials.Exit)
                            {
                                this.gameWin = true;
                            }
                            tile2.SetSymbol((char)Specials.Theseus);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    break;
                case "Right":
                    tile = this.maze.GetTile((char)Specials.Theseus);
                    coords = tile.GetCoords();
                    tile2 = maze.GetTile(coords[0], coords[1] + 1);
                    if (tile != null && tile2 != null && tile2.GetLeftWall() != true)
                    {
                        if (tile2.GetSymbol() != (char)Specials.Hidden)
                        {
                            if (tile2.GetSymbol() == (char)Specials.Exit)
                            {
                                this.gameWin = true;
                            }
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

        public bool GetGameWin()
        {
            return this.gameWin;
        }

        public void LoadMap(string[] mapString)
        {
            this.maze.LoadMap(mapString);
            tiles = this.maze.GetTiles();
            foreach (Tile t in this.tiles)
            {
                if (t.GetSymbol() == '\0')
                {
                    t.SetSymbol((char)Specials.Hidden);
                }
            }
            this.height = this.maze.GetHeight();
            this.width = this.maze.GetWidth();
        }

    }
}
