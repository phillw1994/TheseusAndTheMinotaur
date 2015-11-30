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
            Tile theseus, nextTile;
            int[] coords;
            switch (type)
            {
                case "Up":
                    if (this.gameLoss != true)
                    {
                        theseus = this.maze.GetTile((char)Specials.Theseus);
                        if (theseus.GetTopWall() != true)
                        {
                            coords = theseus.GetCoords();
                            nextTile = maze.GetTile(coords[0] - 1, coords[1]);
                            if (theseus != null && nextTile != null && nextTile.GetSymbol() != (char)Specials.Minotaur)
                            {
                                if (nextTile.GetSymbol() != (char)Specials.Hidden)
                                {
                                    if (nextTile.GetSymbol() == (char)Specials.Exit)
                                    {
                                        this.gameWin = true;
                                    }
                                    nextTile.SetSymbol((char)Specials.Theseus);
                                    theseus.SetSymbol((char)Specials.Floor);
                                }
                            }
                        }
                    }
                    break;
                case "Down":
                    if (this.gameLoss != true)
                    {
                        theseus = this.maze.GetTile((char)Specials.Theseus);
                        coords = theseus.GetCoords();
                        nextTile = maze.GetTile(coords[0] + 1, coords[1]);
                        if (theseus != null && nextTile != null && nextTile.GetTopWall() != true && nextTile.GetSymbol() != (char)Specials.Minotaur)
                        {
                            if (nextTile.GetSymbol() != (char)Specials.Hidden)
                            {
                                if (nextTile.GetSymbol() == (char)Specials.Exit)
                                {
                                    this.gameWin = true;
                                }
                                nextTile.SetSymbol((char)Specials.Theseus);
                                theseus.SetSymbol((char)Specials.Floor);
                            }
                        }
                    }
                    break;
                case "Left":
                    if (this.gameLoss != true)
                    {
                        theseus = this.maze.GetTile((char)Specials.Theseus);
                        coords = theseus.GetCoords();
                        nextTile = maze.GetTile(coords[0], coords[1] - 1);
                        if (theseus != null && nextTile != null && theseus.GetLeftWall() != true && nextTile.GetSymbol() != (char)Specials.Minotaur)
                        {
                            if (nextTile.GetSymbol() != (char)Specials.Hidden)
                            {
                                if (nextTile.GetSymbol() == (char)Specials.Exit)
                                {
                                    this.gameWin = true;
                                }
                                nextTile.SetSymbol((char)Specials.Theseus);
                                theseus.SetSymbol((char)Specials.Floor);
                            }
                        }
                    }
                    break;
                case "Right":
                    if (this.gameLoss != true)
                    {
                        theseus = this.maze.GetTile((char)Specials.Theseus);
                        coords = theseus.GetCoords();
                        nextTile = maze.GetTile(coords[0], coords[1] + 1);
                        if (theseus != null && nextTile != null && nextTile.GetLeftWall() != true && nextTile.GetSymbol() != (char)Specials.Minotaur)
                        {
                            if (nextTile.GetSymbol() != (char)Specials.Hidden)
                            {
                                if (nextTile.GetSymbol() == (char)Specials.Exit)
                                {
                                    this.gameWin = true;
                                }
                                nextTile.SetSymbol((char)Specials.Theseus);
                                theseus.SetSymbol((char)Specials.Floor);
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
                Tile minotaur, nextTile, theseus;
                int[] coords, theseusCoords;
                minotaur = this.maze.GetTile((char)Specials.Minotaur);
                theseus = this.maze.GetTile((char)Specials.Theseus);
                if (theseus != null && minotaur != null)
                {
                    coords = minotaur.GetCoords();
                    theseusCoords = theseus.GetCoords();
                    if (coords[1] > theseusCoords[1] && minotaur.GetLeftWall() != true)
                    {
                        //Minotaur Moves Left
                        nextTile = maze.GetTile(coords[0], coords[1] - 1);
                        if (minotaur.GetLeftWall() != true && nextTile != null && minotaur != null && theseus != null)
                        {
                            nextTile.SetSymbol((char)Specials.Minotaur);
                            minotaur.SetSymbol((char)Specials.Floor);
                        }
                    }
                    else if (coords[1] < theseusCoords[1] && maze.GetTile(coords[0], coords[1] + 1).GetLeftWall() != true)
                    {
                        //Minotaur Moves Right
                        nextTile = maze.GetTile(coords[0], coords[1] + 1);
                        if (nextTile.GetLeftWall() != true && nextTile != null && minotaur != null && theseus != null)
                        {
                            nextTile.SetSymbol((char)Specials.Minotaur);
                            minotaur.SetSymbol((char)Specials.Floor);
                        }
                    }
                    else if (coords[0] < theseusCoords[0] && maze.GetTile(coords[0] + 1, coords[1]).GetTopWall() != true)
                    {
                        //Minotaur moves down
                        nextTile = maze.GetTile(coords[0] + 1, coords[1]);
                        if (nextTile.GetTopWall() != true && nextTile != null && minotaur != null && theseus != null)
                        {
                            nextTile.SetSymbol((char)Specials.Minotaur);
                            minotaur.SetSymbol((char)Specials.Floor);
                        }
                    }
                    else if (coords[0] > theseusCoords[0] && minotaur.GetTopWall() != true)
                    {
                        //Minotaur moves up
                        nextTile = maze.GetTile(coords[0] - 1, coords[1]);
                        if (nextTile.GetTopWall() != true && nextTile.GetLeftWall() != true && nextTile != null && minotaur != null && theseus != null)
                        {
                            nextTile.SetSymbol((char)Specials.Minotaur);
                            minotaur.SetSymbol((char)Specials.Floor);
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
