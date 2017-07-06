using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExam
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonTest();
        }

        static void JsonTest()
        {
            var person = new Person()
            {
                FirstName = "Jin",
                LastName = "Yoon",
            };

            var json = person.ToJson();
            Console.WriteLine(json);

            var newPerson = json.JsonToObject<Person>();
            Console.WriteLine(newPerson.FirstName + newPerson.LastName);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get; set; }
    }
    public enum ResultType { Success, Fail }

    public class Result<T>
    {
        public T Entity { get; set; }

        public ResultType ResultType { get; set; }
    }

    public static class StringHelper
    {
        public static string ToJson<T>(this T entity) => JsonConvert.SerializeObject(entity);

        public static T JsonToObject<T>(this string json) => JsonConvert.DeserializeObject<T>(json);
    }
}
