﻿// <auto-generated />
using CarDealer.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarDealer.Database.Migrations
{
    [DbContext(typeof(CarDealerContext))]
    [Migration("20231222195102_CarDealer_EnginesSeed")]
    partial class CarDealer_EnginesSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarDealer.Domain.Entities.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Coupe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sedan"
                        });
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cylinders")
                        .HasColumnType("int");

                    b.Property<int>("Displacement")
                        .HasColumnType("int");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuelTypeId");

                    b.ToTable("Engines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cylinders = 8,
                            Displacement = 4999,
                            FuelTypeId = 1,
                            Name = "M113"
                        },
                        new
                        {
                            Id = 2,
                            Cylinders = 8,
                            Displacement = 5461,
                            FuelTypeId = 1,
                            Name = "M273"
                        });
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Petrol"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Diesel"
                        });
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Generation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Generations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ModelId = 1,
                            Name = "C215"
                        },
                        new
                        {
                            Id = 2,
                            ModelId = 1,
                            Name = "C216"
                        });
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercedes-Benz"
                        });
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManufacturerId = 1,
                            Name = "CL"
                        });
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Engine", b =>
                {
                    b.HasOne("CarDealer.Domain.Entities.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FuelType");
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Generation", b =>
                {
                    b.HasOne("CarDealer.Domain.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarDealer.Domain.Entities.Model", b =>
                {
                    b.HasOne("CarDealer.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
