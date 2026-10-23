using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Motorcycle : Vehicle
{
    public override decimal Size => 1;
    public Motorcycle(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 2, length)
    {
    }
}