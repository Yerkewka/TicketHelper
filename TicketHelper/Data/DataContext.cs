using Microsoft.EntityFrameworkCore;
using TicketHelper.Domain;

namespace TicketHelper.Data
{
    public class DataContext : DbContext
    {
        #region Contructor

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #endregion

        #region Public properties

        public DbSet<Station> Stations { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<RoutesNodes> RoutesNodes { get; set; }
        public DbSet<Ticket> Ticket { get; set; }        
        public DbSet<Schedule> Schedule { get; set; }        
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<CarriageType> CarriageTypes { get; set; }
        public DbSet<TrainPrice> TrainPrices { get; set; }

        #endregion

        #region Public functions

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Station

            builder.Entity<Station>().ToTable("Stations");

            builder.Entity<Station>().HasKey(e => e.StationId);
            builder.Entity<Station>().Property(e => e.Name).HasMaxLength(100).IsRequired();
            builder.Entity<Station>().Property(e => e.ShortName).HasMaxLength(5).IsRequired();
            builder.Entity<Station>().Property(e => e.Redirect).HasDefaultValue(false);           
            builder.Entity<Station>().HasIndex(e => e.ShortName).IsUnique();

            #endregion

            #region Node

            builder.Entity<Node>().ToTable("Nodes");

            builder.Entity<Node>().HasKey(e => e.NodeId);
            builder.Entity<Node>().Property(e => e.StartStationId).IsRequired();
            builder.Entity<Node>().Property(e => e.EndStationId).IsRequired();
            builder.Entity<Node>().Property(e => e.BackNodeId);
            builder.Entity<Node>().Property(e => e.Distance);

            builder.Entity<Node>().HasOne(e => e.StartStation)
                .WithMany(e => e.AsStartStationNodes)
                .HasForeignKey(e => e.StartStationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Node>().HasOne(e => e.EndStation)
                .WithMany(e => e.AsEndStationNodes)
                .HasForeignKey(e => e.EndStationId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Route

            builder.Entity<Route>().ToTable("Routes");

            builder.Entity<Route>().HasKey(e => e.RouteId);
            builder.Entity<Route>().Property(e => e.Code).HasMaxLength(20).IsRequired();
            builder.Entity<Route>().Property(e => e.StartStationId);
            builder.Entity<Route>().Property(e => e.EndStationId);
            builder.Entity<Route>().Property(e => e.TrainId);

            builder.Entity<Route>().HasIndex(e => e.Code).IsUnique();

            builder.Entity<Route>().HasOne(e => e.StartStation)
                .WithMany(e => e.AsStartStationRoutes)
                .HasForeignKey(e => e.StartStationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Route>().HasOne(e => e.EndStation)
                .WithMany(e => e.AsEndStationRoutes)
                .HasForeignKey(e => e.EndStationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Route>().HasOne(e => e.Train)
                .WithOne(e => e.Route)
                .HasForeignKey<Route>(e => e.TrainId);

            #endregion

            #region Train

            builder.Entity<Train>().ToTable("Trains");

            builder.Entity<Train>().HasKey(e => e.TrainId);
            builder.Entity<Train>().Property(e => e.Code).HasMaxLength(10).IsRequired();
            builder.Entity<Train>().Property(e => e.Name).HasMaxLength(200).IsRequired();

            builder.Entity<Train>().HasIndex(e => e.Code).IsUnique();

            #endregion

            #region RoutesNodes

            builder.Entity<RoutesNodes>().ToTable("RoutesNodes");

            builder.Entity<RoutesNodes>().HasKey(e => e.RoutesNodesId);
            builder.Entity<RoutesNodes>().Property(e => e.RouteId);
            builder.Entity<RoutesNodes>().Property(e => e.NodeId);
            builder.Entity<RoutesNodes>().Property(e => e.Order);

            builder.Entity<RoutesNodes>().HasOne(e => e.Route)
                .WithMany(e => e.RoutesNodes)
                .HasForeignKey(e => e.RouteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<RoutesNodes>().HasOne(e => e.Node)
                .WithMany(e => e.RoutesNodes)
                .HasForeignKey(e => e.NodeId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Ticket

            builder.Entity<Ticket>().ToTable("Tickets");

            builder.Entity<Ticket>().HasKey(e => e.TicketId);
            builder.Entity<Ticket>().Property(e => e.ScheduleId);
            builder.Entity<Ticket>().Property(e => e.CarriageId);

            builder.Entity<Ticket>().HasOne(e => e.Schedule)
                .WithMany(e => e.Tickets)
                .HasForeignKey(e => e.ScheduleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Ticket>().HasOne(e => e.Carriage)
                .WithMany(e => e.Tickets)
                .HasForeignKey(e => e.CarriageId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Schedule

            builder.Entity<Schedule>().ToTable("Schedule");

            builder.Entity<Schedule>().HasKey(e => e.ScheduleId);
            builder.Entity<Schedule>().Property(e => e.TrainId);
            builder.Entity<Schedule>().Property(e => e.StationId);
            builder.Entity<Schedule>().Property(e => e.Date);
            builder.Entity<Schedule>().Property(e => e.DepartureDate);
            builder.Entity<Schedule>().Property(e => e.ArrivalDate);

            builder.Entity<Schedule>().HasIndex(e => new { e.TrainId, e.StationId, e.Date }).IsUnique();

            builder.Entity<Schedule>()
                .HasOne(e => e.Train)
                .WithMany(e => e.Schedule)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Schedule>()
                .HasOne(e => e.Station)
                .WithMany(e => e.Schedule)
                .HasForeignKey(e => e.StationId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Carriage

            builder.Entity<Carriage>().ToTable("Carriages");

            builder.Entity<Carriage>().HasKey(e => e.CarriageId);
            builder.Entity<Carriage>().Property(e => e.TrainId);
            builder.Entity<Carriage>().Property(e => e.CarriageTypeId);
            builder.Entity<Carriage>().Property(e => e.Capacity).IsRequired();

            builder.Entity<Carriage>()
                .HasOne(e => e.Train)
                .WithMany(e => e.Carriages)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Carriage>()
                .HasOne(e => e.CarriageType)
                .WithMany(e => e.Carriages)
                .HasForeignKey(e => e.CarriageTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            #endregion

            #region CarriageType

            builder.Entity<CarriageType>().ToTable("CarriageTypes");

            builder.Entity<CarriageType>().HasKey(e => e.CarriageTypeId);
            builder.Entity<CarriageType>().Property(e => e.Name).HasMaxLength(50);

            builder.Entity<CarriageType>().HasData(new CarriageType[]
            {
                new CarriageType
                {
                    CarriageTypeId = 1,
                    Name = "Плацкарт"
                },
                new CarriageType
                {
                    CarriageTypeId = 2,
                    Name = "Купе"
                },
                new CarriageType
                {
                    CarriageTypeId = 3,
                    Name = "Люкс"
                }
            }); ;

            #endregion

            #region TrainPrice

            builder.Entity<TrainPrice>().ToTable("TrainPrices");

            builder.Entity<TrainPrice>().HasKey(e=>new
            {
                e.TrainId, 
                e.CarriageTypeId,
                e.StartStationId,
                e.EndStationId
            });
            builder.Entity<TrainPrice>().Property(e => e.TrainId);
            builder.Entity<TrainPrice>().Property(e => e.StartStationId);
            builder.Entity<TrainPrice>().Property(e => e.EndStationId);
            builder.Entity<TrainPrice>().Property(e => e.CarriageTypeId);
            builder.Entity<TrainPrice>().Property(e => e.Price);

            builder.Entity<TrainPrice>()
                .HasOne(e => e.Train)
                .WithMany(e => e.TrainPrices)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TrainPrice>()
                .HasOne(e => e.StartStation)
                .WithMany(e => e.AsStartStationTrainPrices)
                .HasForeignKey(e => e.StartStationId)
                .OnDelete(DeleteBehavior.NoAction);            
            
            builder.Entity<TrainPrice>()
                .HasOne(e => e.EndStation)
                .WithMany(e => e.AsEndStationTrainPrices)
                .HasForeignKey(e => e.EndStationId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<TrainPrice>()
                .HasOne(e => e.CarriageType)
                .WithMany(e => e.TrainPrices)
                .HasForeignKey(e => e.CarriageTypeId)
                .OnDelete(DeleteBehavior.NoAction);


            #endregion
        }

        #endregion
    }
}
