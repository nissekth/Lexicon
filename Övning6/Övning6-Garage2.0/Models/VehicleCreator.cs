using Övning6_Garage2._0.Enums;

namespace Övning6_Garage2._0.Models;

public class VehicleCreator{

    public static Vehicle CreateVehicle(VehicleType vehicleType, string registreringsnummer, VehicleColour? vehicleColour, FuelType? fuelType, decimal vehicleLength, 
        MotorcycleBodyType? motorcycleBodyType, CarBodyType? carBodyType, int? noOfSeats, bool? hasTrailer, int? noOfEngines)
    {
        try
        {
            switch (vehicleType)
            {
                case VehicleType.Motorcycle: 
                    return CreateMotorcycle(registreringsnummer, vehicleColour, fuelType, vehicleLength, motorcycleBodyType); 
                case VehicleType.Car: 
                    return CreateCar(registreringsnummer, vehicleColour, fuelType, vehicleLength, carBodyType); 
                case VehicleType.Bus: 
                    return CreateBus(registreringsnummer, vehicleColour, fuelType, vehicleLength, noOfSeats); 
                case VehicleType.Boat: 
                    return CreateBoat(registreringsnummer, vehicleColour, fuelType, vehicleLength, hasTrailer ?? false); 
                case VehicleType.Airplane: 
                    return CreateAirplane(registreringsnummer, vehicleColour, fuelType, vehicleLength, noOfEngines); 
                default: throw new Exception("No such vehicle type!");
            }
        }
        catch(Exception)
        {
            throw;
        }
    }
    public static Vehicle CreateVehicle(Random random, int maxSize)
    {
        try{
            VehicleType vehicleType = (VehicleType)random.Next(0, maxSize);
            string registreringsnummer = CreateRandomRegistreringsnummer(random);
            VehicleColour vehicleColour = (VehicleColour)random.Next(0, Enum.GetValues<VehicleColour>().Length);
            FuelType fuelType = (FuelType)random.Next(0, Enum.GetValues<FuelType>().Length);
            decimal vehicleLength = random.Next(1, 120);

            switch (vehicleType)
            {
                case VehicleType.Motorcycle: 
                    MotorcycleBodyType motorcycleBodyType = (MotorcycleBodyType)random.Next(0, Enum.GetValues<MotorcycleBodyType>().Length);
                    return CreateMotorcycle(registreringsnummer, vehicleColour, fuelType, vehicleLength, motorcycleBodyType); 
                case VehicleType.Car: 
                    CarBodyType carBodyType = (CarBodyType)random.Next(0, Enum.GetValues<CarBodyType>().Length);
                    return CreateCar(registreringsnummer, vehicleColour, fuelType, vehicleLength, carBodyType); 
                case VehicleType.Bus: 
                    int noOfSeats = random.Next(0, 251);
                    return CreateBus(registreringsnummer, vehicleColour, fuelType, vehicleLength, noOfSeats); 
                case VehicleType.Boat: 
                    bool hasTrailer = random.Next(0, 2) == 0;
                    return CreateBoat(registreringsnummer, vehicleColour, fuelType, vehicleLength, hasTrailer); 
                case VehicleType.Airplane: 
                    int noOfEngines = random.Next(0, 9);
                    return CreateAirplane(registreringsnummer, vehicleColour, fuelType, vehicleLength, noOfEngines); 
                default: throw new Exception("No such vehicle type!");
            }
        }
        catch(Exception)
        {
            throw;
        }
    }

    private static Motorcycle CreateMotorcycle(string registreringsnummer, VehicleColour? vehicleColour, FuelType? fuelType, decimal? vehicleLength, MotorcycleBodyType? bodyType)
    {
        return new Motorcycle(VehicleType.Motorcycle, registreringsnummer, vehicleColour ?? VehicleColour.Undefined, fuelType ?? FuelType.Undefined, 2, vehicleLength ?? 0, bodyType ?? MotorcycleBodyType.Undefined); 
    }

    private static Car CreateCar(string registreringsnummer, VehicleColour? vehicleColour, FuelType? fuelType, decimal? vehicleLength, CarBodyType? bodyType)
    {
        return new Car(VehicleType.Car, registreringsnummer, vehicleColour ?? VehicleColour.Undefined, fuelType ?? FuelType.Undefined, 4, vehicleLength ?? 0, bodyType ?? CarBodyType.Undefined); 
    }

    private static Bus CreateBus(string registreringsnummer, VehicleColour? vehicleColour, FuelType? fuelType, decimal? vehicleLength, int? noOfSeats)
    {
        return new Bus(VehicleType.Bus, registreringsnummer, vehicleColour ?? VehicleColour.Undefined, fuelType ?? FuelType.Undefined, 6, vehicleLength ?? 0, noOfSeats ?? 0); 
    }

    private static Boat CreateBoat(string registreringsnummer, VehicleColour? vehicleColour, FuelType? fuelType, decimal? vehicleLength, bool hasTrailer)
    {
        return new Boat(VehicleType.Boat, registreringsnummer, vehicleColour ?? VehicleColour.Undefined, fuelType ?? FuelType.Undefined, 0, vehicleLength ?? 0, hasTrailer); 
    }

    private static Airplane CreateAirplane(string registreringsnummer, VehicleColour? vehicleColour, FuelType? fuelType, decimal? vehicleLength, int? noOfEngines)
    {
        return new Airplane(VehicleType.Airplane, registreringsnummer, vehicleColour ?? VehicleColour.Undefined, fuelType ?? FuelType.Undefined, 8, vehicleLength ?? 0, noOfEngines ?? 0); 
    }

    private static string CreateRandomRegistreringsnummer(Random random)
    {
        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ";
        string reg = "";

        //1st-3rd: letters
        for(int i = 0; i < 3; i++)
        {
            reg += alfabet[random.Next(alfabet.Length)];
        }
        //4th and 5th: digits
        for(int i = 0; i < 2; i++)
        {
            reg += random.Next(0, 10);
        }
        //6th: letter or digit
        if(random.Next(0, 2) == 1) 
        {
            reg += random.Next(0, 10);
        } 
        else
        {
            reg += alfabet[random.Next(alfabet.Length)];
        }

        return reg;
    }

}