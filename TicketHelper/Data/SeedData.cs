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
                        }, // 0
                        new Station
                        {
                            Name = "Актобе",
                            ShortName = "AKTB",
                            Redirect = true
                        }, // 1
                        new Station
                        {
                            Name = "Актогай",
                            ShortName = "AKTG",
                            Redirect = false
                        }, // 2
                        new Station
                        {
                            Name = "Актогай-Восточный",
                            ShortName = "AKTGV",
                            Redirect = false
                        }, // 3
                        new Station
                        {
                            Name = "Алматы-1",
                            ShortName = "ALMT1",
                            Redirect = true
                        }, // 4
                        new Station
                        {
                            Name = "Алматы-2",
                            ShortName = "ALMT2",
                            Redirect = true
                        }, // 5
                        new Station
                        {
                            Name = "Аркалык",
                            ShortName = "ARKL",
                            Redirect = false
                        }, // 5
                        new Station
                        {
                            Name = "Атбасар-1",
                            ShortName = "ATBS",
                            Redirect = false
                        }, // 6
                        new Station
                        {
                            Name = "Атырау",
                            ShortName = "ATRU",
                            Redirect = true
                        }, // 7
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

                    #region Nodes
                    if (!dataContext.Nodes.Any())
                    {
                        var nodes = new List<Node>()
                        {
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SMEY"),//Semey-Aktogai 0
                                EndStation = stations.First(s => s.ShortName == "AKTG")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKTG"),//Aktogai-Ushtobe 1
                                EndStation = stations.First(s => s.ShortName == "USTB")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "USTB"),//Ushtobe-SaryOzek 2
                                EndStation = stations.First(s => s.ShortName == "SROZ")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SROZ"),//SaryOzek-Almaty1 3
                                EndStation = stations.First(s => s.ShortName == "ALMT1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "ALMT1"),//Almaty1-Shu 4
                                EndStation = stations.First(s => s.ShortName == "SHUV")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SHUV"),//Shu-Taraz 5
                                EndStation = stations.First(s => s.ShortName == "TRAZ")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "TRAZ"),//Taraz-Shymkent 6
                                EndStation = stations.First(s => s.ShortName == "SHYM")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SHYM"),//Shymkent-Turkistan 7
                                EndStation = stations.First(s => s.ShortName == "TRKS")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "TRKS"),//Turkistan-Kyzylorda 8
                                EndStation = stations.First(s => s.ShortName == "KZLD")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "PTRP"),//Petropavlovsk-Kokshetau1 9
                                EndStation = stations.First(s => s.ShortName == "KKST1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KKST1"),//Kokshetau1-Borovoje 10
                                EndStation = stations.First(s => s.ShortName == "BRVE")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "BRVE"),//Borovoje-Makinka 11
                                EndStation = stations.First(s => s.ShortName == "MKNK")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "MKNK"),//Makinka-NurSultan 12
                                EndStation = stations.First(s => s.ShortName == "NRST")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "NRST"),//NurSultan-Karaganda 13
                                EndStation = stations.First(s => s.ShortName == "KRGD")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KRGD"),//Karaganda-Akadyr 14
                                EndStation = stations.First(s => s.ShortName == "AKDR")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKDR"),//Akadyr-Shu 15
                                EndStation = stations.First(s => s.ShortName == "SHUV")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "ALMT2"),//Almaty2-Almaty1 16
                                EndStation = stations.First(s => s.ShortName == "ALMT1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KZLD"),//Kyzylorda-Kazaly 17
                                EndStation = stations.First(s => s.ShortName == "KZLY")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KZLY"),//Kazaly-Kandyagash 18
                                EndStation = stations.First(s => s.ShortName == "KDGS")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KDGS"),//Kandyagash-Aktobe 19
                                EndStation = stations.First(s => s.ShortName == "AKTB")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "AKTB"),//Aktobe-Kazakhstan 20
                                EndStation = stations.First(s => s.ShortName == "KZST")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "KZST"),//Kazakhstan-Uralsk 21
                                EndStation = stations.First(s => s.ShortName == "URLS")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "SMEY"),//Semey-Pavlodar 22
                                EndStation = stations.First(s => s.ShortName == "PVLD")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "PVLD"),//Pavlodar-Ekibastuz1 23
                                EndStation = stations.First(s => s.ShortName == "EKBS1")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "EKBS1"),//Ekibastuz1-Ereimentau 24
                                EndStation = stations.First(s => s.ShortName == "ERMT")
                            },
                            new Node
                            {
                                StartStation = stations.First(s => s.ShortName == "ERMT"),//Ereimentau-NurSultan NurlyZhol 25
                                EndStation = stations.First(s => s.ShortName == "NRLZ")
                            }
                        };
                        #endregion

                        dataContext.Nodes.AddRange(nodes);
                        await dataContext.SaveChangesAsync();

                    #region Trains

                        if (!dataContext.Trains.Any())
                        {
                            #region Trains List
                            var trains = new List<Train>()
                            {
                                new Train {
                                    Code = "021Ц",
                                    Name = "Семей-Кызылорда"
                                },
                                new Train
                                {
                                    Code = "076Ц",
                                    Name = "Петропавловск-Кызылорда"
                                },
                                new Train
                                {
                                    Code = "379Т",
                                    Name = "Алматы2-Уральск"
                                },
                                new Train
                                {
                                    Code = "353Ц",
                                    Name = "Семей — Нур-Султан"
                                }
                            };
                            #endregion

                            dataContext.Trains.AddRange(trains);
                            await dataContext.SaveChangesAsync();

                            #region Routes for trains

                            if (!dataContext.Routes.Any())
                            {
                                var routes = new List<Route>()
                                {
                                    new Route
                                    {
                                        Code = "021Ц-R",
                                        StartStation = stations.First(s => s.ShortName == "SMEY"),
                                        EndStation = stations.First(s => s.ShortName == "KZLD"),
                                        Train = trains[0]
                                    },
                                    new Route
                                    {
                                        Code = "076Ц-R",
                                        StartStation = stations.First(s => s.ShortName == "PTRP"),
                                        EndStation = stations.First(s => s.ShortName == "KZLD"),
                                        Train = trains[1]
                                    },
                                    new Route
                                    {
                                        Code = "379Т-R",
                                        StartStation = stations.First(s => s.ShortName == "ALMT2"),
                                        EndStation = stations.First(s => s.ShortName == "URLS"),
                                        Train = trains[2]
                                    },
                                    new Route
                                    {
                                        Code = "353Ц-R",
                                        StartStation = stations.First(s => s.ShortName == "SMEY"),
                                        EndStation = stations.First(s => s.ShortName == "NRLZ"),
                                        Train = trains[3]
                                    }
                                };

                                dataContext.Routes.AddRange(routes);
                                await dataContext.SaveChangesAsync();

                                if (!dataContext.RoutesNodes.Any())
                                   {
                                    var routesNodes = new List<RoutesNodes>();

                                    #region RouteNodes

                                    #region Semey - Kyzylorda (Route)

                                    int lastOrderNumber = 0;
                                    for (int i = 0; i <= 8; i++)
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = nodes[i],
                                            Route = routes[0],
                                            Order = ++lastOrderNumber
                                        });
                                    }

                                    #endregion

                                    #region Petropavlovsk - Kyzylorda (Route)

                                    lastOrderNumber = 0;
                                    for (int i = 9; i <= 15; i++)
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = nodes[i],
                                            Route = routes[1],
                                            Order = ++lastOrderNumber
                                        });
                                    }

                                    for (int i = 5; i <= 8; i++)
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = nodes[i],
                                            Route = routes[1],
                                            Order = ++lastOrderNumber
                                        });
                                    }

                                    #endregion

                                    #region Almaty - Uralsk (Route)

                                    lastOrderNumber = 0;
                                    routesNodes.Add(new RoutesNodes
                                    {
                                        Node = nodes[16],
                                        Route = routes[2],
                                        Order = ++lastOrderNumber
                                    });

                                    for (int i = 4; i <= 8; i++)
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = nodes[i],
                                            Route = routes[2],
                                            Order = ++lastOrderNumber
                                        });
                                    }

                                    for (int i = 17; i <= 21; i++)
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = nodes[i],
                                            Route = routes[2],
                                            Order = ++lastOrderNumber
                                        });
                                    }

                                    #endregion

                                    #region Semey - NurSultan (Route)

                                    lastOrderNumber = 0;

                                    for (int i = 22; i <= 25; i++)
                                    {
                                        routesNodes.Add(new RoutesNodes
                                        {
                                            Node = nodes[i],
                                            Route = routes[0],
                                            Order = ++lastOrderNumber
                                        });
                                    }

                                    #endregion

                                    #endregion

                                    dataContext.RoutesNodes.AddRange(routesNodes);
                                    await dataContext.SaveChangesAsync();
                                }

                                #region Arrival dates
                                if (!dataContext.Schedule.Any())
                                {
                                    var utcNow = DateTime.UtcNow;

                                    var schedules = new List<Schedule>();

                                    for (int i = 0; i <= 30; i++)
                                    {
                                        var utcNowShifted = utcNow.AddDays(i);

                                        #region Semey - Kyzylorda 021Ц (D) 

                                        schedules.AddRange(new List<Schedule>() {

                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SMEY"),
                                                    ArrivalDate = null,
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 13, 10, 0),
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "AKTG"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 22, 55, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 23, 25, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "USTB"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 4, 1, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 4, 16, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SROZ"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 6, 21, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 6, 36, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "ALMT1"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 10, 12, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 10, 43, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SHUV"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 15, 26, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 15, 46, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "TRAZ"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 19, 19, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 19, 39, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SHYM"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 23, 28, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 23, 43, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "TRKS"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 3, 4, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 3, 23, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[0],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KZLD"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 6, 36, 0),
                                                    DepartureDate = null
                                                }
                                            });

                                        #endregion

                                        #region Petropavlovsk - Kyzylorda 379Т (D)

                                        if (utcNowShifted.Day % 2 != 0)
                                        {
                                            schedules.AddRange(new List<Schedule>() {

                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "PTRP"),
                                                    ArrivalDate = null,
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 17, 46, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KKST1"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 20, 58, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 21, 18, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "BRVE"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 22, 20, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 22, 30, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "MKNK"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 20, 58, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 21, 18, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "NRST"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 1, 50, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 2, 18, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KRGD"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 5, 56, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 6, 18, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KRBS"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 6, 41, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 7, 11, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "AKDR"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 9, 18, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 9, 33, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SHUV"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 17, 17, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 17, 37, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "TRAZ"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 21, 10, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 21, 30, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SHYM"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 1, 26, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 1, 44, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "TRKS"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 5, 5, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 5, 25, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[1],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KZLD"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 11, 10, 0),
                                                    DepartureDate = null
                                                }

                                            });
                                        }

                                        #endregion

                                        #region Almaty - Uralsk 379Т (D) 

                                        if (utcNowShifted.DayOfWeek == DayOfWeek.Tuesday || utcNowShifted.DayOfWeek == DayOfWeek.Friday)
                                        {
                                            schedules.AddRange(new List<Schedule>() {

                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "ALMT2"),
                                                    ArrivalDate = null,
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 21, 50, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "ALMT1"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 22, 13, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 22, 33, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SHUV"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 5, 8, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 5, 28, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "TRAZ"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 9, 26, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 9, 46, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SHYM"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 14, 37, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 15, 07, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "TRKS"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 18, 43, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 19, 00, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KZLD"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 1, 4, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 1, 34, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KZLY"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 7, 7, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 7, 27, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KDGS"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 20, 10, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 20, 38, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "AKTB"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 22, 04, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(2).Day, 22, 34, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "KZST"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(3).Day, 7, 18, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(3).Day, 7, 47, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[2],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "URLS"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(3).Day, 10, 01, 0),
                                                    DepartureDate = null
                                                }
                                            });
                                        }

                                        #endregion

                                        #region Semey - Nur Sultan 353Ц (D) 
                                        schedules.AddRange(new List<Schedule>() {

                                                new Schedule
                                                {
                                                    Train = trains[3],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "SMEY"),
                                                    ArrivalDate = null,
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 12, 05, 0),
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[3],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "PVLD"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 20, 38, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 21, 23, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[3],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "EKBS1"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.Day, 23, 46, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 0, 6, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[3],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "ERMT"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 3, 17, 0),
                                                    DepartureDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 3, 30, 0)
                                                },
                                                new Schedule
                                                {
                                                    Train = trains[3],
                                                    Date = utcNowShifted.Date,
                                                    Station = stations.First(s => s.ShortName == "NRLZ"),
                                                    ArrivalDate = new DateTime(utcNowShifted.Year, utcNowShifted.Month, utcNowShifted.AddDays(1).Day, 5, 50, 0),
                                                    DepartureDate = null
                                                }
                                            });

                                        #endregion

                                    }

                                    dataContext.Schedule.AddRange(schedules);
                                    await dataContext.SaveChangesAsync();

                                    #endregion
                                }


                            }
                        }

                        #endregion

                    }

                    #endregion

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
