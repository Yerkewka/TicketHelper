using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHelper.Common.Interfaces;
using TicketHelper.Data;
using TicketHelper.Domain;
using TicketHelper.Models;

namespace TicketHelper.Services
{
    public class Processor : IProcessor
    {
        #region Fields

        private readonly DataContext _dataContext;

        #endregion


        #region Contructor

        public Processor(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        #region Public functions

        public async Task<List<ProcessResult>> Process(int startStationId, int endStationId, DateTime departureDate, decimal price)
        {
            var stations = await _dataContext.Stations.ToListAsync();
            var nodes = await _dataContext.Nodes.ToListAsync();

            var graph = new Graph();
            foreach (var station in stations)
            {
                graph.AddVertex(station.StationId);
            }
            foreach (var node in nodes)
            {
                graph.AddEdge(node.StartStationId, node.EndStationId);
            }

            var paths = graph.FindAllPossiblePaths(startStationId, endStationId);

            var possibleTrains = await GetTrains(startStationId);

            return new List<ProcessResult>();
        }

        #endregion

        #region Private functions

        private async Task<Dictionary<int, LinkedList<int>>> GetTrains(int startStationId)
        {
            var trainsQueryable = from r in _dataContext.Routes.Include(t => t.RoutesNodes)

                                  join t in _dataContext.Trains on r.TrainId equals t.TrainId

                                  join rn in _dataContext.RoutesNodes on r.RouteId equals rn.RouteId

                                  join n in _dataContext.Nodes on rn.NodeId equals n.NodeId
                                  where n.StartStationId == startStationId

                                  select new
                                  {
                                      t.TrainId,
                                      Data = r.RoutesNodes.Select(rn => new {
                                          rn.Order,
                                          rn.Node.StartStationId,
                                          rn.Node.EndStationId
                                      })
                         };

            var trains = await trainsQueryable.ToListAsync();

            var result = new Dictionary<int, LinkedList<int>>();
            foreach (var train in trains)
            {
                result.Add(train.TrainId, new LinkedList<int>());
                foreach (var node in train.Data.OrderBy(n => n.Order))
                {
                    if (!result.Last().Value.Contains(node.StartStationId))
                    {
                        result.Last().Value.AddLast(node.StartStationId);
                    }
                    
                    if (!result.Last().Value.Contains(node.EndStationId))
                    {
                        result.Last().Value.AddLast(node.EndStationId);
                    }
                }
            }

            return result;
        }

        #endregion

    }
}
