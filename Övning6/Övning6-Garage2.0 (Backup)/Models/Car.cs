using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Car : Vehicle
{
    public override decimal Size => 1;
    public Car(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 4, length)
    {
    }

}