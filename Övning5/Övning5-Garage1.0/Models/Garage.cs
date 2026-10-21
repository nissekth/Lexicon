
using Övning5_Garage1._0.Enums;
using Övning5_Garage1._0.Exceptions;

namespace Övning5_Garage1._0.Models;

// Skulle kunna lägga till så att totalNoOfSlots kan vara en decimal, för motorcykelstorlekar och dyl
public class Garage(string name, int capacity)
{
    public string Name {get; private set;} = name;
    private int garageCapacity = capacity;
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

        Vehicle[] allVehicles = new Vehicle[garageCapacity];
        int i = 0;
        foreach(Vehicle v in parkedVehicles)
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
        int[] stats = new int[Enum.GetNames<VehicleType>().Length];
        foreach(Vehicle v in parkedVehicles)
        {
            if(v != null){
                stats[(int)v.VehicleType]++;
            }
        }
        return stats;
    }

}