using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketHelper.Common.Interfaces;

namespace TicketHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly IDictionaryService _dictionaryService;

        public DictionaryController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet("stations")]
        public async Task<IActionResult> GetStations([FromQuery] string search, int? page, int? pageLimit)
        {
            return Ok(await _dictionaryService.GetStations(search, page, pageLimit));
        }

    }
}
