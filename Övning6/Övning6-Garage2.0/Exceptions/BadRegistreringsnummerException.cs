
namespace Övning6_Garage2._0.Exceptions;

public class BadRegistreringsnummerException : Exception
{

    private const string DefaultMessage = "Incorrect format for registreringsnummer!";
    public BadRegistreringsnummerException() : base(DefaultMessage)
    {

    }

    public BadRegistreringsnummerException(string? message) : base(message ?? DefaultMessage)
    {

    }
}