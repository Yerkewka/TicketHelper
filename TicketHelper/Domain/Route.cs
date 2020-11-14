using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Route
    {
        #region Public properties

        public int RouteId { get; set; }
        public string Code { get; set; }
        public int StartStationId { get; set; }
        public int EndStationId { get; set; }
        public int TrainId { get; set; }

        #endregion

        #region Navigation properties

        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
        public Train Train { get; set; }
        public ICollection<RoutesNodes> RoutesNodes { get; set; }

        #endregion
    }
}
