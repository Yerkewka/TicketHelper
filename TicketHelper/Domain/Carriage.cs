using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Carriage
    {
        #region Public properties

        public int CarriageId { get; set; }
        public int TrainId { get; set; }
        public int Capacity { get; set; }

        #endregion

        #region Navigation properties

        public Train Train { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        #endregion
    }
}
