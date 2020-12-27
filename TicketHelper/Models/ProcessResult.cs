using System;
using System.Collections.Generic;

namespace TicketHelper.Models
{
    public class ProcessResult
    {
        public LinkedList<ProcessTrainResult> Trains { get; set; }
        public decimal Price { get; set; }
    }

    public class ProcessTrainResult
    {
        public string TrainName { get; set; }
        public string TrainCode { get; set; }

        public DateTime DepartureTime { get; set; }
        public string DepartureStationName { get; set; }

        public DateTime ArrivalDate { get; set; }
        public string ArrivalStationName { get; set; }
    }
}
