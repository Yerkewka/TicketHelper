using Microsoft.EntityFrameworkCore;
using TicketHelper.Domain;

namespace TicketHelper.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<RoutesNodes> RoutesNodes { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        


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
            builder.Entity<Train>().Property(e => e.RouteId);
            builder.Entity<Train>().Property(e => e.Code).HasMaxLength(10).IsRequired();

            builder.Entity<Train>().HasIndex(e => e.Code).IsUnique();

            builder.Entity<Train>().HasOne(e => e.Route)
                .WithOne(e => e.Train)
                .HasForeignKey<Train>(e => e.RouteId);

            #endregion

            #region RoutesNodes

            builder.Entity<RoutesNodes>().ToTable("RoutesNodes");

            builder.Entity<RoutesNodes>().HasKey(e => e.RoutesNodesId);
            builder.Entity<RoutesNodes>().Property(e => e.RouteId);
            builder.Entity<RoutesNodes>().Property(e => e.NodeId);

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
            builder.Entity<Schedule>().Property(e => e.Date);
            builder.Entity<Schedule>().Property(e => e.DepartureDate);
            builder.Entity<Schedule>().Property(e => e.ArrivalDate);

            builder.Entity<Schedule>().HasIndex(e => e.Date).IsUnique();

            builder.Entity<Schedule>()
                .HasOne(e => e.Train)
                .WithMany(e => e.Schedule)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Carriage

            builder.Entity<Carriage>().ToTable("Carriages");

            builder.Entity<Carriage>().HasKey(e => e.CarriageId);
            builder.Entity<Carriage>().Property(e => e.TrainId);
            builder.Entity<Carriage>().Property(e => e.Capacity).IsRequired();

            builder.Entity<Carriage>()
                .HasOne(e => e.Train)
                .WithMany(e => e.Carriages)
                .HasForeignKey(e => e.TrainId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion
        }
    }
}
