using Personalregister.Models;

namespace Personalregister.Tests;

public class EmployeeTests
{
    [Fact]
    public void EmployeeTest1()
    {
        //Arrange
        Anställd anställd = new Anställd("Maja", "Gräddnos");

        //Act
        

        //Assert
        Assert.Equal("Gräddnos",anställd.Efternamn);
    }
}
