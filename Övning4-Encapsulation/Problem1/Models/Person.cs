

namespace Övning4;

public class Person(string firstName, string lastName, int age)
{
    private string firstName = firstName;
    private string lastName = lastName;
    private int age = age;

    public string FirstName => firstName;
    public string LastName => lastName;
    public int Age => age;

    public override string ToString()
    {
        return $"{firstName} {lastName} is {age} years old.";
    }

}