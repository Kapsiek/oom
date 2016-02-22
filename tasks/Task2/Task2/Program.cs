using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args) // jumppoint in to the programm
        {
            var members = new[] //set new members in Stack sector of RAM
            {
                new FamMember("Gerald  ", "male", 25),  // save dates in heap sector of RAM
                new FamMember("Mathias ", "male", 22),
                new FamMember("Oskar   ", "male", 19),
            };

            headerLine(); // show header in console

            foreach (var MEMBER in members) // show all members in console
            {
                Console.WriteLine(" |    " + MEMBER.First_Name + "    |   " + MEMBER.Sex + "   |   " + MEMBER.Age);
            }

            //insert future-time in years
            Console.Write("\n   How many years you want to go in to the future?: ");
            int i = Convert.ToInt16(Console.ReadLine());
            
            Console.WriteLine("\n  ... {0} year(s) later...\n\n", i);

            headerLine();// show header in console

            //change all age-data of each member
            foreach (var MEMBER in members)
            {
                 MEMBER.Age = MEMBER.Next_Year(i);
            }

            //output updated list of mebers
            foreach (var MEMBER in members)
            {
                if(MEMBER.Age >= 100)
                    Console.WriteLine(" |    " + MEMBER.First_Name + "    |   " + MEMBER.Sex + "   |   " + MEMBER.Age +  "    -_- (hmm...) probably death ...");
                else
                    Console.WriteLine(" |    " + MEMBER.First_Name + "    |   " + MEMBER.Sex + "   |   " + MEMBER.Age);
            }

            Console.ReadKey();  // ReadKey for console-stop at the end
        }

        //own method für head-line
        private static void headerLine()
        {
            Console.WriteLine("\n -----      Family Members    -----\n\n ");
            Console.WriteLine("\n |   NAME         |   SEX    |   Age  ");
            Console.WriteLine("\n -----------------------------------\n");
        }
    }
}
