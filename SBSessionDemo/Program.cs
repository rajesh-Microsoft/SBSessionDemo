using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using SBSessionReceiver;

class Program
{
    private const string connectionString = "";
    private const string queueName = "sessiontest";
    static string rideId = "RajeshRide"; // Unique ID for the ride

    static async Task Main()
    {
        await SendRideUpdates();
    }

    static async Task SendRideUpdates()
    {         
        await RideRequested();
        await DriverAssigned();
        await RideStarted();
        await RideCompleted();    
    }

    static async Task RideRequested()
    {
        await using var client = new ServiceBusClient(connectionString);
        ServiceBusSender sender = client.CreateSender(queueName);
  
        var rideRequested = new RideRequested()
        {
            RideId = rideId,
            Status = "Ride Requested",
            Timestamp = DateTime.UtcNow,
            PassengerId = "Passenger123",
            PickupLocation = "Location A",
            DropoffLocation = "Location B",
            PaymentMethod = "Credit Card"
        };

        var rideRequestedMessage = JsonSerializer.Serialize(rideRequested);
        ServiceBusMessage message = new(rideRequestedMessage)
        {
            SessionId = rideId // Ensures messages for this ride are grouped
        };
        await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent: {rideRequestedMessage}");
    }
    
    static async Task DriverAssigned()
    {
        await using var client = new ServiceBusClient(connectionString);
        ServiceBusSender sender = client.CreateSender(queueName);
  
        var driverAssigned = new DriverAssigned()
        {
            RideId = rideId,
            Status = "Driver Assigned",
            Timestamp = DateTime.UtcNow,
            DriverId = "Driver456",
            DriverName = "John Doe",
            DriverRating = 4.8,
            Vehicle = "Toyota Camry",
            VehicleNumber = "ABC1234",
            EtaMinutes = 5
        };

        var driverAssignedMessage = JsonSerializer.Serialize(driverAssigned);
        ServiceBusMessage message = new(driverAssignedMessage)
        {
            SessionId = rideId // Ensures messages for this ride are grouped
        };
        await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent: {driverAssignedMessage}");
    }

    static async Task RideStarted()
    {
        await using var client = new ServiceBusClient(connectionString);
        ServiceBusSender sender = client.CreateSender(queueName);
  
        var rideStarted = new RideStarted()
        {   
            RideId = rideId,
            Status = "Ride Started",
            Timestamp = DateTime.UtcNow,
            DriverId = "Driver456",      
            PassengerId = "Passenger123",
            PickupLocation = "Location A"
          
        };

        var rideStartedMessage = JsonSerializer.Serialize(rideStarted);
        ServiceBusMessage message = new(rideStartedMessage)
        {
            SessionId = rideId // Ensures messages for this ride are grouped
        };
        await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent: {rideStartedMessage}");
    }

    static async Task RideCompleted()
    {
        await using var client = new ServiceBusClient(connectionString);
        ServiceBusSender sender = client.CreateSender(queueName);
  
        var rideCompleted = new RideCompleted()
        {
            RideId = rideId,
            Status = "Ride Completed",
            Timestamp = DateTime.UtcNow,
            DriverId = "Driver456",
            PassengerId = "Passenger123",
            DropoffLocation = "Location B",
            FareAmount = 20.50,
            PaymentStatus = "Paid",
            RideDurationMinutes = 15
        };

        var rideCompletedMessage = JsonSerializer.Serialize(rideCompleted);
        ServiceBusMessage message = new(rideCompletedMessage)
        {
            SessionId = rideId // Ensures messages for this ride are grouped
        };
        await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent: {rideCompletedMessage}");
    }
}