
namespace Övning9_Garage3._0.Exceptions;

public class UserBackNavigationException : Exception
{

    public UserBackNavigationException() : base("")
    {

    }

    public UserBackNavigationException(string? message) : base(message ?? "")
    {

    }
}