using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHelper.Domain;

namespace TicketHelper.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext dataContext)
        {
            var transaction = await dataContext.Database.BeginTransactionAsync();

            try
            {
                if (!dataContext.Stations.Any())
                {
                    var stations = new List<Station>()
                    {
                        new Station
                        {
                            Name = "Акадыр",
                            ShortName = "AKDR",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Актобе",
                            ShortName = "AKTB",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Актогай",
                            ShortName = "AKTG",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Актогай-Восточный",
                            ShortName = "AKTGV",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Алматы-1",
                            ShortName = "ALMT1",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Алматы-2",
                            ShortName = "ALMT2",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Аркалык",
                            ShortName = "ARKL",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Атбасар-1",
                            ShortName = "ATBS",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Атырау",
                            ShortName = "ATRU",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Балхаш-1",
                            ShortName = "BLQS1",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Балхаш-2",
                            ShortName = "BLQS2",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Екибастуз-1",
                            ShortName = "EKBS1",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Ерейментау",
                            ShortName = "ERMT",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Жезказган",
                            ShortName = "ZHKG",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Казахстан",
                            ShortName = "KZST",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Казалы",
                            ShortName = "KZLY",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Кандыагаш",
                            ShortName = "KDGS",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Карабас",
                            ShortName = "KRBS",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Караганды-Пасс.",
                            ShortName = "KRGD",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Кокшетау 2",
                            ShortName = "KKST2",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Кокшетау 1",
                            ShortName = "KKST1",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Курорт-Боровое",
                            ShortName = "BRVE",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Кызылорда",
                            ShortName = "KZLD",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Макинка",
                            ShortName = "MKNK",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Мангистау",
                            ShortName = "MNGT",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Нур-Султан (старый вокзал)",
                            ShortName = "NRST",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Нур-Султан (Нурлы Жол)",
                            ShortName = "NRLZ",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Оскемен-1",
                            ShortName = "OSKM1",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Павлодар",
                            ShortName = "PVLD",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Риддер",
                            ShortName = "RDDR",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Сары-Озек",
                            ShortName = "SROZ",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Семей",
                            ShortName = "SMEY",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Тараз",
                            ShortName = "TRAZ",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Темиртау",
                            ShortName = "TMRT",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Туркестан",
                            ShortName = "TRKS",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Уральск",
                            ShortName = "URLS",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Усть-Каменогорск",
                            ShortName = "USKM",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Уштобе",
                            ShortName = "USTB",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Шу",
                            ShortName = "SHUV",
                            Redirect = false
                        },
                        new Station
                        {
                            Name = "Шымкент",
                            ShortName = "SHYM",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Петропавловск",
                            ShortName = "PTRP",
                            Redirect = true
                        }
                    };

                    dataContext.Stations.AddRange(stations);
                    await dataContext.SaveChangesAsync();

                    if (!dataContext.Nodes.Any())
                    {
                        var nodes = new List<Node>()
                        {
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SMEY"),
                                EndStation = stations.First(s => s.ShortName == "AKTG")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKTG"),
                                EndStation = stations.First(s => s.ShortName == "USTB")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "USTB"),
                                EndStation = stations.First(s => s.ShortName == "SROZ")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SROZ"),
                                EndStation = stations.First(s => s.ShortName == "ALMT1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "ALMT1"),
                                EndStation = stations.First(s => s.ShortName == "SHUV")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SHUV"),
                                EndStation = stations.First(s => s.ShortName == "TRAZ")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "TRAZ"),
                                EndStation = stations.First(s => s.ShortName == "SHYM")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SHYM"),
                                EndStation = stations.First(s => s.ShortName == "TRKS")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "TRKS"),
                                EndStation = stations.First(s => s.ShortName == "KZLD")
                            }
                        };

                        dataContext.Nodes.AddRange(nodes);
                        await dataContext.SaveChangesAsync();

                        if (!dataContext.Trains.Any())
                        {
                            var train = new Train
                            {
                                Code = "021Ц",
                                Name = "Семей-Кызылорда"
                            };

                            dataContext.Trains.Add(train);
                            await dataContext.SaveChangesAsync();

                            if (!dataContext.Routes.Any())
                            {
                                var route = new Route
                                {
                                    Code = "021Ц-R",
                                    StartStation = stations.First(s => s.ShortName == "SMEY"),
                                    EndStation = stations.First(s => s.ShortName == "KZLD"),
                                    Train = train
                                };

                                dataContext.Routes.Add(route);
                                await dataContext.SaveChangesAsync();

                                if (!dataContext.RoutesNodes.Any())
                                {
                                    var routesNodes = new List<RoutesNodes>();
                                    foreach (var item in nodes.Select((node, index) => new { index, node }))
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = item.node,
                                            Route = route,
                                            Order = item.index + 1
                                        });
                                    }

                                    dataContext.RoutesNodes.AddRange(routesNodes);
                                    await dataContext.SaveChangesAsync();
                                }
                            }
                        }
                    }                    
                }

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await transaction.RollbackAsync();
            }
        }
    }
}
