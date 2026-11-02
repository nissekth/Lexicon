namespace Övning9_Garage3._0.Exceptions;

public class GarageFullException : Exception
{

    private const string DefaultMessage = "Garage is full!";
    public GarageFullException() : base(DefaultMessage)
    {

    }

    public GarageFullException(string? message) : base(message ?? DefaultMessage)
    {

    }
}