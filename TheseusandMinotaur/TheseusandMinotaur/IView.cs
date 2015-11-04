using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusandMinotaur
{
    interface IView
    {
        void Say<T>(T message);
        string Get();
    }
}
