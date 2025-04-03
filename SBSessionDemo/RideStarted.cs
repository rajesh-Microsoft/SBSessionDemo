using System;

namespace SBSessionReceiver
{
    public class RideStarted
    {
        public string RideId { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string DriverId { get; set; }
        public string PassengerId { get; set; }
        public string PickupLocation { get; set; }
    }
}