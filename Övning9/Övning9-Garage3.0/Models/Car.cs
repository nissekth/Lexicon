namespace Övning9_Garage3._0.Models;

public class Car : Vehicle
{
    public CarBodyType BodyType {get; private set;}
    public override decimal Size => 1;
    public Car(VehicleType vehicleType, string licensePlate, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, CarBodyType bodyType) 
        : base(vehicleType, licensePlate, colour, fuelType, 4, length)
    {
        BodyType = bodyType;
    }

    public override string ListVehicleAttributes() { return $"{base.ListVehicleAttributes()}\nBodyType: {BodyType}"; }

}