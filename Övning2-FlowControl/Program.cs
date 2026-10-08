using System;
using System.IO;
using System.Threading;

namespace FlowControl
{

    public enum ÅldersGrupp
    {
        Ungdom,
        Standard,
        Pensionär
    }
    
    internal class Program
    {

        const int UNGDOMSPRIS = 80;
        const int STANDARDPRIS = 120;
        const int PENSIONÄRSPRIS = 90;

        public static void Main(string[] args){


            while (true)
            {   
                Console.WriteLine("****************** Huvudmeny ******************");
                Console.WriteLine("Vänligen knappa in en siffra motsvarande den tjänst du vill nyttja.");
                Console.WriteLine("Du avslutar genom att knappa in \'0\'.");
                Console.WriteLine("1. Kolla upp ditt biljettpris.");
                Console.WriteLine("2. Kolla upp totalkostnad för sällskap.");
                Console.WriteLine("3. Skriv ut en valfri textrad tio gånger.");
                Console.WriteLine("4. Skriv ut det tredje ordet i en valfri textrad.");


                Boolean semaphore = true;
                int valdTjänst = -1;

                // Loop until user has given a valid choice for Huvudmeny
                while (semaphore)
                {
                    Console.Write("> ");

                    // Read the user input from the console. If it is not a valid number, throw an exception.
                    try
                    {
                        String input = Console.ReadLine() ?? throw new Exception("Vänligen ange en siffra mellan 1 och 4.");
                        valdTjänst = int.Parse(input);
                        semaphore = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error! {e.Message}");
                        System.Threading.Thread.Sleep(500);
                    }
                }

                
                switch (valdTjänst)
                {
                    case 0:
                        Console.WriteLine($"Stänger ned programmet.");
                        System.Threading.Thread.Sleep(500);
                        return;
                    case 1:
                        Meny1();
                        Console.WriteLine("");
                        System.Threading.Thread.Sleep(500);
                        break;
                    case 2:
                        Meny2();
                        Console.WriteLine("");
                        System.Threading.Thread.Sleep(500);
                        break;
                    case 3:
                        Meny3();
                        Console.WriteLine("");
                        System.Threading.Thread.Sleep(500);
                        break;
                    case 4:
                        Meny4();
                        Console.WriteLine("");
                        System.Threading.Thread.Sleep(500);
                        break;
                    default:
                        Console.WriteLine($"Felaktig input, vänligen försök igen.\n");
                        System.Threading.Thread.Sleep(500);
                        break;
                }

                semaphore = true;
                valdTjänst = -1;

            }

        }

