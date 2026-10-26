using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Motorcycle : Vehicle
{    
    public MotorcycleBodyType BodyType {get; private set;}
    public override decimal Size => 1;
    public Motorcycle(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, MotorcycleBodyType bodyType) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 2, length)
    {
        BodyType = bodyType;
    }

    public override string ListVehicleAttributes()
    {
        return $"Type: {VehicleType}\nReg: {Registreringsnummer}\nColour: {Colour}\nFuelType: {FuelType}\n#Wheels: {NoOfWheels}\nLength: {Length}m\nBodyType: {BodyType}\nSize: {Size}";
    }
}