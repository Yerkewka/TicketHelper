namespace TicketHelper.Domain
{
    public class Ticket
    {
        #region Public properties

        public int TicketId { get; set; }
        public int ScheduleId { get; set; }
        public int CarriageId { get; set; }

        #endregion

        #region Navigation properties

        public Carriage Carriage { get; set; }
        public Schedule Schedule { get; set; }

        #endregion
    }
}