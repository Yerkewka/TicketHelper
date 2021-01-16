using System;
using System.Collections.Generic;

namespace TicketHelper.Models
{
    public class TrainResult
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string TrainCode { get; set; }
        public LinkedList<int> TrainPath { get; set; } = new LinkedList<int>();
        public Dictionary<int, StationResult> StationNames { get; set; } = new Dictionary<int, StationResult>();
    }

    public class StationResult
    {
        public string StationName { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public bool IsRedirect { get; set; }
    }
}
