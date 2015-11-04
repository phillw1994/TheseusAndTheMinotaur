using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusAndMinotaurGameLibrary
{
    class Controller
    {
        private CView cv;
        private Maze maze;

        public Controller(CView cv)
        {
            this.cv = cv;
            this.maze = new Maze();
        }

        public void Go()
        {
            cv.Say("Theseus and Minotaur Game");
            cv.Say("----------------------------");
            //cv.Say("Please Enter a MapString");
            //this.CreateMap(5, 3, "");

            string map =
            ".___.___.___." + "\n" +
            "|     M     |" + "\n" +
            ".   .___.   .___." + "\n" +
            "|       |     X  " + "\n" +
            ".   .___.   .___." + "\n" +
            "|     T     |" + "\n" +
            ".___.___.___.";


            Maze maze = new Maze();
            maze.LoadMap(map);
            

            Console.WriteLine("Maze Width: " + maze.GetWidth());
            Console.WriteLine("Maze Height: " + maze.GetHeight());

            List<Tile> tiles = maze.GetTiles();

            int count = 0;
            foreach (Tile t in tiles)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Tile " + count + " [" + t.GetCoords()[0] + "," + t.GetCoords()[1] + "]");
                Console.WriteLine("Top Wall " + t.GetTopWall());
                Console.WriteLine("Left Wall " + t.GetLeftWall());
                Console.WriteLine("Symbol " + t.GetSymbol());
                count += 1;
            }
            Console.ReadKey();
        }
    }
}