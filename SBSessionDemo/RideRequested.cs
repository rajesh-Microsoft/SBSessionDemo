namespace SBSessionReceiver
{
    public class RideRequested
{
    public string RideId { get; set; }
    public string Status { get; set; }
    public DateTime Timestamp { get; set; }
    public string PassengerId { get; set; }
    public string PickupLocation { get; set; }
    public string DropoffLocation { get; set; }
    public string PaymentMethod { get; set; }
}
}
// This class represents a ride request in the system. It contains properties such as RideId, Status, Timestamp, PassengerId, PickupLocation, DropoffLocation, and PaymentMethod.
