using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            var possibleTrains = await GetTrains(startStationId, departureDate);

            return await GetProcessResults(paths, possibleTrains);
        }

        #endregion

        #region Private functions

        private async Task<List<TrainResult>> GetTrains(int stationId, DateTime departureDate, int[] excludedTrains = null)
        {
            if (excludedTrains == null)
                excludedTrains = new int[0];

            var trainsQueryable = from r in _dataContext.Routes.Include(t => t.RoutesNodes)

                                  join t in _dataContext.Trains on r.TrainId equals t.TrainId
                                  where !excludedTrains.Contains(t.TrainId)

                                  join rn in _dataContext.RoutesNodes on r.RouteId equals rn.RouteId

                                  join n in _dataContext.Nodes on rn.NodeId equals n.NodeId
                                  where n.StartStationId == stationId

                                  join s in _dataContext.Schedule on t.TrainId equals s.TrainId
                                  where s.DepartureDate.HasValue && s.DepartureDate.Value.Date == departureDate.Date && s.DepartureDate.Value > departureDate && s.StationId == stationId

                                  select new
                                  {
                                      t.TrainId,
                                      TrainName = t.Name,
                                      TrainCode = t.Code,                                      
                                      Data = r.RoutesNodes.Select(rn => new {
                                          rn.Order,
                                          rn.Node.StartStationId,
                                          StartStationName = rn.Node.StartStation.Name,
                                          StartStationDepartureDate = rn.Node.StartStation.Schedule.First(ss => ss.TrainId == t.TrainId && ss.Date == s.Date).DepartureDate,
                                          StartStationArrivalDate = rn.Node.StartStation.Schedule.First(ss => ss.TrainId == t.TrainId && ss.Date == s.Date).ArrivalDate,
                                          StartStationRedirect = rn.Node.StartStation.Redirect,
                                          rn.Node.EndStationId,
                                          EndStationName = rn.Node.EndStation.Name,
                                          EndStationDepartureDate = rn.Node.EndStation.Schedule.First(ss => ss.TrainId == t.TrainId && ss.Date == s.Date).DepartureDate,
                                          EndStationArrivalDate = rn.Node.EndStation.Schedule.First(ss => ss.TrainId == t.TrainId && ss.Date == s.Date).ArrivalDate,
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
                        result.Last().StationNames.Add(node.StartStationId, new StationResult { 
                            StationName = node.StartStationName, 
                            ArrivalDate = node.StartStationArrivalDate,
                            DepartureDate = node.StartStationDepartureDate,
                            IsRedirect = node.StartStationRedirect 
                        });
                    }

                    if (!result.Last().TrainPath.Contains(node.EndStationId))
                    {
                        result.Last().TrainPath.AddLast(node.EndStationId);
                        result.Last().StationNames.Add(node.EndStationId, new StationResult { 
                            StationName = node.EndStationName,
                            ArrivalDate = node.EndStationArrivalDate,
                            DepartureDate = node.EndStationDepartureDate,
                            IsRedirect = node.EndStationRedirect 
                        });
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
                    while (trainStation != null && pathStation != null && trainStation.Value == pathStation.Value)
                    {
                        if (pathStation.Next?.Value == null || trainStation.Next?.Value == null || pathStation.Next?.Value != trainStation.Next?.Value)
                        {
                            var possibleResult = new ProcessResult
                            {
                                Trains = new LinkedList<ProcessTrainResult>()
                            };

                            possibleResult.Trains.AddLast(new ProcessTrainResult 
                            { 
                                TrainName = train.TrainName,
                                TrainCode = train.TrainCode,
                                DepartureStationName = train.StationNames[path.First.Value].StationName,
                                DepartureStationDepartureDate = train.StationNames[path.First.Value].DepartureDate,
                                DepartureStationArrivalDate = train.StationNames[path.First.Value].ArrivalDate,
                                ArrivalStationName = train.StationNames[trainStation.Value].StationName,
                                ArrivalStationDepartureDate = train.StationNames[trainStation.Value].DepartureDate,
                                ArrivalStationArrivalDate = train.StationNames[trainStation.Value].ArrivalDate
                            });

                            if (pathStation.Next == null)
                            {
                                results.Add(possibleResult);
                                break;
                            }
                            
                            if (!train.StationNames[trainStation.Value].IsRedirect)
                                break;

                            // TODO: Check time and price

                            // TODO: Apply correct date
                            var arrivalDate = train.StationNames[trainStation.Value].ArrivalDate.Value;
                            for (var date = arrivalDate; date <= arrivalDate.AddDays(1); date = date.Date.AddDays(1))
                            {
                                var alternatePossibleTrains = await GetTrains(trainStation.Value, date, new int[] { train.TrainId });
                                if (!alternatePossibleTrains.Any())
                                    continue;

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
                                    var serialized = JsonConvert.SerializeObject(possibleResult);
                                    var possibleResultCopy =  JsonConvert.DeserializeObject<ProcessResult>(serialized);

                                    // TODO: Process prices
                                    foreach (var alternameTrain in alternateResult.Trains)
                                    {
                                        possibleResultCopy.Trains.AddLast(alternameTrain);
                                    }

                                    results.Add(possibleResultCopy);
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
