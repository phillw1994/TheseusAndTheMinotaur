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
            cv.Say(mapString2);
            this.maze.CreateMap(1,0);
            cv.Get();
        }
    }
}