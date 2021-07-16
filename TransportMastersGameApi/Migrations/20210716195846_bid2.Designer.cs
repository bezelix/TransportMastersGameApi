﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi.Migrations
{
    [DbContext(typeof(TransportMastersGameDbContext))]
    [Migration("20210716195846_bid2")]
    partial class bid2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("TransportMastersGameApi.Entities.Bid", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("BidValue")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserIdentyficator")
                        .HasColumnType("int");

                    b.Property<int>("VehicleIdentyficator")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.CarManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CarManufacturers");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int?>("Destination")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("StartLocation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.CargoSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.CargoTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<float?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CargoTemplate");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.CargoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CargoTypes");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cargo")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedByUser")
                        .HasColumnType("int");

                    b.Property<int>("Destination")
                        .HasColumnType("int");

                    b.Property<int>("Driver")
                        .HasColumnType("int");

                    b.Property<float>("RouteLength")
                        .HasColumnType("float");

                    b.Property<int>("StartLocation")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("User")
                        .HasColumnType("int");

                    b.Property<int>("Vehicle")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<double>("Lat")
                        .HasColumnType("double");

                    b.Property<double>("Lon")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<float>("HoursAtWork")
                        .HasColumnType("float");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<float>("MaxHoursAtWork")
                        .HasColumnType("float");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<float>("Payment")
                        .HasColumnType("float");

                    b.Property<int>("User")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.FirstName", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstNameValue")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("FirstName");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.LastName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LastNameValue")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LastName");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.ModelName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ModelNames");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Nationality")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<int>("PremiumPoints")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("RoleNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarCondition")
                        .HasColumnType("int");

                    b.Property<int?>("CarManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("CarManufacturerNumber")
                        .HasColumnType("int");

                    b.Property<int>("CargNumber")
                        .HasColumnType("int");

                    b.Property<int?>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("Driver")
                        .HasColumnType("int");

                    b.Property<double>("Lat")
                        .HasColumnType("double");

                    b.Property<double>("Lon")
                        .HasColumnType("double");

                    b.Property<string>("ManufactureDate")
                        .HasColumnType("longtext");

                    b.Property<int?>("ModelNameId")
                        .HasColumnType("int");

                    b.Property<string>("ModelNameNumber")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OfferEndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OfferStartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("OnMarket")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("Payload")
                        .HasColumnType("float");

                    b.Property<float>("Speed")
                        .HasColumnType("float");

                    b.Property<float>("StartPrice")
                        .HasColumnType("float");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleMileage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarManufacturerId");

                    b.HasIndex("CargoId");

                    b.HasIndex("ModelNameId");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.VehicleTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CarCondition")
                        .HasColumnType("int");

                    b.Property<int>("CarManufacturerNumber")
                        .HasColumnType("int");

                    b.Property<string>("LocalizationE")
                        .HasColumnType("longtext");

                    b.Property<string>("LocalizationN")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModelNameNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("OnMarket")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("Payload")
                        .HasColumnType("float");

                    b.Property<float>("Speed")
                        .HasColumnType("float");

                    b.Property<float>("StartPrice")
                        .HasColumnType("float");

                    b.Property<int>("VehicleMileage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleTemplate");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Cargo", b =>
                {
                    b.HasOne("TransportMastersGameApi.Entities.Destination", null)
                        .WithMany("Cargos")
                        .HasForeignKey("DestinationId");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Delivery", b =>
                {
                    b.HasOne("TransportMastersGameApi.Entities.User", "CreatedBy")
                        .WithMany("Deliveries")
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Driver", b =>
                {
                    b.HasOne("TransportMastersGameApi.Entities.User", null)
                        .WithMany("Drivers")
                        .HasForeignKey("UserId");

                    b.HasOne("TransportMastersGameApi.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.User", b =>
                {
                    b.HasOne("TransportMastersGameApi.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Vehicle", b =>
                {
                    b.HasOne("TransportMastersGameApi.Entities.CarManufacturer", "CarManufacturer")
                        .WithMany()
                        .HasForeignKey("CarManufacturerId");

                    b.HasOne("TransportMastersGameApi.Entities.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.HasOne("TransportMastersGameApi.Entities.ModelName", "ModelName")
                        .WithMany()
                        .HasForeignKey("ModelNameId");

                    b.HasOne("TransportMastersGameApi.Entities.User", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId");

                    b.Navigation("Cargo");

                    b.Navigation("CarManufacturer");

                    b.Navigation("ModelName");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.Destination", b =>
                {
                    b.Navigation("Cargos");
                });

            modelBuilder.Entity("TransportMastersGameApi.Entities.User", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Drivers");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
