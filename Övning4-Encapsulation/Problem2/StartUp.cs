
namespace Övning4.Problem2;

public class StartUp
{
 
    const string USAGE = "Invalid input! Please enter the entry in the format \"Firstname Lastname Age Salary\".";

    /// <summary>
    /// Main method from lecture but modified to include valiadtion
    /// </summary>
    public static void Main()
    {
        int lines;
        if(!int.TryParse(Console.ReadLine(), out lines))
        {
            Console.WriteLine("Invalid input! Please enter an integer.");
            return;
        }

        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {   
            string input = Console.ReadLine();
            if(input == null)
            {
                Console.WriteLine(USAGE);
                return;
            }
            string[] cmdArgs = input.Split();

            try
            {   
                var person = new Person(
                    cmdArgs[0], cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]
                ));
                persons.Add(person);
            } 
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid input: " + e.Message);
                continue;
            }
            catch (IndexOutOfRangeException)
            {
                
                Console.WriteLine(USAGE);
                continue;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! " + e.Message);
                continue;
            }
        }
        
        decimal bonus;
        if(!decimal.TryParse(Console.ReadLine(), out bonus))
        {
            Console.WriteLine("Invalid input! Please enter an integer.");
            return;
        }
        persons.ForEach(p => p.IncreaseSalary(bonus));
        persons.ForEach(p => Console.WriteLine(p.ToString()));
    
    }

}