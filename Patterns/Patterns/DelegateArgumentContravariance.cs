using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public delegate void StringAction(string s);

    class DelegateArgumentContravariance
    {
        static void ActOnObject(Object o) => Console.WriteLine(o);

#if false
        static void Main()
        {
            StringAction sa = new StringAction(ActOnObject);
            sa.Invoke("You have to use string here, not object");
        }
#endif
    }
}
