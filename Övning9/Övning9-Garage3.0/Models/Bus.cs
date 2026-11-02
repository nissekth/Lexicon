namespace Övning9_Garage3._0.Models;

public class Bus : Vehicle
{
    //Fix so that this doesnt default to 0 on lack of input, null or something istället
    public int NoOfSeats {get; private set;}
    public override decimal Size => 3;
    public Bus(VehicleType vehicleType, string licensePlate, VehicleColour colour, FuelType fuelType, int noOfWheels, decimal length, int noOfSeats) 
        : base(vehicleType, licensePlate, colour, fuelType, 8, length)
    {
        NoOfSeats = noOfSeats;
    }

        public override string ListVehicleAttributes() 
    { 
        string seats = NoOfSeats > 0? "\n#Seats: " + NoOfSeats : "";
        return $"{base.ListVehicleAttributes()} {seats}"; 
    }

}