using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Process(int startStationId, int endStationId, DateTime departureDate)
        {
            return Ok(await _processor.Process(startStationId, endStationId, departureDate, 2000));
        }
    }
}