        /// <summary>
        /// Reads the user input and throws an exception if they have not entered an integer between 0 and 125.
        /// Determines ticket price based on age and prints it to the console.
        /// </summary>
        private static void Meny1()
        {

            Console.WriteLine("****************** Meny 1 ******************");
            Console.WriteLine("Vänligen tryck in din ålder.");

            while (true)
            {
                Console.Write("> ");
                try
                {
                    String input = Console.ReadLine() ?? throw new Exception("Vänligen ange en siffra mellan 0 och 125.");
                    int ålder;
                    if (int.TryParse(input, out ålder))
                    {
                        ÅldersGrupp åldersGrupp = AvgörÅldersgrupp(ålder);
                        if (åldersGrupp.Equals(ÅldersGrupp.Ungdom))
                        {  
                            Console.WriteLine($"Ungdomspris: {UNGDOMSPRIS} kr");
                        }
                        else if (åldersGrupp.Equals(ÅldersGrupp.Pensionär))
                        {  
                            Console.WriteLine($"Pensionärspris: {PENSIONÄRSPRIS} kr");
                        }
                        else
                        {
                            Console.WriteLine($"Standardpris: {STANDARDPRIS} kr");
                        }
                        return;
                    }
                    else
                    {
                        throw new Exception("Vänligen ange en siffra mellan 0 och 125.");
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! {e.Message}");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Helper method which determines which returns an ÅldersGrupp enum based on a given age.
        /// </summary>
        /// <param name="ålder"></param>
        /// <returns></returns>
        private static ÅldersGrupp AvgörÅldersgrupp(int ålder)
        {
            if (ålder < 20)
            {
                return ÅldersGrupp.Ungdom;
            }
            else if (ålder > 64)
            {
                return ÅldersGrupp.Pensionär;
            }
            return ÅldersGrupp.Standard;
        }

        private static int AvgörPris(ÅldersGrupp åldersGrupp)
        {
           return 2;
        }

        /// <summary>
        /// Reads the user input and throws an exception if they have not entered an integer n, between 2 and 12.
        /// Iterates n times and prompts the user for age input. Throws an exception if the user fails to enter an integer between 0 and 125.
        /// Calculates the total cost based on the price for the age categories corresponding to the user input and prints it to the console.
        /// </summary>
        private static void Meny2()
        {

            Console.WriteLine("****************** Meny 2 ******************");
            Console.WriteLine("Vänligen tryck in antal personer i sällskapet.");
            Console.WriteLine("För sällskap på fler än 12 personer, vänligen kontakta kundtjänst.");

            while (true)
            {
                Console.Write("> ");
                try
                {
                    String input1 = Console.ReadLine() ?? throw new Exception("Vänligen ange en siffra mellan 2 och 12.");
                    int n;
                    int totalkostnad = 0;
                    if (int.TryParse(input1, out n))
                    {
                        if (n < 2 || n > 12)
                        {
                            throw new Exception("Vänligen ange en siffra mellan 2 och 12.");
                        }
                        for(int i = 1; i <= n; i++)
                        {
                            Console.WriteLine($"Vänligen tryck in ålder på person #{i}.");
                            String input2 = Console.ReadLine() ?? throw new Exception("Vänligen ange en siffra mellan 0 och 125.");
                            int ålder;
                            if (int.TryParse(input2, out ålder))
                            {
                                ÅldersGrupp åldersGrupp = AvgörÅldersgrupp(ålder);                        
                                if (åldersGrupp.Equals(ÅldersGrupp.Ungdom))
                                {  
                                    totalkostnad += UNGDOMSPRIS;
                                }
                                else if (åldersGrupp.Equals(ÅldersGrupp.Pensionär))
                                {  
                                    totalkostnad += PENSIONÄRSPRIS;
                                }
                                else
                                {
                                    totalkostnad += STANDARDPRIS;
                                }
                            }
                            else
                            {
                                throw new Exception("Vänligen ange en siffra mellan 0 och 125.");
                            }
                        }

                        Console.WriteLine($"Totalkostnad: {totalkostnad} kr");
                        return;
                    }
                    else
                    {
                        throw new Exception("Vänligen ange en siffra mellan 2 och 12.");
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! {e.Message}");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Reads the user input and throws an exception if they have not entered any characters.
        /// Prints the user input to the console ten times.
        /// </summary>
        private static void Meny3()
        {
            
            Console.WriteLine("****************** Meny 3 ******************");
            Console.WriteLine("Vänligen ange en textrad du vill repetera.");

            while (true)
            {
                Console.Write("> ");
                try
                {
                    String input = Console.ReadLine() ?? throw new Exception("Vänligen ange minst ett tecken.");
                    if(input.Length < 1)
                    {
                        throw new Exception("Vänligen ange minst ett tecken.");
                    }
                    for(int i = 1; i < 10; i++)
                    {
                        Console.Write($"{i}. {input}, ");
                    }
                    Console.WriteLine($"10. {input}");
                    return;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! {e.Message}");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Reads the user input and throws an exception if they have not entered at least three groups 
        /// of characters separated by at least two are blankspaces.
        /// Prints the third group of characters to the console.
        /// </summary>
        private static void Meny4()
        {
        
            Console.WriteLine("****************** Meny 4 ******************");
            Console.WriteLine("Vänligen ange en textrad du vill skriva ut tredje ordet ur.");
            Console.WriteLine("Texten du anger måste vara minst tre ord lång.");

            while (true)
            {
                Console.Write("> ");
                try
                {
                    String input = Console.ReadLine() ?? throw new Exception("Vänligen ange minst ett tecken.");
                    if(input.Length < 1)
                    {
                        throw new Exception("Vänligen ange minst ett tecken.");
                    }
                    String[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (splitInput.Length < 3)
                    {
                        throw new Exception("Vänligen ange minst tre ord separerade av mellanslag.");
                    }
                    Console.WriteLine(splitInput[2]);
                    return;
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! {e.Message}");
                    System.Threading.Thread.Sleep(500);
                }
            }
        }


    }

}