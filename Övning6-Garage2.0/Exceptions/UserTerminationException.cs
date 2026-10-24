using Microsoft.Win32.SafeHandles;

namespace Övning6_Garage2._0.Exceptions;

public class UserTerminationException : Exception
{

    private const string DefaultMessage = "User quit!";
    public UserTerminationException() : base(DefaultMessage)
    {

    }

    public UserTerminationException(string? message) : base(message ?? DefaultMessage)
    {

    }
}