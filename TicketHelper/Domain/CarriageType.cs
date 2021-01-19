using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class CarriageType
    {
        #region Public properties

        public int CarriageTypeId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        public ICollection<Carriage> Carriages { get; set; }

        public ICollection<TrainPrice> TrainPrices { get; set; }

        #endregion
    }
}
