
namespace Övning9_Garage3._0.Models;

public interface IVehicle
{
    VehicleType VehicleType {get;}
    string LicensePlate {get;}
    VehicleColour Colour {get;}
    int NoOfWheels {get;}
    decimal Length {get;}
    FuelType FuelType {get;}
    decimal Size {get;}

    string ListVehicleAttributes();
}