
using System.Collections;
using Övning9_Garage3._0.Exceptions;

namespace Övning9_Garage3._0.Models;

// Skulle kunna lägga till så att totalNoOfSlots kan vara en decimal, för motorcykelstorlekar och dyl
public class Garage<T>(string name, int capacity) : IEnumerable<T> where T : Vehicle
{
    public string Name {get; private set;} = name;
    public int MaxCapacity {get; private set;} = capacity;
    private decimal availableSlots = capacity;
    public decimal AvailableSlots => availableSlots;
    private readonly List<T> parkedVehicles = new List<T>();

    public void ParkVehicle(T vehicle){
        if(vehicle.Size > availableSlots)
        {
            throw new GarageFullException();
        }

        parkedVehicles.Add(vehicle);
        availableSlots -= vehicle.Size;
    }

    public T RetrieveVehicle(string licensePlate)
    {
        int index = FindVehicle(licensePlate.ToUpper());
        if(index == -1)
        {
            throw new NoSuchVehicleException();
        }
        T vehicle = parkedVehicles[index];
        parkedVehicles.RemoveAt(index);
        availableSlots += vehicle.Size;
        return vehicle;
    }

    private int FindVehicle(string licensePlate)
    {
        int indexOfSpecifiedVehicle = -1;
        for(int i = 0; i < parkedVehicles.Count; i++)
        {
            if(parkedVehicles[i].LicensePlate == licensePlate.ToUpper())
            {
                return i;
            }
        }

        return indexOfSpecifiedVehicle;
    }

    public T GetVehicleInformation(string licensePlate)
    {

        int index = FindVehicle(licensePlate);
        if(index == -1)
        {
            throw new NoSuchVehicleException();
        }
        return parkedVehicles[index];
    }

    public IReadOnlyList<T>? GetAllVehiclesInformation()
    {
        return parkedVehicles;
    }

    public bool VehicleInGarage(string licensePlate)
    {
        if(FindVehicle(licensePlate) == -1)
        {
            return false;
        }
        return true;
    }

    public IReadOnlyDictionary<VehicleType,int> GetGarageStats()
    {
        Dictionary<VehicleType,int> stats = new();
        foreach(VehicleType type in Enum.GetValues<VehicleType>())
        {
            stats.Add(type, parkedVehicles.Count(v => v.VehicleType == type));
        }
        return stats;
    }


    public IEnumerable<T> GetGarageSelection(VehicleType? vehicleType, VehicleColour? colour, FuelType? fuelType, int? noOfWheels, decimal? length)
    {
        if (!parkedVehicles.Any())
        {
            throw new Exception("Garage is empty!");
        }
        
        List<T> selection = new List<T>();

        //Det här var ju inte så snyggt... Byt ut mot && eller || istället kanske
        foreach (T? vehicle in parkedVehicles)
        {
            if (vehicleType == null || vehicle.VehicleType == vehicleType)
            {
                if (colour == null || vehicle.Colour == colour)
                {
                    if (fuelType == null || vehicle.FuelType == fuelType)
                    {
                        if (noOfWheels == null || vehicle.NoOfWheels == noOfWheels)
                        {
                            if (length == null || vehicle.Length <= length)
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

    public IEnumerator<T> GetEnumerator()
    {
        foreach(T v in parkedVehicles)
        {
            yield return v;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}