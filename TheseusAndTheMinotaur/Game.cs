using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheseusAndTheMinotaur.Library;
using System.Diagnostics;
using System.IO;
using System.Threading;

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
        private bool gameLoss = false;

        public Game(IView theView)
        {
            this.view = theView;
        }
        public void Go()
        {
            this.view.Start();
            this.maze = new Maze();
        }

        public void TheseusMovement(string type)
        {
            Tile tile, tile2;
            int[] coords;
            switch (type)
            {
                case "Up":
                    if (this.gameLoss != true)
                    {
                        tile = this.maze.GetTile((char)Specials.Theseus);
                        if (tile.GetTopWall() != true)
                        {
                            coords = tile.GetCoords();
                            tile2 = maze.GetTile(coords[0] - 1, coords[1]);
                            if (tile != null && tile2 != null && tile2.GetSymbol() != (char)Specials.Minotaur)
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
                    }
                    break;
                case "Down":
                    if (this.gameLoss != true)
                    {
                        tile = this.maze.GetTile((char)Specials.Theseus);
                        coords = tile.GetCoords();
                        tile2 = maze.GetTile(coords[0] + 1, coords[1]);
                        if (tile != null && tile2 != null && tile2.GetTopWall() != true && tile2.GetSymbol() != (char)Specials.Minotaur)
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
                case "Left":
                    if (this.gameLoss != true)
                    {
                        tile = this.maze.GetTile((char)Specials.Theseus);
                        coords = tile.GetCoords();
                        tile2 = maze.GetTile(coords[0], coords[1] - 1);
                        if (tile != null && tile2 != null && tile.GetLeftWall() != true && tile2.GetSymbol() != (char)Specials.Minotaur)
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
                case "Right":
                    if (this.gameLoss != true)
                    {
                        tile = this.maze.GetTile((char)Specials.Theseus);
                        coords = tile.GetCoords();
                        tile2 = maze.GetTile(coords[0], coords[1] + 1);
                        if (tile != null && tile2 != null && tile2.GetLeftWall() != true && tile2.GetSymbol() != (char)Specials.Minotaur)
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
            }
        }


        public void MinotaurMovement(string type)
        {
            if (this.gameLoss != true)
            {
                Tile tile, tile2, theseus;
                int[] coords, theseusCoords;

                //Figure out Theseus Coords

                tile = this.maze.GetTile((char)Specials.Minotaur);
                theseus = this.maze.GetTile((char)Specials.Theseus);
                if (theseus != null && tile != null)
                {
                    coords = tile.GetCoords();
                    theseusCoords = theseus.GetCoords();
                    //Figures out if theseus moved left
                    if (coords[1] > theseusCoords[1] && tile.GetLeftWall() != true)
                    {
                        //Check nextTile not null, wall, hidden etc.
                        //Minotaur moves left
                        Debug.WriteLine("Minotuar Moves Left");
                        tile2 = maze.GetTile(coords[0], coords[1] - 1);
                        if (tile.GetLeftWall() != true && tile2 != null && tile != null && theseus != null)
                        {
                            tile2.SetSymbol((char)Specials.Minotaur);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    else if (coords[1] < theseusCoords[1] && maze.GetTile(coords[0], coords[1] + 1).GetLeftWall() != true)
                    {
                        //Check nextTile not null, wall, hidden etc.
                        //Minotaur moves right
                        Debug.WriteLine("Minotuar Moves Right");
                        tile2 = maze.GetTile(coords[0], coords[1] + 1);
                        if (tile2.GetLeftWall() != true && tile2 != null && tile != null && theseus != null)
                        {
                            tile2.SetSymbol((char)Specials.Minotaur);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    else if (coords[0] < theseusCoords[0] && maze.GetTile(coords[0] + 1, coords[1]).GetTopWall() != true)
                    {
                        //Check nextTile not null, wall, hidden etc.
                        //Minotaur moves up
                        Debug.WriteLine("Minotuar Moves Down");
                        tile2 = maze.GetTile(coords[0] + 1, coords[1]);
                        if (tile2.GetTopWall() != true && tile2 != null && tile != null && theseus != null)
                        {
                            tile2.SetSymbol((char)Specials.Minotaur);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    else if (coords[0] > theseusCoords[0] && tile.GetTopWall() != true)
                    {
                        //Check nextTile not null, wall, hidden etc.
                        //Minotaur moves down
                        Debug.WriteLine("Minotuar Moves Up");
                        tile2 = maze.GetTile(coords[0] - 1, coords[1]);
                        if (tile2.GetTopWall() != true && tile2.GetLeftWall() != true && tile2 != null && tile != null && theseus != null)
                        {
                            tile2.SetSymbol((char)Specials.Minotaur);
                            tile.SetSymbol((char)Specials.Floor);
                        }
                    }
                    if ((Tile)this.maze.GetTile((char)Specials.Theseus) == null)
                    {
                        this.gameLoss = true;
                    }
                    view.PanelRefresh();
                }
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

        public bool GetGameLoss()
        {
            return this.gameLoss;
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
