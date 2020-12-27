/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) *
  FROM [TicketHelper].[dbo].[Stations]

  SELECT TOP (1000) *
  FROM [TicketHelper].[dbo].[Nodes]

    SELECT TOP (1000) *
  FROM [TicketHelper].[dbo].[Trains]

      SELECT TOP (1000) *
  FROM [TicketHelper].[dbo].[Routes]


  --Insert into Trains (Code) values (N'021Ö')
  --Insert into Routes (Code, StartStationId, EndStationId, TrainId) values (N'021Ö-R',112,103,1)

  Select * from Nodes n
  inner join Stations s1 on n.StartStationId = s1.StationId
  inner join Stations s2 on n.EndStationId = s2.StationId

  --Insert into nodes (StartStationId, EndStationId) values (111,85)
  --Delete from nodes where NodeId = 6

  --5,1002,1003,1004,8,9,10,11,12
  --Insert into RoutesNodes (NodeId,RouteId) values (5,1),(1002,1),(1003,1),(1004,1),(8,1),(9,1),(10,1),(11,1),(12,1)
  Select rn.RoutesNodesId, n.NodeId, s1.Name as StartStationName, s2.Name as EndStationName from RoutesNodes rn
  inner join Nodes n on rn.NodeId = n.NodeId
  inner join Stations s1 on n.StartStationId = s1.StationId
  inner join Stations s2 on n.EndStationId = s2.StationId
  order by RoutesNodesId ASC