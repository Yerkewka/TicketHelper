using System.Collections.Generic;
using System.Threading.Tasks;
using TicketHelper.Models;

namespace TicketHelper.Common.Interfaces
{
    public interface IDictionaryService
    {
        Task<List<DictionaryResult>> GetStations(string search, int? page, int? pageLimit);
    }
}
