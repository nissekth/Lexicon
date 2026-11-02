namespace Övning9_Garage3._0.Exceptions;

public class NoSuchVehicleException : Exception
{

    private const string DefaultMessage = "Vehicle could not be found!";
    public NoSuchVehicleException() : base(DefaultMessage)
    {

    }

    public NoSuchVehicleException(string? message) : base(message ?? DefaultMessage)
    {

    }
}