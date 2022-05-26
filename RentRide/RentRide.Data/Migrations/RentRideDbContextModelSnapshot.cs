﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentRide.Data;

namespace RentRide.Data.Migrations
{
    [DbContext(typeof(RentRideDbContext))]
    partial class RentRideDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentRide.DomainModels.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CarModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("SalonId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("RentRide.DomainModels.CarModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Carcase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("RentCoefficient")
                        .HasColumnType("real");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("RentRide.DomainModels.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndOfContractDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalRentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("ClientId");

                    b.HasIndex("SalonId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("RentRide.DomainModels.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RentRide.DomainModels.Salon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("RentRide.DomainModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("RentRide.DomainModels.Car", b =>
                {
                    b.HasOne("RentRide.DomainModels.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentRide.DomainModels.Salon", "Salon")
                        .WithMany("Cars")
                        .HasForeignKey("SalonId");

                    b.Navigation("CarModel");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("RentRide.DomainModels.Contract", b =>
                {
                    b.HasOne("RentRide.DomainModels.Car", "Car")
                        .WithOne("RentContract")
                        .HasForeignKey("RentRide.DomainModels.Contract", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentRide.DomainModels.User", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId");

                    b.HasOne("RentRide.DomainModels.Salon", "Salon")
                        .WithMany("Contracts")
                        .HasForeignKey("SalonId");

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("RentRide.DomainModels.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentRide.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentRide.DomainModels.Car", b =>
                {
                    b.Navigation("RentContract");
                });

            modelBuilder.Entity("RentRide.DomainModels.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentRide.DomainModels.Salon", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("RentRide.DomainModels.User", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
