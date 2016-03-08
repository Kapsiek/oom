using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class uncle : FamMember  // Sub-Class uncle for SUPER-Class FamMember
    {
        private int new_age; // private filed

        public uncle(string first_name, string sex, int age) //Constructor
        {
            if (age < 0) throw new ArgumentOutOfRangeException("\n\n Age can't be negative. \n\n");
            if (string.IsNullOrWhiteSpace(first_name)) throw new ArgumentOutOfRangeException("\n\n First name can´t be empty \n\n");
            if (string.IsNullOrWhiteSpace(sex)) throw new ArgumentOutOfRangeException("\n\n Sax can´t be empty\n\n");
            if ((sex != "male") && (sex != "female")) throw new ArgumentOutOfRangeException("\n\n Sax must be male or female \n\n");
            if (new_age < 0) throw new ArgumentOutOfRangeException("\n\n NEW Age can't be negative.\n\n");


            this.First_Name = first_name;
            this.Sex = sex;
            Next_Year(age);  // set age or get new age
        }

        public string First_Name { get; }
        public string Sex { get; }
        public int Age => new_age;  // get- and set- accessor 

        public int Next_Year(int ago) // method to update age of family members
        {
            return new_age = Age + ago;
        }

        public string Member_status => " Uncle " + " " + First_Name + " " + Sex + " " + Age;

    }
}
