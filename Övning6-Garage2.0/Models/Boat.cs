using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Boat : Vehicle
{
    public override decimal Size => 2;
    public Boat(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 0, length)
    {
    }
}