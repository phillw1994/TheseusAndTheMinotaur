﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusAndMinotaurLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            new Controller(new CView()).Go();
        }
    }
}
