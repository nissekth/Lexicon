using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Airplane : Vehicle
{
    
    public override decimal Size => 4;
    public Airplane(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 6, length)
    {
    }
}