using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketHelper.Models;

namespace TicketHelper.Common.Interfaces
{
    public interface IProcessor
    {
        Task<List<ProcessResult>> Process(int startStationId, int endStationId, DateTime departureDate, decimal price);
    }
}
