using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHelper.Common.Interfaces;
using TicketHelper.Data;
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

            return await GetProcessResults(paths, possibleTrains);
        }

        #endregion

        #region Private functions

        private async Task<List<TrainResult>> GetTrains(int stationId)
        {
            var trainsQueryable = from r in _dataContext.Routes.Include(t => t.RoutesNodes)

                                  join t in _dataContext.Trains on r.TrainId equals t.TrainId

                                  join rn in _dataContext.RoutesNodes on r.RouteId equals rn.RouteId

                                  join n in _dataContext.Nodes on rn.NodeId equals n.NodeId
                                  where n.StartStationId == stationId

                                  select new
                                  {
                                      t.TrainId,
                                      TrainName = t.Name,
                                      TrainCode = t.Code,                                      
                                      Data = r.RoutesNodes.Select(rn => new {
                                          rn.Order,
                                          rn.Node.StartStationId,
                                          StartStationName = rn.Node.StartStation.Name,
                                          StartStationRedirect = rn.Node.StartStation.Redirect,
                                          rn.Node.EndStationId,
                                          EndStationName = rn.Node.EndStation.Name,
                                          EndStationRedirect = rn.Node.EndStation.Redirect,
                                      })
                                  };

            var trains = await trainsQueryable.ToListAsync();

            var result = new List<TrainResult>();
            foreach (var train in trains)
            {
                result.Add(new TrainResult() 
                {
                    TrainId = train.TrainId,
                    TrainName = train.TrainName,
                    TrainCode = train.TrainCode
                });

                foreach (var node in train.Data.OrderBy(n => n.Order))
                {
                    if (!result.Last().TrainPath.Contains(node.StartStationId))
                    {
                        result.Last().TrainPath.AddLast(node.StartStationId);
                        result.Last().StationNames.Add(node.StartStationId, new StationResult { StationName = node.StartStationName, IsRedirect = node.StartStationRedirect });
                    }

                    if (!result.Last().TrainPath.Contains(node.EndStationId))
                    {
                        result.Last().TrainPath.AddLast(node.EndStationId);
                        result.Last().StationNames.Add(node.EndStationId, new StationResult { StationName = node.EndStationName, IsRedirect = node.EndStationRedirect });
                    }
                }
            }

            return result;
        }

        private async Task<List<ProcessResult>> GetProcessResults(List<LinkedList<int>> paths, List<TrainResult> possibleTrains)
        {
            var results = new List<ProcessResult>();

            foreach (var path in paths)
            {
                foreach (var train in possibleTrains)
                {
                    var pathStation = path.First;
                    var trainStation = train.TrainPath.Find(path.First.Value);
                    while (trainStation.Value == pathStation.Value)
                    {
                        if (pathStation.Next?.Value != trainStation.Next?.Value)
                        {
                            results.Add(new ProcessResult
                            {
                                Trains = new LinkedList<ProcessTrainResult>()
                            });

                            results.Last().Trains.AddLast(new ProcessTrainResult 
                            { 
                                TrainName = train.TrainName,
                                TrainCode = train.TrainCode,
                                DepartureStationName = train.StationNames[path.First.Value].StationName,
                                ArrivalStationName = train.StationNames[trainStation.Value].StationName
                            });

                            if (pathStation.Next == null)
                                break;
                            
                            if (!train.StationNames[trainStation.Value].IsRedirect)
                                break;

                            // TODO: Check time and price

                            var alternatePossibleTrains = await GetTrains(trainStation.Value); // Except current train
                            var alternatePath = new LinkedList<int>();
                            alternatePath.AddLast(pathStation.Value);
                            while (pathStation.Next != null)
                            {
                                alternatePath.AddLast(pathStation.Next.Value);
                                pathStation = pathStation.Next;
                            }

                            var alternateResults = await GetProcessResults(new List<LinkedList<int>>() { alternatePath }, alternatePossibleTrains);
                            foreach (var alternateResult in alternateResults)
                            {
                                // TODO: Process prices
                                foreach (var alternameTrain in alternateResult.Trains)
                                {
                                    results.Last().Trains.AddLast(alternameTrain);
                                }
                            }                                                      
                        }

                        pathStation = pathStation.Next;
                        trainStation = trainStation.Next;
                    }                    
                }
            }

            return results;
        }

        #endregion

    }
}
