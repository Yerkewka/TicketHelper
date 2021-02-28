using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketHelper.Common.Interfaces;

namespace TicketHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessor _processor;

        public ProcessController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<IActionResult> Process([FromQuery] int startStationId, int endStationId, DateTime departureDate, decimal price)
        {
            return Ok(await _processor.Process(startStationId, endStationId, departureDate.Date, price));
        }
    }
}
