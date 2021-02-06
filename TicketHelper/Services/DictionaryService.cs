using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHelper.Common.Interfaces;
using TicketHelper.Data;
using TicketHelper.Models;

namespace TicketHelper.Services
{
    public class DictionaryService : IDictionaryService
    {
        #region Fields

        private readonly DataContext _dataContext;

        #endregion

        #region Constructor

        public DictionaryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        #region Public functions

        public async Task<List<DictionaryResult>> GetStations(string search, int? page, int? pageLimit)
        {
            var stationsQueryable = _dataContext.Stations.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                stationsQueryable = stationsQueryable.Where(s => s.Name.Contains(search));
            }

            stationsQueryable = stationsQueryable.OrderBy(s => s.Name);

            if (page.HasValue && pageLimit.HasValue)
            {
                stationsQueryable = stationsQueryable
                    .Skip((page.Value - 1) * pageLimit.Value)
                    .Take(pageLimit.Value);
            }

            var stationsResultQueryable = stationsQueryable.Select(s => new DictionaryResult
            {
                Id = s.StationId,
                Name = s.Name
            });

            return await stationsResultQueryable.ToListAsync();
        }

        #endregion
    }
}
