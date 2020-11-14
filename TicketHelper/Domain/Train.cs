namespace TicketHelper.Domain
{
    public class Train
    {
        #region Public properties

        public int TrainId { get; set; }
        public int RouteId { get; set; }
        public string Code { get; set; }

        #endregion

        #region Navigation properties

        public Route Route { get; set; }

        #endregion
    }
}
