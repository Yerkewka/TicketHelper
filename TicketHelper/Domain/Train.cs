﻿using System.Collections.Generic;

namespace TicketHelper.Domain
{
    public class Train
    {
        #region Public properties

        public int TrainId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        public Route Route { get; set; }
        public ICollection<Schedule> Schedule { get; set; }
        public ICollection<Carriage> Carriages { get; set; }
        public ICollection<TrainPrice> TrainPrices { get; set; }

        #endregion
    }
}
