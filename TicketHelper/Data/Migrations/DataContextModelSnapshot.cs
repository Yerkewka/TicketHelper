﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketHelper.Data;

namespace TicketHelper.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicketHelper.Domain.Carriage", b =>
                {
                    b.Property<int>("CarriageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("CarriageId");

                    b.HasIndex("TrainId");

                    b.ToTable("Carriages");
                });

            modelBuilder.Entity("TicketHelper.Domain.Node", b =>
                {
                    b.Property<int>("NodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackNodeId")
                        .HasColumnType("int");

                    b.Property<float?>("Distance")
                        .HasColumnType("real");

                    b.Property<int>("EndStationId")
                        .HasColumnType("int");

                    b.Property<int>("StartStationId")
                        .HasColumnType("int");

                    b.HasKey("NodeId");

                    b.HasIndex("EndStationId");

                    b.HasIndex("StartStationId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("TicketHelper.Domain.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("EndStationId")
                        .HasColumnType("int");

                    b.Property<int>("StartStationId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("RouteId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("EndStationId");

                    b.HasIndex("StartStationId");

                    b.HasIndex("TrainId")
                        .IsUnique();

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TicketHelper.Domain.RoutesNodes", b =>
                {
                    b.Property<int>("RoutesNodesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NodeId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("RoutesNodesId");

                    b.HasIndex("NodeId");

                    b.HasIndex("RouteId");

                    b.ToTable("RoutesNodes");
                });

            modelBuilder.Entity("TicketHelper.Domain.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("Date")
                        .IsUnique();

                    b.HasIndex("TrainId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("TicketHelper.Domain.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Redirect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("StationId");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("TicketHelper.Domain.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarriageId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("CarriageId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TicketHelper.Domain.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("TrainId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("TicketHelper.Domain.Carriage", b =>
                {
                    b.HasOne("TicketHelper.Domain.Train", "Train")
                        .WithMany("Carriages")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketHelper.Domain.Node", b =>
                {
                    b.HasOne("TicketHelper.Domain.Station", "EndStation")
                        .WithMany("AsEndStationNodes")
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TicketHelper.Domain.Station", "StartStation")
                        .WithMany("AsStartStationNodes")
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketHelper.Domain.Route", b =>
                {
                    b.HasOne("TicketHelper.Domain.Station", "EndStation")
                        .WithMany("AsEndStationRoutes")
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TicketHelper.Domain.Station", "StartStation")
                        .WithMany("AsStartStationRoutes")
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TicketHelper.Domain.Train", "Train")
                        .WithOne("Route")
                        .HasForeignKey("TicketHelper.Domain.Route", "TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketHelper.Domain.RoutesNodes", b =>
                {
                    b.HasOne("TicketHelper.Domain.Node", "Node")
                        .WithMany("RoutesNodes")
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TicketHelper.Domain.Route", "Route")
                        .WithMany("RoutesNodes")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketHelper.Domain.Schedule", b =>
                {
                    b.HasOne("TicketHelper.Domain.Train", "Train")
                        .WithMany("Schedule")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TicketHelper.Domain.Ticket", b =>
                {
                    b.HasOne("TicketHelper.Domain.Carriage", "Carriage")
                        .WithMany("Tickets")
                        .HasForeignKey("CarriageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TicketHelper.Domain.Schedule", "Schedule")
                        .WithMany("Tickets")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
