using System;
using System.Threading;
using Personalregister.DBHandler;
using Personalregister.Models;

namespace Personalregister
{
    class Program
    {
        static void Main(string[] args){

            Register lokaltPersonalRegister = new Register();
            int semaphore = 0;
            int valdTjänst = -1;

            Console.Write("Välkommen!");

            while (true)
            {
                

                Console.WriteLine("\nVälj ett alternativ genom att skriva motsvarande siffra nedan.");
                Console.WriteLine("1. Skapa ny användare");
                Console.WriteLine("2. Begär lista över alla användare");
                Console.WriteLine("3. Begär löneinfo om specifik användare");
                
                while (semaphore < 1)
                {
                    Console.Write("> ");

                    try
                    {
                        String input = Console.ReadLine() ?? throw new Exception("Vänligen ange en siffra mellan 1 och 3.");
                        valdTjänst = int.Parse(input);
                        if(valdTjänst < 1 || valdTjänst > 3)
                        {
                            throw new Exception("Vänligen ange en siffra mellan 1 och 3.");
                        }

                        semaphore = 1;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error! {e.Message}");
                        System.Threading.Thread.Sleep(400);
                    }
                }

                if (valdTjänst == 1)
                {
                    try
                    {       
                        Console.Write("Skriv den anställdes förnamn: ");
                        string förnamn = Console.ReadLine() ?? throw new Exception("Ogiltigt förnamn.");
                        Console.Write("Skriv den anställdes efternamn: ");
                        string efternamn = Console.ReadLine() ?? throw new Exception("Ogiltigt efternamn.");
                        Console.Write("Skriv den anställdes lön: ");
                        string tempLön = Console.ReadLine() ?? "Ogiltig lön.";
                        double lön = double.Parse(tempLön);

                        Anställd person = new Anställd(förnamn, efternamn, lön);
                        lokaltPersonalRegister.LäggTillAnställd(person);

                        Console.WriteLine("*****************************************************");
                        Console.WriteLine("Ny anställd tillagd: " + förnamn + " " + efternamn);
                        Console.WriteLine("*****************************************************");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("*****************************************************");
                        Console.WriteLine($"Error! {e.Message}");
                        Console.WriteLine("Person ej tillagd i systemet!");
                        Console.WriteLine("*****************************************************");
                        System.Threading.Thread.Sleep(400);
                    }
                }
                else if (valdTjänst == 2)
                {
                    try
                    { 
                        List<Anställd> personal = lokaltPersonalRegister.HämtaAllaAnställda();
                        Console.WriteLine("*****************************************************");
                        foreach(Anställd person in personal)
                        {
                            Console.WriteLine("Namn: " + person.Förnamn + " " + person.Efternamn + " | Lön: " + person.Lön);
                        }
                        Console.WriteLine("*****************************************************");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("*****************************************************");
                        Console.WriteLine($"Error! {e.Message}");
                        System.Threading.Thread.Sleep(400);
                        Console.WriteLine("*****************************************************");
                    }
                }
                else if (valdTjänst == 3)
                {

                    try
                    {
                        Console.Write("Skriv den anställdes förnamn: ");
                        string förnamn = Console.ReadLine() ?? throw new Exception("Ogiltigt förnamn.");

                        Console.Write("Skriv den anställdes efternamn: ");
                        string efternamn = Console.ReadLine() ?? throw new Exception("Ogiltigt efternamn.");

                        Anställd person = lokaltPersonalRegister.HämtaSpecifikAnställd(förnamn, efternamn);
                        
                        Console.WriteLine("*****************************************************");
                        Console.WriteLine(person.Förnamn + " " + person.Efternamn + " har " + person.Lön + "kr i lön.");
                        Console.WriteLine("*****************************************************");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("*****************************************************");
                        Console.WriteLine($"{e.Message}");
                        System.Threading.Thread.Sleep(400);
                        Console.WriteLine("*****************************************************");
                    }
                }

                semaphore = 0;
                valdTjänst = -1;

            }

        }

    }

}