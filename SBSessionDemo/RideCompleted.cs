using System;

namespace SBSessionReceiver
{
    public class RideCompleted
    {
        public string RideId { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string DriverId { get; set; }
        public string PassengerId { get; set; }
        public string DropoffLocation { get; set; }
        public double FareAmount { get; set; }
        public string PaymentStatus { get; set; }
        public int RideDurationMinutes { get; set; }
    }
}