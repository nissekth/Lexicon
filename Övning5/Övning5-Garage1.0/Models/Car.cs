using Övning5_Garage1._0.Enums;
namespace Övning5_Garage1._0.Models;

public class Car : Vehicle
{
    public override decimal Size => 1;
    public Car(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 4, length)
    {
    }

}