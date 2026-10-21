using Övning5_Garage1._0.Enums;
namespace Övning5_Garage1._0.Models;

public class Motorcycle : Vehicle
{
    public override decimal Size => 1;
    public Motorcycle(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 2, length)
    {
    }
}