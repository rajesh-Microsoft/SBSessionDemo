using System;

namespace SBSessionReceiver
{
    public class DriverAssigned
    {
        public string RideId { get; set; }
        public string Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public double DriverRating { get; set; }
        public string Vehicle { get; set; }
        public string VehicleNumber { get; set; }
        public int EtaMinutes { get; set; }
    }
}