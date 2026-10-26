using Övning6_Garage2._0.Enums;
namespace Övning6_Garage2._0.Models;

public class Bus : Vehicle
{
    //Fix so that this doesnt default to 0 on lack of input, null or something istället
    public int NoOfSeats {get; private set;}
    public override decimal Size => 3;
    public Bus(VehicleType vehicleType, string registreringsnummer, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, int noOfSeats) 
        : base(vehicleType, registreringsnummer, colour, fuelType, 8, length)
    {
        NoOfSeats = noOfSeats;
    }

    public override string ListVehicleAttributes()
    {
        string seats = NoOfSeats > 0? "\nMaxCapaxity: " + NoOfSeats : "";
        return $"Type: {VehicleType}\nReg: {Registreringsnummer}\nColour: {Colour}\nFuelType: {FuelType}\n#Wheels: {NoOfWheels}\nLength: {Length}m\n{seats} seats\nSize: {Size}";
    }

}