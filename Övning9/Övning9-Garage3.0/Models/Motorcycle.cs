
namespace Övning9_Garage3._0.Models;

public class Motorcycle : Vehicle
{    
    public MotorcycleBodyType BodyType {get; private set;}
    public override decimal Size => 1;
    public Motorcycle(VehicleType vehicleType, string licensePlate, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, MotorcycleBodyType bodyType) 
        : base(vehicleType, licensePlate, colour, fuelType, 2, length)
    {
        BodyType = bodyType;
    }

    public override string ListVehicleAttributes() { return $"{base.ListVehicleAttributes()}\nBodyType: {BodyType}"; }

}