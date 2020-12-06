using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Train
    {
        #region Public properties

        public int TrainId { get; set; }
        public string Code { get; set; }

        #endregion

        #region Navigation properties

        public Route Route { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<Carriage> Carriages { get; set; }

        #endregion
    }
}
