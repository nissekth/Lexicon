using Övning5_Garage1._0.Enums;
namespace Övning5_Garage1._0.Models;

public class Boat : Vehicle
{
    public override decimal Size => 2;
    public Boat(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 0, length)
    {
    }
}