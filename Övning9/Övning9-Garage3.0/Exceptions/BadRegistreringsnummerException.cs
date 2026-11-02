
namespace Övning9_Garage3._0.Exceptions;

public class BadLicensePlateException : Exception
{

    private const string DefaultMessage = "Incorrect format for licensePlate!";
    public BadLicensePlateException() : base(DefaultMessage)
    {

    }

    public BadLicensePlateException(string? message) : base(message ?? DefaultMessage)
    {

    }
}