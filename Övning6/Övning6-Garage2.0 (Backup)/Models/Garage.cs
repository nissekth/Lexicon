
using Övning6_Garage2._0.Enums;
using Övning6_Garage2._0.Exceptions;

namespace Övning6_Garage2._0.Models;

// Skulle kunna lägga till så att totalNoOfSlots kan vara en decimal, för motorcykelstorlekar och dyl
public class Garage(string name, int capacity)
{
    public string Name {get; private set;} = name;
    public int MaxCapacity {get; private set;} = capacity;
    private decimal availableSlots = capacity;
    public decimal AvailableSlots => availableSlots;
    private List<Vehicle> parkedVehicles = new List<Vehicle>();

    public void ParkVehicle(Vehicle vehicle){
        if(vehicle.Size > availableSlots)
        {
            throw new GarageFullException();
        }

        parkedVehicles.Add(vehicle);
        availableSlots -= vehicle.Size;
    }

    public Vehicle RetrieveVehicle(string registreringsnummer)
    {
        int index = FindVehicle(registreringsnummer.ToUpper());
        if(index == -1)
        {
            throw new NoSuchVehicleException();
        }
        Vehicle vehicle = parkedVehicles[index];
        parkedVehicles.RemoveAt(index);
        availableSlots += vehicle.Size;
        return vehicle;
    }

    private int FindVehicle(string registreringsnummer)
    {
        int indexOfSpecifiedVehicle = -1;
        for(int i = 0; i < parkedVehicles.Count; i++)
        {
            if(parkedVehicles[i].Registreringsnummer == registreringsnummer)
            {
                return i;
            }
        }

        return indexOfSpecifiedVehicle;
    }

    public Vehicle GetVehicleInformation(string registreringsnummer)
    {

        int index = FindVehicle(registreringsnummer.ToUpper());
        if(index == -1)
        {
            throw new NoSuchVehicleException();
        }
        return parkedVehicles[index];
    }

    public List<Vehicle> GetAllVehiclesInformation()
    {
        if (parkedVehicles.Count < 1)
        {
            throw new Exception("Garage is empty!");
        }

        List<Vehicle> allVehicles = new List<Vehicle>();

        foreach(Vehicle v in parkedVehicles!)
        {
            allVehicles.Add(v);
        }

        return allVehicles;
    }

    public bool RegistreringsnummerAlreadyInGarage(string reg)
    {
        if(FindVehicle(reg) == -1)
        {
            return false;
        }
        return true;
    }

    public List<int> GetGarageStats()
    {
        if (parkedVehicles.Count < 1)
        {
            throw new Exception("Garage is empty!");
        }

        List<int> stats = new List<int>(Enum.GetValues<VehicleType>().Length);
        foreach(Vehicle v in parkedVehicles!)
        {
            stats[(int)v.VehicleType]++;
        }
        return stats;
    }


    public List<Vehicle> GetGarageSelection(VehicleType? vehicleType, VehicleColour? colour, FuelType? fuelType, int? noOfWheels, decimal? length)
    {
        if (!parkedVehicles.Any())
        {
            throw new Exception("Garage is empty!");
        }
        
        List<Vehicle> selection = new List<Vehicle>();

        //Det här var ju inte så snyggt... Byt ut mot && eller || istället kanske
        foreach (Vehicle? vehicle in parkedVehicles)
        {
            if (vehicleType == null || vehicle.VehicleType == vehicleType)
            {
                if (colour == null || vehicle.Colour == colour)
                {
                    if (fuelType == null || vehicle.FuelType == fuelType)
                    {
                        if (noOfWheels == null || vehicle.NoOfWheels == noOfWheels)
                        {
                            if (length == null || vehicle.Length == length)
                            {
                                selection.Add(vehicle);
                            }
                        }
                    }
                }
            }
        }

        return selection;
    }


}