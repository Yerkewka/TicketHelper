using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHelper.Models;

namespace TicketHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            var graph = new Graph();

            var mappings = new Dictionary<int, string>
            {
                { 1, "A" },
                { 2, "B" },
                { 3, "C" },
                { 4, "D" },
                { 5, "E" },
                { 6, "F" },
                { 7, "G" }
            };

            foreach (var vertex in mappings)
            {
                graph.AddVertex(vertex.Key);
            }

            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 1);

            var result = new List<LinkedList<string>>();
            var allPaths = graph.FindAllPossiblePaths(1, 5);
            foreach(var path in allPaths)
            {
                result.Add(new LinkedList<string>());
                foreach (var vertex in path)
                {
                    result.Last().AddLast(mappings[vertex]);
                }
            }

            return Ok(result);
        }
    }
}
