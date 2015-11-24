using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusAndTheMinotaur.Library
{
    public class Editor
    {
        private int width = 0;
        private int height = 0;
        private IView view;


        public Editor(IView theView)
        {
            this.view = theView;
        }

        public void Go()
        {
            this.view.Start();
            //this.maze = new Maze();
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public int GetHeight()
        {
            return this.height;
        }
    }
}
