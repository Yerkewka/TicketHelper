using System;
using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Schedule
    {
        #region Public properties

        public int ScheduleId { get; set; }
        public int TrainId { get; set; }
        public int StationId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }

        #endregion

        #region Navigation properties

        public Train Train { get; set; }
        public Station Station { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        #endregion
    }
}
