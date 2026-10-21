using Microsoft.Win32.SafeHandles;

namespace Övning5_Garage1._0.Exceptions;

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