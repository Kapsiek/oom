using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Task2
{
    public class eventandasynchrony
    {
        public static void Run(IFamMember[] x)
        {
            var random = new Random();
           
            //Test der einzelnen Ausgabe
            Console.Write("\n\n Brüder: \n\n ".PadRight(20) + x[1].First_Name.PadRight(20) + "\n".PadRight(15) + "&\n");
            Console.Write(" ".PadRight(20) + x[0].First_Name.PadRight(17) + "\n\n\n");

            //Ausgabe aller gefunden Mitglieder und veränderung des Alters inkl. Wartezeit
            var liste1 = new List<Task<IFamMember>>();
            foreach (var y in x)
            {
                var liste = Task.Run(() =>
                {
                    Console.WriteLine(" Gefundenes Mitglied:  " + y.First_Name + "\n");
                        Task.Delay(TimeSpan.FromSeconds(random.Next(50))).Wait();

                    y.Age = y.Age + 1;
                    return y;
                });

                //hinzufügen des gefunden Mitglieds zu der Familienliste um sein Alter zu erhoehen
                liste1.Add(liste); 
            }


            //erstellen der zweiten Liste um den Geburtstag auszugeben -> Mitglied wird ein Jahr aelter
            var Liste2 = new List<Task<IFamMember>>();
            foreach (var liste in liste1.ToArray())
            {
                Liste2.Add(
                    liste.ContinueWith(a => 
                    {
                        Console.Write("  " + " Das Mitglied " + a.Result.First_Name + " ist gerade ".PadRight(7) + Convert.ToString(a.Result.Age) + " Jahr alt geworden. \n\n");
                            if(a.Result.Age > 50)
                            { Console.Write("    --> " + " Das Mitglied " + a.Result.First_Name + " gehört zu den aeltern Mitglieder der Familie!!! \n\n \n ".PadRight(7) ); }
                        return a.Result;
                    }));
            }

            Console.Write(" ---  Die Zeit vergeht .... und alle werden älter ... \n \n \n ");

            var calcs = new CancellationTokenSource();

            Console.ReadLine();
            calcs.Cancel();
            Console.Write("  --->> Zeitschleife wurde unterbrochen !!! \n\n\n");

            return ;
        }


        public static Task<int> CalcNewAge(CancellationToken calc, IFamMember[] x)
        {
            return Task.Run(() =>
            {
                int erg = 0;
                foreach (var y in x)
                {
                    erg += y.Age;
                }
                return erg;
            }, calc);
        }

        public static async Task PrintNewAge(CancellationToken calc, IFamMember[] x)
        {
            while (true)
            {
                calc.ThrowIfCancellationRequested(); // fehlerabfang für token

                int data = await CalcNewAge(calc, x);

                if (Convert.ToString(data).Length > 5)
                    Console.WriteLine(data);

                Task.Delay(TimeSpan.FromSeconds(3)).Wait();
            }
        }



    }
}
