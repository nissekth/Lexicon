using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Boat : Vehicle
{
    public bool Trailer {get; private set;}
    public override decimal Size => 2;
    public Boat(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, bool trailer) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 0, length)
    {
        Trailer = trailer;
    }

    public override string ListVehicleAttributes()
    {
        string hasTrailer = Trailer? "Yes" : "No";
        return $"Type: {VehicleType}\nReg: {Registreringsnummer}\nColour: {Colour}\nFuelType: {FuelType}\n#Wheels: {NoOfWheels}\nLength: {Length}m\nOn trailer: {hasTrailer}\nSize: {Size}";
    }
}