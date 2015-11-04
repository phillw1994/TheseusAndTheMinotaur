using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusandMinotaur
{
    class CView : IView
    {
        public void Say<T>(T message)
        {
            Console.WriteLine(message);
        }

        public string Get()
        {
            return Console.ReadLine();
        }
    }
}
