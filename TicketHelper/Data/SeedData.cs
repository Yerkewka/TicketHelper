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
                    #region Stations
                    var stations = new List<Station>()
                    {
                        #region Station A
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
#endregion

                        #region Station B
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
#endregion

                        #region Station E
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
#endregion

                        #region Station ZH
                        new Station
                        {
                            Name = "Жезказган",
                            ShortName = "ZHKG",
                            Redirect = true
                        },
#endregion

                        #region Station K
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
#endregion

                        #region Station M
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
#endregion

                        #region Station N
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
#endregion

                        #region Station O
                        new Station
                        {
                            Name = "Оскемен-1",
                            ShortName = "OSKM1",
                            Redirect = true
                        },
#endregion

                        #region Station P
                        new Station
                        {
                            Name = "Павлодар",
                            ShortName = "PVLD",
                            Redirect = true
                        },
                        new Station
                        {
                            Name = "Петропавловск",
                            ShortName = "PTRP",
                            Redirect = true
                        },
#endregion

                        #region Station R
                        new Station
                        {
                            Name = "Риддер",
                            ShortName = "RDDR",
                            Redirect = false
                        },
#endregion

                        #region Station S
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
                        #endregion

                        #region Station T
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
#endregion

                        #region Station U
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
#endregion

                        #region Station SH
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
                        }
#endregion
                    };
#endregion

                    dataContext.Stations.AddRange(stations);
                    await dataContext.SaveChangesAsync();

                    if (!dataContext.Nodes.Any())
                    {
                        var nodes = new List<Node>()
                        {
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SMEY"),//Semey-Aktogai
                                EndStation = stations.First(s => s.ShortName == "AKTG")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKTG"),//Aktogai-Ushtobe
                                EndStation = stations.First(s => s.ShortName == "USTB")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "USTB"),//Ushtobe-SaryOzek
                                EndStation = stations.First(s => s.ShortName == "SROZ")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SROZ"),//SaryOzek-Almaty1
                                EndStation = stations.First(s => s.ShortName == "ALMT1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "ALMT1"),//Almaty1-Shu
                                EndStation = stations.First(s => s.ShortName == "SHUV")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SHUV"),//Shu-Taraz
                                EndStation = stations.First(s => s.ShortName == "TRAZ")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "TRAZ"),//Taraz-Shymkent
                                EndStation = stations.First(s => s.ShortName == "SHYM")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SHYM"),//Shymkent-Turkistan
                                EndStation = stations.First(s => s.ShortName == "TRKS")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "TRKS"),//Turkistan-Kyzylorda
                                EndStation = stations.First(s => s.ShortName == "KZLD")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "PTRP"),//Petropavlovsk-Kokshetau1
                                EndStation = stations.First(s => s.ShortName == "KKST1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KKST1"),//Kokshetau1-Borovoje
                                EndStation = stations.First(s => s.ShortName == "BRVE")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "BRVE"),//Borovoje-Makinka
                                EndStation = stations.First(s => s.ShortName == "MKNK")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "MKNK"),//Makinka-NurSultan
                                EndStation = stations.First(s => s.ShortName == "NRST")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "NRST"),//NurSultan-Karaganda
                                EndStation = stations.First(s => s.ShortName == "KRGD")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KRGD"),//Karaganda-Akadyr
                                EndStation = stations.First(s => s.ShortName == "AKDR")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKDR"),//Akadyr-Shu
                                EndStation = stations.First(s => s.ShortName == "SHUV")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "ALMT2"),//Almaty2-Almaty1
                                EndStation = stations.First(s => s.ShortName == "ALMT1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KZLD"),//Kyzylorda-Kazaly
                                EndStation = stations.First(s => s.ShortName == "KZLY")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KZLY"),//Kazaly-Kandyagash
                                EndStation = stations.First(s => s.ShortName == "KDGS")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KDGS"),//Kandyagash-Aktobe
                                EndStation = stations.First(s => s.ShortName == "AKTB")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKTB"),//Aktobe-Kazakhstan
                                EndStation = stations.First(s => s.ShortName == "KZST")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KZST"),//Kazakhstan-Uralsk
                                EndStation = stations.First(s => s.ShortName == "URLS")
                            },

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
/*                       
                            new Train
                            {
                                Code = "076Ц",
                                Name = "Петропавловск-Кызылорда"
                            };
                            new Train
                            {
                                Code = "379Т",
                                Name = "Алматы2-Уральск"
                            };
*/
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

/*
                                new Route
                                {
                                    Code = "076Ц-R",
                                    StartStation = stations.First(s => s.ShortName == "PTRP"),
                                    EndStation = stations.First(s => s.ShortName == "KZLD"),
                                    Train = train
                                };
                                new Route
                                {
                                    Code = "379Т-R",
                                    StartStation = stations.First(s => s.ShortName == "ALMT2"),
                                    EndStation = stations.First(s => s.ShortName == "URLS"),
                                    Train = train
                                };
*/

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
