using System;
using System.Collections.Generic;

namespace TicketHelper.Models
{
    public class ProcessResult
    {
        public LinkedList<TrainResult> Trains { get; set; }
        public decimal Price { get; set; }
    }

    public class TrainResult
    {
        public string TrainName { get; set; }
        public string TrainCode { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
