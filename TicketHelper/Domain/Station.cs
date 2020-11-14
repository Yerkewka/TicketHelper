using System.Collections;
using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Station
    {
        #region Public properties

        public int StationId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool Redirect { get; set; }

        #endregion

        #region Navigation properties

        public ICollection<Node> AsStartStationNodes { get; set; }
        public ICollection<Node> AsEndStationNodes { get; set; }

        public ICollection<Route> AsStartStationRoutes { get; set; }
        public ICollection<Route> AsEndStationRoutes { get; set; }

        #endregion
    }
}
