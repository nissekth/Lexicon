using Övning9_Garage3._0.Models;

namespace Övning9_Garage3._0.Tests;

public class GarageTests
{

    [Theory]
    [InlineData(VehicleType.Car, "abc123", VehicleColour.Black, FuelType.Petrol, 4, 2, CarBodyType.SUV)]
    [InlineData(VehicleType.Car, "abc123", VehicleColour.Black, FuelType.Electric, 4, 2, CarBodyType.PickupTruck)]
    [InlineData(VehicleType.Car, "abc123", VehicleColour.Black, FuelType.Undefined, 0, 0, CarBodyType.Undefined)]
    public void ParkVehicle(VehicleType type, string reg, VehicleColour col, FuelType fuel, int wheels, decimal length, CarBodyType body)
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Car car = new(type, reg, col, fuel, wheels, length, body);

        //Act - Kör koden som ska testas
        garage.ParkVehicle(car);

        //Assert - kontrollera resultatet
        Assert.Single(garage);
        Assert.Contains(car, garage);
        Assert.Equal(VehicleColour.Black, car.Colour);
        Assert.Equal(19, garage.AvailableSlots);
    }

    [Fact]
    public void RetrieveVehicle()
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Black, FuelType.Petrol, 4, 2, MotorcycleBodyType.Scooter);
        Airplane airplane = new(VehicleType.Airplane, "abc124", VehicleColour.Black, FuelType.Petrol, 4, 2, 8);
        garage.ParkVehicle(motorcycle);
        garage.ParkVehicle(airplane);

        //Act - Kör koden som ska testas
        var vehicle1 = garage.RetrieveVehicle("abc123");
        var vehicle2 = garage.RetrieveVehicle("abc124");

        //Assert - kontrollera resultatet
        Assert.Equal("ABC123", vehicle1.LicensePlate);
        Assert.Same(motorcycle.LicensePlate, vehicle1.LicensePlate);
        Assert.Equal("ABC124", vehicle2.LicensePlate);
        Assert.Same(airplane.LicensePlate, vehicle2.LicensePlate);
        Assert.Equal(20, garage.AvailableSlots);
    }


    [Fact]
    public void VehicleInGarage()
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Black, FuelType.Petrol, 4, 2, MotorcycleBodyType.Scooter);
        garage.ParkVehicle(motorcycle);

        //Act - Kör koden som ska testas
        bool vehicle1 = garage.VehicleInGarage("abc123");
        bool vehicle2 = garage.VehicleInGarage("abc124");

        //Assert - kontrollera resultatet
        Assert.True(vehicle1);
        Assert.False(vehicle2);


    }

    [Fact]
    public void GetVehicleInformation()
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Black, FuelType.Petrol, 4, 2, MotorcycleBodyType.Scooter);
        Airplane airplane = new(VehicleType.Airplane, "abc124", VehicleColour.Black, FuelType.Petrol, 4, 2, 8);
        garage.ParkVehicle(motorcycle);
        garage.ParkVehicle(airplane);

        //Act - Kör koden som ska testas
        var vehicle1 = garage.GetVehicleInformation("abc123");
        var vehicle2 = garage.GetVehicleInformation("abc124");

        //Assert - kontrollera resultatet
        Assert.Equal("ABC123", vehicle1.LicensePlate);
        Assert.Same(motorcycle.LicensePlate, vehicle1.LicensePlate);
        Assert.Equal("ABC124", vehicle2.LicensePlate);
        Assert.Same(airplane.LicensePlate, vehicle2.LicensePlate);
        Assert.Equal(15, garage.AvailableSlots);

    }

    [Fact]
    public void GetAllVehiclesInformation()
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Black, FuelType.Petrol, 2, 2, MotorcycleBodyType.Scooter);
        Airplane airplane = new(VehicleType.Airplane, "abc124", VehicleColour.Black, FuelType.Petrol, 4, 0, 8);
        Car car = new(VehicleType.Car, "abc125", VehicleColour.Black, FuelType.Electric, 4, 3, CarBodyType.SUV);
        Bus bus = new(VehicleType.Bus, "abc126", VehicleColour.Black, FuelType.Hybrid, 8, 22, 120);
        garage.ParkVehicle(motorcycle);
        garage.ParkVehicle(airplane);
        garage.ParkVehicle(car);
        garage.ParkVehicle(bus);

        //Act - Kör koden som ska testas
        var stats = garage.GetAllVehiclesInformation();

        //Assert - kontrollera resultatet
        Assert.Equal(4, stats!.Count);
        Assert.Same(motorcycle, stats[0]);
        Assert.Same(airplane, stats[1]);
        Assert.Same(car, stats[2]);
        Assert.Same(bus, stats[3]);
        
    }


    [Fact]
    public void GetGarageSelection()
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Yellow, FuelType.Petrol, 2, 2, MotorcycleBodyType.Scooter);
        Airplane airplane = new(VehicleType.Airplane, "abc124", VehicleColour.Red, FuelType.Petrol, 4, 0, 8);
        Car car = new(VehicleType.Car, "abc125", VehicleColour.Yellow, FuelType.Electric, 4, 3, CarBodyType.SUV);
        Bus bus1 = new(VehicleType.Bus, "abc126", VehicleColour.Blue, FuelType.Hybrid, 8, 22, 120);
        Bus bus2 = new(VehicleType.Bus, "abc127", VehicleColour.Yellow, FuelType.Hybrid, 8, 22, 120);
        garage.ParkVehicle(motorcycle);
        garage.ParkVehicle(airplane);
        garage.ParkVehicle(car);
        garage.ParkVehicle(bus1);
        garage.ParkVehicle(bus2);

        //Act - Kör koden som ska testas
        var selectionBus = garage.GetGarageSelection(VehicleType.Bus, null, null, null, null);
        var selectionCar = garage.GetGarageSelection(VehicleType.Car, null, null, null, null);
        var selectionPetrol = garage.GetGarageSelection(null, null, FuelType.Petrol, null, null);
        var selectionYellowPetrol = garage.GetGarageSelection(null, VehicleColour.Yellow, FuelType.Petrol, null, null);
        var selectionTwowheeler = garage.GetGarageSelection(null, null, null, 2, null);
        var selectionFourwheeler = garage.GetGarageSelection(null, null, null, 4, null);
        var selectionEightwheeler = garage.GetGarageSelection(null, null, null, 8, null);
        var selectionLengthlessthan20 = garage.GetGarageSelection(null, null, null, null, 19);
        var selectionFullnull = garage.GetGarageSelection(null, null, null, null, null);

        //Assert - kontrollera resultatet
        Assert.Equal(2, selectionBus.Count());
        Assert.Equal("ABC127", selectionBus.Last().LicensePlate);
        Assert.Single(selectionCar);
        Assert.Equal(2, selectionPetrol.Count());
        Assert.Single(selectionYellowPetrol);
        Assert.Single(selectionTwowheeler);
        Assert.Single(selectionFourwheeler);
        Assert.Equal(2, selectionEightwheeler.Count());
        Assert.Equal(3, selectionLengthlessthan20.Count());
        Assert.Equal(5, selectionFullnull.Count());
    }


    [Fact]
    public void GetGarageStats()
    {
        //Arrange - Förered testet
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Black, FuelType.Petrol, 2, 2, MotorcycleBodyType.Scooter);
        Airplane airplane = new(VehicleType.Airplane, "abc124", VehicleColour.Black, FuelType.Petrol, 4, 0, 8);
        Car car = new(VehicleType.Car, "abc125", VehicleColour.Black, FuelType.Electric, 4, 3, CarBodyType.SUV);
        Bus bus1 = new(VehicleType.Bus, "abc126", VehicleColour.Black, FuelType.Hybrid, 8, 22, 120);
        Bus bus2 = new(VehicleType.Bus, "abc127", VehicleColour.Black, FuelType.Hybrid, 8, 22, 120);
        garage.ParkVehicle(motorcycle);
        garage.ParkVehicle(airplane);
        garage.ParkVehicle(car);
        garage.ParkVehicle(bus1);
        garage.ParkVehicle(bus2);

        //Act - Kör koden som ska testas
        var stats = garage.GetGarageStats();

        //Assert - kontrollera resultatet
        Assert.Equal(6, stats!.Count);
        Assert.Equal(1, stats![VehicleType.Motorcycle]);
        Assert.Equal(2, stats![VehicleType.Bus]);
        Assert.Equal(0, stats![VehicleType.Boat]);

    }


    [Fact]
    public void GetEnumerator()
    {
        //Arrange
        Garage<Vehicle> garage = new("TestGarage",20);
        Motorcycle motorcycle = new(VehicleType.Motorcycle, "abc123", VehicleColour.Black, FuelType.Petrol, 2, 2, MotorcycleBodyType.Scooter);
        Airplane airplane = new(VehicleType.Airplane, "abc124", VehicleColour.Black, FuelType.Petrol, 4, 0, 8);
        garage.ParkVehicle(motorcycle);
        garage.ParkVehicle(airplane);
        var stats = garage.GetAllVehiclesInformation();

        //Act - Kör koden som ska testas
        var enumerator = stats!.GetEnumerator();

        //Assert - kontrollera resultatet
        Assert.True(enumerator.MoveNext());
        Assert.Same(motorcycle, enumerator.Current);
        Assert.True(enumerator.MoveNext());
        Assert.Same(airplane, enumerator.Current);
        Assert.False(enumerator.MoveNext());
    }

    
}
