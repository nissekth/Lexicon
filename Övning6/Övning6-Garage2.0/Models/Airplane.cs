using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Airplane : Vehicle
{
    public int NoOfEngines {get; private set;}
    public override decimal Size => 4;
    public Airplane(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, int noOfEngines) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 6, length)
    {
        NoOfEngines = noOfEngines;
    }

    public override string ListVehicleAttributes()
    {
        string engines = NoOfEngines > 0? "\n#Engines: " + NoOfEngines : "";
        return $"Type: {VehicleType}\nReg: {Registreringsnummer}\nColour: {Colour}\nFuelType: {FuelType}\n#Wheels: {NoOfWheels}\nLength: {Length}m\n{engines}\nSize: {Size}";
    }
}