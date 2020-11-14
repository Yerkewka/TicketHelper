namespace TicketHelper.Domain
{
    public class RoutesNodes
    {
        #region Public properties

        public int RoutesNodesId { get; set; }
        public int RouteId { get; set; }
        public int NodeId { get; set; }

        #endregion

        #region Navigation properties

        public Route Route { get; set; }
        public Node Node { get; set; }

        #endregion
    }
}
