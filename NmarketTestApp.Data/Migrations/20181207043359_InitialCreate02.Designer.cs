﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NmarketTestApp.Data;

namespace NmarketTestApp.Data.Migrations
{
    [DbContext(typeof(NmarketDbContext))]
    [Migration("20181207043359_InitialCreate02")]
    partial class InitialCreate02
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NmarketTestApp.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DistrictId");

                    b.Property<string>("Housing");

                    b.Property<Guid>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("Queue");

                    b.HasKey("BuildingId");

                    b.HasIndex("BuildingId")
                        .IsUnique()
                        .HasName("Index_BuildingId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("NmarketTestApp.Models.District", b =>
                {
                    b.Property<int>("DistrictId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Id");

                    b.Property<string>("Name");

                    b.Property<int>("RegionId");

                    b.HasKey("DistrictId");

                    b.HasIndex("DistrictId")
                        .IsUnique()
                        .HasName("Index_DistrictId");

                    b.HasIndex("RegionId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("NmarketTestApp.Models.Flat", b =>
                {
                    b.Property<int>("FlatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId");

                    b.Property<int>("Floor");

                    b.Property<Guid>("Id");

                    b.Property<decimal>("KitchenArea")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomsCount");

                    b.Property<decimal>("TotalArea")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FlatId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("FlatId")
                        .IsUnique()
                        .HasName("Index_FlatId");

                    b.ToTable("Flat");
                });

            modelBuilder.Entity("NmarketTestApp.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Id");

                    b.Property<string>("Name");

                    b.HasKey("RegionId");

                    b.HasIndex("RegionId")
                        .IsUnique()
                        .HasName("Index_RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("NmarketTestApp.Models.Building", b =>
                {
                    b.HasOne("NmarketTestApp.Models.District", "District")
                        .WithMany("Buildings")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NmarketTestApp.Models.District", b =>
                {
                    b.HasOne("NmarketTestApp.Models.Region", "Region")
                        .WithMany("Districts")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NmarketTestApp.Models.Flat", b =>
                {
                    b.HasOne("NmarketTestApp.Models.Building", "Building")
                        .WithMany("Flats")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
