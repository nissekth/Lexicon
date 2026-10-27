using System;
using System.Collections.Generic;
using System.Linq;
namespace Övning7_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exempeldata
            List<Student> studenter = new List<Student>
            {
                new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
                new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
                new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
                new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
                new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
                new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
                new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
                new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
            };
            Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");

            /*
                Where
                    • Hämta alla studenter som är äldre än 20.
                    • Hämta alla studenter som har mer än 80 poäng.
                Select
                    • Visa bara namnen på alla studenter.
                    • Visa namn och poäng i en ny anonym typ
                OrderBy
                    • Sortera studenter efter ålder.
                    • Sortera studenter efter poäng, högst först.
                Count
                    • Räkna hur många studenter som finns.
                    • Räkna hur många som går i klass A
                Take
                    • Ta ut de tre första studenterna.
                    • Ta ut de två bästa poängen efter sortering.
                Distinct
                    • Visa alla unika klassnamn.
                    • Visa alla unika åldrar.
                Any / All
                    • Finns det någon student med 100 poäng?
                    • Har alla studenter minst 50 poäng?
                FirstOrDefault / Last / Single
                    • Hämta första studenten i klass B.
                    • Hämta sista studenten i listan.
                    • Hämta studenten med ett visst Id.
                GroupBy
                    • Gruppera studenter per klass.
                    • Skriv ut varje klass och namnen i gruppen.
                Sum / Average / Min / Max
                    • Summera alla poäng.
                    • Räkna ut medelpoäng.
                    • Hitta lägsta och högsta poäng.
            */
            
            //Where
            Console.WriteLine("______________________________________");
            Console.WriteLine("*** WHERE ***");
            List<Student> över20år = studenter.Where(student => student.Alder > 20).ToList();
            Console.WriteLine("Över 20 år:");
            foreach(Student entry in över20år)
            {
                Console.WriteLine(entry.Namn + ": " + entry.Alder + "år");
            }
            List<Student> över80poäng = studenter.Where(student => student.Poang > 80).ToList();
            Console.WriteLine("\nÖver 80 poäng:");
            foreach(Student entry in över80poäng)
            {
                Console.WriteLine(entry.Namn + ": " + entry.Poang + "p");
            }
            Console.WriteLine("______________________________________");

            //Select
            Console.WriteLine("*** SELECT ***");
            List<string> studenterNamn = studenter.Select(student => student.Namn).ToList();
            Console.WriteLine("Namn på alla:");
            foreach(string entry in studenterNamn)
            {
                Console.WriteLine(entry);
            }
            var studenterNamnOchPoäng = studenter.Select(student => new {a = student.Namn, b = student.Poang});
            Console.WriteLine("\nNamn och poäng:");
            foreach(var entry in studenterNamnOchPoäng)
            {
                Console.WriteLine(entry.a + " " + entry.b);
            }
            Console.WriteLine("______________________________________");

            //OrderBy
            Console.WriteLine("*** ORDER BY ***");
            List<Student> åldersSortering = studenter.OrderBy(student => student.Alder).ToList();
            Console.WriteLine("Ålder (asc): ");
            foreach(Student entry in åldersSortering)
            {
                Console.WriteLine(entry.Namn + ": " + entry.Alder + "år");
            }

            List<Student> poängSortering = studenter.OrderByDescending(student => student.Poang).ToList();
            Console.WriteLine("\nPoäng (desc): ");
            foreach(Student entry in poängSortering)
            {
                Console.WriteLine(entry.Namn + ": " + entry.Poang + "p");
            }
            Console.WriteLine("______________________________________");
            

            //Count
            Console.WriteLine("*** COUNT ***");
            int antalStudenter = studenter.Count();
            Console.WriteLine("Antal studenter: ");
            Console.WriteLine(antalStudenter);

            int antalStudenterIA = studenter.Count(student => student.Klass == "A");
            Console.WriteLine("\nStudenter i A-klassen: ");
            Console.WriteLine(antalStudenterIA);
            Console.WriteLine("______________________________________");
            

            //Take
            Console.WriteLine("*** TAKE ***");
            List<Student> förstaTreStudenterna = studenter.Take(3).ToList();
            Console.WriteLine("Första tre studenterna: ");
            foreach(Student entry in förstaTreStudenterna)
            {
                Console.WriteLine(entry.Namn);
            }

            List<Student> tvåBästaPoäng = poängSortering.Take(2).ToList();
            Console.WriteLine("\nTvå bästa poängen (desc): ");
            foreach(Student entry in tvåBästaPoäng)
            {
                Console.WriteLine(entry.Poang + "p (" + entry.Namn + ")");
            }
            Console.WriteLine("______________________________________");
            

            //Distinct
            Console.WriteLine("*** DISTINCT ***");
            List<string> unikaKlassnamn = studenter.Select(student => student.Klass).Distinct().ToList();
            Console.WriteLine("Alla unika klassnamn: ");
            foreach(string entry in unikaKlassnamn)
            {
                Console.WriteLine(entry);
            }

            List<int> unikaÅldrar = studenter.Select(student => student.Alder).Distinct().ToList();
            Console.WriteLine("\nAlla unika åldrar: ");
            foreach(int entry in unikaÅldrar)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine("______________________________________");
            

            //Any/All
            Console.WriteLine("*** ANY / ALL ***");
            bool högPoäng = studenter.Any(student => student.Poang == 100);
            Console.WriteLine("Student med poäng == 100? " + (högPoäng? "Ja" : "Nej"));

            bool minst50 = studenter.All(student => student.Poang >= 50);
            Console.WriteLine("\nAlla har minst 50p? " + (minst50? "Ja" : "Nej"));
            Console.WriteLine("______________________________________");


            //FirstOrDefault / Last / Single
            Console.WriteLine("*** FirstOrDefault / Last / Single ***");
            Student firstStudentIB = studenter.FirstOrDefault(student => student.Klass == "B")!;
            Console.WriteLine("Första studentem i Klass B: " + firstStudentIB!.Namn);

            Student sistaStudenten = studenter.Last();
            Console.WriteLine("Sista studenten i listan: " + sistaStudenten.Namn);

            Student studentMedID5 = studenter.Single(student => student.Id == 5);
            Console.WriteLine("Student med ID 5: " + studentMedID5.Namn + " (ID = " + studentMedID5.Id + ")");
            Console.WriteLine("______________________________________");


            //GroupBy
            Console.WriteLine("*** GroupBy ***");
            var studentByKlass = studenter.GroupBy(student => student.Klass).ToList();
            foreach (var klass in studentByKlass)
            {
                Console.WriteLine("|Klass " + klass.Key + "|");
                foreach (Student student in klass)
                {
                    Console.WriteLine("-" + student.Namn + " går i klass " + student.Klass);
                }
            }
            Console.WriteLine("______________________________________");


            //Sum / Average / Min / Max
            Console.WriteLine("*** Sum / Average / Min / Max ***");
            int totalPoäng = studenter.Sum(student => student.Poang);
            Console.WriteLine("Summan av alla poäng: " + totalPoäng);
            
            double genomsnitt = studenter.Average(student => student.Poang);
            Console.WriteLine("Genomsnittlig poäng: " + genomsnitt);

            int lägstaPoäng = studenter.Min(student => student.Poang);
            Console.WriteLine("Lägsta poäng: " + lägstaPoäng);

            int högstaPoäng = studenter.Max(student => student.Poang);
            Console.WriteLine("Högsta poäng: " + högstaPoäng);
            
            
            
            
        }
        



    }
}