﻿// <auto-generated />
using System;
using GarageV2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageV2.Migrations
{
    [DbContext(typeof(GarageDBContext))]
    [Migration("20220713133606_220713")]
    partial class _220713
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<string>("RegNr")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wheels")
                        .HasColumnType("int");

                    b.HasKey("RegNr");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            RegNr = "abc123",
                            ArrivalTime = new DateTime(2022, 7, 13, 15, 26, 6, 752, DateTimeKind.Local).AddTicks(6194),
                            Brand = "Volvo",
                            Color = "Röd",
                            Model = "X90",
                            VehicleType = "PersonBil",
                            Wheels = 4
                        },
                        new
                        {
                            RegNr = "abb456",
                            ArrivalTime = new DateTime(2022, 7, 13, 15, 21, 6, 752, DateTimeKind.Local).AddTicks(6232),
                            Brand = "Saab",
                            Color = "Grön",
                            Model = "99",
                            VehicleType = "PersonBil",
                            Wheels = 4
                        },
                        new
                        {
                            RegNr = "oPq144",
                            ArrivalTime = new DateTime(2022, 7, 13, 15, 34, 6, 752, DateTimeKind.Local).AddTicks(6234),
                            Brand = "Tesla",
                            Color = "Silver",
                            Model = "Super",
                            VehicleType = "PersonBil",
                            Wheels = 4
                        },
                        new
                        {
                            RegNr = "krtekl",
                            ArrivalTime = new DateTime(2022, 7, 13, 15, 36, 6, 752, DateTimeKind.Local).AddTicks(6236),
                            Brand = "Ford",
                            Color = "Brun",
                            Model = "Taunus",
                            VehicleType = "PersonBil",
                            Wheels = 4
                        },
                        new
                        {
                            RegNr = "MyBike",
                            ArrivalTime = new DateTime(2022, 7, 13, 14, 36, 6, 752, DateTimeKind.Local).AddTicks(6238),
                            Brand = "Honda",
                            Color = "Svart",
                            Model = "XFusion",
                            VehicleType = "MotorCykel",
                            Wheels = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
