using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Node
    {
        #region Public properties

        public int NodeId { get; set; }
        public int StartStationId { get; set; }
        public int EndStationId { get; set; }
        public int? BackNodeId { get; set; }
        public float? Distance { get; set; }

        #endregion

        #region Navigation properties

        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
        public ICollection<RoutesNodes> RoutesNodes { get; set; }

        #endregion
    }
}
