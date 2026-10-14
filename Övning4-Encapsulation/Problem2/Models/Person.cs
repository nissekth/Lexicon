

namespace Övning4.Problem2;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public string FirstName{
        get => firstName;
        private set
        {
            if (value == null || value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            firstName = value;
            
        }
    }
    public string LastName{
        get => lastName;
        private set
        {
            if (value == null || value.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }
    public int Age{
        get => age;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }
    public decimal Salary{
        get => salary;
        private set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 dollars!");
            }
            salary = value;
        }
    }

    public void IncreaseSalary(decimal percentage)
    {
        if(age < 30){
            Salary *= 1 + (percentage/ 200);
        }
        else
        {
            Salary *= 1 + (percentage/ 100);
        }
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary.ToString("F2")} dollars.";
    }

}