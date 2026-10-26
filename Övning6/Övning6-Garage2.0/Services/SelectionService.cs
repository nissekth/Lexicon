
using Övning6_Garage2._0.Exceptions;

namespace Övning6_Garage2._0.Services;

public class SelectionService
{
    
    public static string? GetUserSelection()
    {
        Console.Write("> ");
        string? input = Console.ReadLine();

        if(string.IsNullOrWhiteSpace(input))
        {
            return null;
        }
        if (input == "q")
        {
            throw new UserTerminationException();
        }
        if (input == "b")
        {
            throw new UserBackNavigationException();
        }
        return input;
    }

    public static int UserInputSelection(int floor, int ceiling)
    {
        while(true){
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"You must select an option below or go back.");
                continue;
            }
            if (input == "q")
            {
                throw new UserTerminationException();
            }
            if (input == "b")
            {
                throw new UserBackNavigationException();
            }

            int userSelection = 0;
            bool parseSuccess = int.TryParse(input,out userSelection);
            if (parseSuccess)
            {
                if(userSelection >= floor && userSelection <= ceiling)
                {
                    return userSelection;
                }
            }
            Console.WriteLine($"Invalid option! Please provide an integer between {floor} and {ceiling}!\n");
            continue;
        }
    }
}