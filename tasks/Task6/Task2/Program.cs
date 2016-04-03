using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

/*
    extension: Task 3 based on Task2  as an extension to >>> TASK 6 

    Coded by Gerald Karpiel
    ic15b081
*/
namespace Task2
{
     class Program
    {
        //extension the Code with ENUM for TASK 5 eqluals . 4_1
        enum gender
        {
            male,
            female
        };


        static void Main(string[] args) // jumppoint in to the programm
        {

            //ausgabe für den Push der aktuellen Fam.Mitglieder
            var membertype = new Subject<IFamMember>();
            membertype.Subscribe(x => Console.WriteLine("\n    " + x.Member_status)); 

            var members = new IFamMember[]//set new members in Stack sector of RAM
            {
                new brothers("Mathias", Convert.ToString(gender.male), 22), // save data in heap sector of RAM
                new brothers("Oskar", Convert.ToString(gender.male), 19), // and save data via Interface(Super-Class) to Sub-Classes 
                new uncle("Arthur", Convert.ToString(gender.male), 48),
                new uncle("Christian" , Convert.ToString(gender.male), 52),
                new aunt("Maria", Convert.ToString(gender.female), 49),
                new aunt("Isabella", Convert.ToString(gender.female), 42),
                new cousin("Sahra", Convert.ToString(gender.female), 21),
                new cousin("Martin", Convert.ToString(gender.male), 23),
                new cousin("Thomas", Convert.ToString(gender.male), 21),
                new pet("Jim", Convert.ToString(gender.male), 5 ),
                new pet("Goldi", Convert.ToString(gender.female), 2),
                new pet("Susi", Convert.ToString(gender.female), 1),
                new pet("Timy", Convert.ToString(gender.male), 20),
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
                if ( MEMBER.Age >= 100)
                    Console.WriteLine(MEMBER.Member_status + "    -_- (hmm...) probably death ...");
                else
                    Console.WriteLine(MEMBER.Member_status);
            }

  //extension of Task 4_1 (eq.Taks5) to Task 6 - Push vs. Pull and Events and Asynchrony

            Console.WriteLine("\n\n - Eingetragene Mitglieder: \n" );

            // push der Mitgliedstypen um die aktuellen Mitglieder anzuzeigen
            foreach (var Member in members)
            {
                membertype.OnNext(Member); 
            }

            var oldmembers = members.AsParallel().Where(x => x.Age > 50 ).Select(x => " Altes Mitglied: " + x.Member_status.PadRight(15)  );

            Console.WriteLine(" \n \n ");
            foreach (var x in oldmembers)
            {
                Console.WriteLine( x );
            }

            eventandasynchrony.Run(members);

            //Ausgabe des aktuellen Stands nach abbruch des aufrechnens

            Console.WriteLine();

            headerLine();// show header in console
            
            //output updated list of members
            foreach (var MEMBER in members)
            {
                if (MEMBER.Age >= 100)
                    Console.WriteLine(MEMBER.Member_status + "    -_- (hmm...) probably death ...");
                else
                    Console.WriteLine(MEMBER.Member_status);
            }
            Console.WriteLine();
            Console.WriteLine();

            // extension of Task 2 and 3 TO Task 4 -Jasonconversion

            ////set string for Jsonconversion
            //string data = JsonConvert.SerializeObject(members);
            //// set path for the Jason-File
            //string path_OF_file = @"C:\Users\Gerald\Dropbox\FH\SEM_2_SS_2016\Objektorientierte Methoden\__GIT\oom\tasks\Task4_1\OUTPUT_File.txt";

            ////Write Data to the Jason-File
            //if (!File.Exists(path_OF_file)) { File.WriteAllText(path_OF_file, data); }

            ////read the data from the file
            //string dataread = File.ReadAllText(path_OF_file);

            ////output the File-Data
            //Console.WriteLine("\n\n File was seccessful created!\n  ");
            //Console.WriteLine("\n\n File is readeble and give the follow output: \n\n  ");
            //Console.WriteLine(dataread);

            //Console.ReadKey();  // ReadKey for console-stop at the end

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
