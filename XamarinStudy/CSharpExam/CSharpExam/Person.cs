using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";

        private int score;

        public int Score
        {
            get { return score; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("input is not correct.");
                score = value;
            }
        }

    }
}
