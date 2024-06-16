using VehicleRentalSystem;
using VehicleRentalSystem.Vehicles;

Vehicle car = new Motorcycle()
{
    CustomerName = "John Doe",
    Brand = "Triumph",
    Model = "Tiger Sport 660",
    Value = 10000,
    RentalStart = new DateTime(2024, 6, 6),
    RentalEnd = new DateTime(2024, 6, 16),
    DriverAge = 20
};

Invoice invoice = new Invoice(car);


Console.WriteLine(invoice.ToString());