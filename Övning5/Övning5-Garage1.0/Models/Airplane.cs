using Övning5_Garage1._0.Enums;
namespace Övning5_Garage1._0.Models;

public class Airplane : Vehicle
{
    
    public override decimal Size => 4;
    public Airplane(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 6, length)
    {
    }
}