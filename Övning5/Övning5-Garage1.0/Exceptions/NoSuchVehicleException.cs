using Microsoft.Win32.SafeHandles;

namespace Övning5_Garage1._0.Exceptions;

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