using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    extension: Task 3 based on Task2  as an extension

    Coded by Gerald Karpiel
    ic15b081
*/
namespace Task2
{
    class Program
    {
        static void Main(string[] args) // jumppoint in to the programm
        {
            var members = new FamMember[]//set new members in Stack sector of RAM
            {
                new brothers("Mathias   ", "male   ", 22), // save data in heap sector of RAM
                new brothers("Oskar     ", "male   ", 19), // and save data via Interface(Super-Class) to Sub-Classes 
                new uncle("  Arthur    ", "male   ", 48),
                new uncle("  Christian " , "male   ", 52),
                new aunt("   Maria     ", "female ", 49),
                new aunt("   Isabella  ", "female ", 42),
                new cousin(" Sahra     ", "female ", 21),
                new cousin(" Martin    ", "male   ", 23),
                new cousin(" Thomas    ", "male   ", 21),
            };

            headerLine(); // show header in console

            foreach (var MEMBER in members) // show all members in console
            {
                Console.WriteLine( MEMBER.Member_status );  // interface Methode
            }

            //insert future-time in years
            Console.Write("\n   How many years you want to go in to the future?: ");
            int i = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("\n  ... {0} year(s) later...\n\n", i);

            headerLine();// show header in console

            //change all age - data of each member
            foreach (var MEMBER in members)
            {
                MEMBER.Next_Year(i);  // give interface a value for Sub-Class methods
            }

            //output updated list of members
            foreach (var MEMBER in members)
            {
                if ( i >= 80)
                    Console.WriteLine(MEMBER.Member_status + "    -_- (hmm...) probably death ...");
                else
                    Console.WriteLine(MEMBER.Member_status);
            }

            Console.ReadKey();  // ReadKey for console-stop at the end
        }

        //own method für head-line
        private static void headerLine()
        {
            Console.WriteLine("\n -----           Family Members       -----");
            Console.WriteLine("\n Status  |   NAME  |   SEX  |  Age  ");
            Console.WriteLine("\n ------------------------------------------\n");
        }
    }
}
