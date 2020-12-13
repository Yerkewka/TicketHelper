Insert into Stations (StationId, Name, ShortName, Redirect) values ('121',N'Петропавловск','PTRP','1')
Insert into Nodes (NodeId, StartStationId,	EndStationId) values 
(1005,121,102),
(1006,102,104),
(1007,104,106),
(1008,106,99),
(1009,99,98),
(1010,98,81),
(1011,81,119)