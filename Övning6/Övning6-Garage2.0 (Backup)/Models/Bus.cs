using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Bus : Vehicle
{
    public override decimal Size => 3;
    public Bus(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 8, length)
    {
    }
}