using Microsoft.Win32.SafeHandles;

namespace Övning6_Garage2._0.Exceptions;

public class UserBackNavigationException : Exception
{

    public UserBackNavigationException() : base("")
    {

    }

    public UserBackNavigationException(string? message) : base(message ?? "")
    {

    }
}