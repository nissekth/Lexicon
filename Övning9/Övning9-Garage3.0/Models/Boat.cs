namespace Övning9_Garage3._0.Models;

public class Boat : Vehicle
{
    public bool Trailer {get; private set;}
    public override decimal Size => 2;
    public Boat(VehicleType vehicleType, string licensePlate, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, bool trailer) 
        : base(vehicleType, licensePlate, colour, fuelType, 0, length)
    {
        Trailer = trailer;
    }


    public override string ListVehicleAttributes() 
    { 
        string hasTrailer = Trailer? "Yes" : "No";
        return $"{base.ListVehicleAttributes()} \nOn trailer: {hasTrailer}"; 
    }
}