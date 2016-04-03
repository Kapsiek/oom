using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class cousin : IFamMember  // Sub-Class cousin for SUPER-Class FamMember
    {
        public cousin(string first_name, string sex, int age) //Constructor
        {
            if (age < 0) throw new ArgumentOutOfRangeException("Age can't be negative.");
            if (string.IsNullOrWhiteSpace (first_name)) throw new ArgumentOutOfRangeException("\n\n First name can´t be empty \n\n");
            if (string.IsNullOrWhiteSpace (sex)) throw new ArgumentOutOfRangeException("\n\n Sax can´t be empty \n\n");
            if ((sex != "male") && (sex != "female")) throw new ArgumentOutOfRangeException("\n\n Sax must be male or female \n\n");
            
            this.First_Name = first_name;
            this.Sex = sex;

            this.Age = age;
        }

        public string First_Name { get; }
        public string Sex { get; }

        public int Age { get; set; }

        public int Next_Year(int ago) // method to update age of family members
        {
            return Age = Age + ago;
        }

        public string Member_status => " " + "Cousin".PadRight(10) + "|".PadRight(5) + First_Name.PadRight(10) + "|".PadRight(5) + Sex.PadRight(10) + "|".PadRight(5) + Age;
    }
}
