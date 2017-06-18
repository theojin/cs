using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    delegate object ObjectRetriever();

    class DelegateReturnCovariance
    {
#if false
        static void Main()
        {
            ObjectRetriever o = new ObjectRetriever(RetrieveString);
            object result = o();
            Console.WriteLine(result);
        }
#endif

        static string RetrieveString() => "hello";
    }
}
