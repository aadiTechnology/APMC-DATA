﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.Entities;

namespace MyProject.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20201130063413_QRCode")]
    partial class QRCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyProject.Entities.Models.AppUserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("MyProject.Entities.Models.AppUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("MyProject.Entities.Models.ChargesTypeMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ExtraTimeCharges")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NoParkingCharges")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ChargesTypeMaster");
                });

            modelBuilder.Entity("MyProject.Entities.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MyProject.Entities.Models.GlobalConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GlobalConfigurations");
                });

            modelBuilder.Entity("MyProject.Entities.Models.IndentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppovedBy")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ETADate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ETATime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsScanned")
                        .HasColumnType("bit");

                    b.Property<string>("OrderNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QrId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RollId")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IndentDetails");
                });

            modelBuilder.Entity("MyProject.Entities.Models.IndentProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("IndentId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IndentProducts");
                });

            modelBuilder.Entity("MyProject.Entities.Models.ParkingCharges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChargesTypeId")
                        .HasColumnType("int");

                    b.Property<string>("EntryFee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IndentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleTypeId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParkingCharges");
                });

            modelBuilder.Entity("MyProject.Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MyProject.Entities.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("MyProject.Entities.Models.StallDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<string>("StallName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StallNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StallRegNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StallDetails");
                });

            modelBuilder.Entity("MyProject.Entities.Models.StallProductCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("StallRegistrationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StallProductCategories");
                });

            modelBuilder.Entity("MyProject.Entities.Models.StallRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApproveBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRejected")
                        .HasColumnType("bit");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StallId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StallRegistration");
                });

            modelBuilder.Entity("MyProject.Entities.Models.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("MyProject.Entities.Models.VehicleTypeMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypeMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
