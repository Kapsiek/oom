using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class FamMember
    {
       private int new_age; // private filed

        public FamMember(string first_name, string sex, int age) //Constructor
        {
            if (age < 0) throw new ArgumentOutOfRangeException("Age can't be negative.");

            this.First_Name = first_name;
            this.Sex = sex;
            this.Age = age;
        }

        public string First_Name { get; }
        public string Sex { get; }
        public int Age { get; set; }  // get- and set- accessor 
       
        public int Next_Year(int ago) // method to update age of family members
        {
            return new_age = Age + ago; 
        }

    }
}
