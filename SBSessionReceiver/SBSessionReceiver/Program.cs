using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

class Program
{
    private const string connectionString = "";
    private const string queueName = "sessiontest";

    static async Task Main()
    {
        await ReceiveRideUpdates();
    }

    static async Task ReceiveRideUpdates()
    {
        await using var client = new ServiceBusClient(connectionString);
        
        // Accept a session dynamically (any available session)
        ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(queueName);

        Console.WriteLine($"Processing session: {receiver.SessionId}");

        var messages = await receiver.ReceiveMessagesAsync(maxMessages: 10);
        foreach (ServiceBusReceivedMessage message in messages)
        {
            string body = message.Body.ToString();
            Console.WriteLine($"Processing: {body}");

            await receiver.CompleteMessageAsync(message); // Mark message as processed
        }
    }
}
