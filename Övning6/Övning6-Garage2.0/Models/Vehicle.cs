
using Övning6_Garage2._0.Enums;

namespace Övning6_Garage2._0.Models;

public abstract class Vehicle
{
    public VehicleType VehicleType {get; private set;}
    private string _registreringsnummer = "";
    public VehicleColour Colour {get; private set;}
    public int NoOfWheels {get; private set;}
    public decimal Length {get; private set;}
    public FuelType FuelType {get; private set;}
    public abstract decimal Size {get;}

    public Vehicle(VehicleType vehicleType, string registreringsnummer, VehicleColour? colour, FuelType? fuelType, int noOfWheels, decimal length)
    {
        this.VehicleType = vehicleType;
        this.Registreringsnummer = registreringsnummer;
        this.Colour = colour ?? VehicleColour.Undefined;
        this.FuelType = fuelType ?? FuelType.Undefined;
        this.NoOfWheels = noOfWheels;
        this.Length = length;
    }

    public string Registreringsnummer
    {
        get
        {
            return _registreringsnummer;
        }
        set
        {
            if(value.Length != 6)
            {
                throw new Exception("Registreringsnummer must consist of 6 characters.");
            }
            if (!char.IsLetter(value.ElementAt(0)) || !char.IsLetter(value.ElementAt(1)) || !char.IsLetter(value.ElementAt(2)))
            {
                throw new Exception("Registreringsnummer must have letters at positions 1 2, and 3.");
            }
            if (!char.IsDigit(value.ElementAt(3)) || !char.IsDigit(value.ElementAt(4)))
            {
                throw new Exception("Registreringsnummer must have integers at positions 4 and 5.");
            }

            _registreringsnummer = value.ToUpper();
        }
    }

    public virtual string ListVehicleAttributes()
    {
        return $"Type: {VehicleType}\nReg: {Registreringsnummer}\nColour: {Colour}\nFuelType: {FuelType}\n#Wheels: {NoOfWheels}\nLength: {Length}m\nSize: {Size}";
    }

}