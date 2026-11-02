namespace Övning9_Garage3._0.Models;

public class Airplane : Vehicle
{
    public int NoOfEngines {get; private set;}
    public override decimal Size => 4;
    public Airplane(VehicleType vehicleType, string licensePlate, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, int noOfEngines) 
        : base(vehicleType, licensePlate, colour, fuelType, 6, length)
    {
        NoOfEngines = noOfEngines;
    }
    
    public override string ListVehicleAttributes() 
    { 
        string engines = NoOfEngines > 0? "\n#Engines: " + NoOfEngines : "";
        return $"{base.ListVehicleAttributes()} {engines}"; 
    }
}