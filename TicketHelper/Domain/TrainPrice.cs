namespace TicketHelper.Domain
{
    public class TrainPrice
    {
        #region Public properties

        public int TrainId { get; set; }
        public int StartStationId { get; set; }
        public int EndStationId { get; set; }
        public int CarriageTypeId { get; set; }
        public decimal Price { get; set; }

        #endregion

        #region Navigation properties

        public Train Train { get; set; }
        public Station StartStation { get; set; }
        public Station EndStation { get; set; }
        public CarriageType CarriageType { get; set; }

        #endregion
    }
}
