using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    partial class Program
    {
        static void Main(string[] args)
        {
#if false
            var persons = new List<Person>()
            {
                new Person() { FirstName = "Jin", LastName = "Yoon", Score = 90 },
                new Person() { FirstName = "YoungJoo", LastName = "Park", Score = 100 },
            };

            var highScore = from person in persons
                            where person.Score > 90
                            select person.FullName;

            foreach (var p in highScore)
            {
                Console.WriteLine(p);
                Console.WriteLine(p.GetCurrentType());
            }
#endif

            object[] ps = {
                new Developer { FirstName = "Jin", LastName = "Yoon", MainLanguage = "C#", },
                new Developer { FirstName = "Gunsun", LastName = "Lee", MainLanguage = "C", },
                new SalesMan { FirstName = "Hanbyul", LastName = "Park", Sales = 8000000, },
                new SalesMan { FirstName = "Dongsu", LastName = "Kim", Sales = 12000000, },
            };

            foreach (var p in ps)
            {
                switch (p)
                {
                    case Developer d:
                        Console.WriteLine(d.FullName + " : " + d.MainLanguage);
                        break;
                    case SalesMan s when s.Sales > 10000000:
                        Console.WriteLine(s.FullName + "(Elite) : " + s.Sales);
                        break;
                    case SalesMan s:
                        Console.WriteLine(s.FullName + " : " + s.Sales);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public static class TypeHelper
    {
        public static string GetCurrentType<T>(this T entity)
        {
            return typeof(T).FullName;
        }
    }
}
