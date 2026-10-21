
using Övning5_Garage1._0.Enums;
using Övning5_Garage1._0.Exceptions;

namespace Övning5_Garage1._0.Models;

// Skulle kunna lägga till så att totalNoOfSlots kan vara en decimal, för motorcykelstorlekar och dyl
public class Garage(string name, int capacity)
{
    public string Name {get; private set;} = name;
    public int MaxCapacity {get; private set;} = capacity;
    private decimal availableSlots = capacity;
    public decimal AvailableSlots => availableSlots;
    private Vehicle?[] parkedVehicles = new Vehicle[capacity];

    public void ParkVehicle(Vehicle vehicle){
        if(vehicle.Size > availableSlots)
        {
            throw new GarageFullException();
        }

        int availableSlotIndex = Array.FindIndex(parkedVehicles, 0, parkedVehicles.Length, 
            vehicle => vehicle == null);

        if(availableSlotIndex == -1)
        {
            throw new GarageFullException($"Error! No parking slots available for the size of your vehicle. (Size {vehicle.Size})");
        }

        parkedVehicles[availableSlotIndex] = vehicle;
        availableSlots -= vehicle.Size;
    }

    public Vehicle RetrieveVehicle(string registreringsnummer)
    {
        int index = FindVehicle(registreringsnummer.ToUpper());
        if(index == -1)
        {
            throw new NoSuchVehicleException();
        }
        Vehicle vehicle = parkedVehicles[index]!;
        parkedVehicles[index] = null;
        availableSlots += vehicle.Size;
        return vehicle;
    }

    private int FindVehicle(string registreringsnummer)
    {
        int indexOfSpecifiedVehicle = Array.FindIndex(parkedVehicles, 0, parkedVehicles.Length, 
            parkedVehicle => parkedVehicle != null &&
            registreringsnummer == parkedVehicle.Registreringsnummer);

        return indexOfSpecifiedVehicle;
    }

    public Vehicle GetVehicleInformation(string registreringsnummer)
    {

        int index = FindVehicle(registreringsnummer.ToUpper());
        if(index == -1)
        {
            throw new NoSuchVehicleException();
        }
        Vehicle vehicle = parkedVehicles[index]!;
        return vehicle;
    }

    public Vehicle[] GetAllVehiclesInformation()
    {
        if (!parkedVehicles.Any())
        {
            throw new Exception("Garage is empty!");
        }

        Vehicle[] allVehicles = new Vehicle[MaxCapacity];
        int i = 0;
        foreach(Vehicle v in parkedVehicles!)
        {
            if(v != null){
                allVehicles[i++] = v;
            }
        }
        Array.Resize(ref allVehicles,i);
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

    public int[] GetGarageStats()
    {
        if (!parkedVehicles.Any())
        {
            throw new Exception("Garage is empty!");
        }

        int[] stats = new int[Enum.GetNames<VehicleType>().Length];
        foreach(Vehicle v in parkedVehicles!)
        {
            if(v != null){
                stats[(int)v.VehicleType]++;
            }
        }
        return stats;
    }


    public Vehicle[] GetGarageSelection(VehicleType? vehicleType, VehicleColour? colour, FuelType? fuelType, int? noOfWheels, decimal? length)
    {
        if (!parkedVehicles.Any())
        {
            throw new Exception("Garage is empty!");
        }
        
        Vehicle[] selection = new Vehicle[parkedVehicles.Length];
        int count = 0;

        //Det här var ju inte så snyggt... Byt ut mot && eller || istället kanske
        foreach (Vehicle? vehicle in parkedVehicles)
        {
            if (vehicle != null)
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
                                    selection[count++] = vehicle;
                                }
                            }
                        }
                    }
                }
            }
        }

        Array.Resize(ref selection, count);
        return selection;
    }


}