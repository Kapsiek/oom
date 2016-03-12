using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/*
    extension: Task 3 based on Task2  as an extension to >>> TASK 4 

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
                new brothers("Mathias", "male", 22), // save data in heap sector of RAM
                new brothers("Oskar", "male", 19), // and save data via Interface(Super-Class) to Sub-Classes 
                new uncle("Arthur", "male", 48),
                new uncle("Christian" , "male", 52),
                new aunt("Maria", "female", 49),
                new aunt("Isabella", "female", 42),
                new cousin("Sahra", "female", 21),
                new cousin("Martin", "male", 23),
                new cousin("Thomas", "male", 21),
            };

            headerLine(); // show header in console

            foreach (var MEMBER in members) // show all members in console
            {

                Console.WriteLine( MEMBER.Member_status );  // interface Methode
            }
            
            //insert future-time in years
            Console.Write("\n   How many years you want to go in to the future?: ");
            int i = Convert.ToInt16(Console.ReadLine());
            if (i < 0) throw new ArgumentOutOfRangeException("\n\n New Age can't be negative.\n\n");

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

  // extension of Task 2 and 3 TO Task 4 -Jasonconversion
    
            //set string for Jsonconversion
            string data = JsonConvert.SerializeObject(members);
            // set path for the Jason-File
            string path_OF_file = @"C:\Users\ic15b081\Dropbox\FH\SEM_2_SS_2016\Objektorientierte Methoden\__GIT\oom\tasks\Task4\OUTPUT_File.txt";

            //Write Data to the Jason-File
            if (!File.Exists(path_OF_file)) { File.WriteAllText(path_OF_file, data); }

            //read the data from the file
            string dataread = File.ReadAllText(path_OF_file);

            //output the File-Data
            Console.WriteLine("\n\n File was seccessful created!\n  ");
            Console.WriteLine("\n\n File is readeble and give the follow output: \n\n  ");
            Console.WriteLine(dataread);

            Console.ReadKey();  // ReadKey for console-stop at the end

        }

        //own method für head-line
        private static void headerLine()
        {
            Console.WriteLine("\n -------------    Family Members    -------------- ");
            Console.WriteLine("\n Status    |     NAME     |     SEX      |    Age  ");
            Console.WriteLine("\n ------------------------------------------------\n");
        }
    }
}
