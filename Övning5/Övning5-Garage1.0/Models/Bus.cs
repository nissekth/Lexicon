using Övning5_Garage1._0.Enums;
namespace Övning5_Garage1._0.Models;

public class Bus : Vehicle
{
    public override decimal Size => 3;
    public Bus(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 8, length)
    {
    }
}