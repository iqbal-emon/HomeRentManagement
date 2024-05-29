﻿// <auto-generated />
using System;
using HomeRentManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeRentManagement.Migrations
{
    [DbContext(typeof(addDbContex))]
    [Migration("20240528132912_payment-monthd")]
    partial class paymentmonthd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeRentManagement.Data.BillGenerate", b =>
                {
                    b.Property<int>("BillingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillingID"));

                    b.Property<decimal>("ElectricityBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GasBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MonthName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServiceCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalRent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BillingID");

                    b.HasIndex("StatusId");

                    b.HasIndex("TenantID");

                    b.ToTable("BillGenerates");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Floor", b =>
                {
                    b.Property<int>("FloorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FloorID"));

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.Property<int>("HouseID")
                        .HasColumnType("int");

                    b.HasKey("FloorID");

                    b.HasIndex("HouseID");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HomeRentManagement.Data.House", b =>
                {
                    b.Property<int>("HouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseID"));

                    b.Property<string>("HouseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("floorNumber")
                        .HasColumnType("int");

                    b.HasKey("HouseID");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<string>("PaymentMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("TenantID");

                    b.HasIndex("UnitID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Rental", b =>
                {
                    b.Property<int>("RentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentID"));

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RentMont")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.Property<decimal>("totalRent")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RentID");

                    b.HasIndex("TenantID");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ShortForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShorForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuss");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Tenant", b =>
                {
                    b.Property<int>("TenantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantID"));

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("IdCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TenantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.HasKey("TenantID");

                    b.HasIndex("HomeId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UnitID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitID"));

                    b.Property<int>("BedRoom")
                        .HasColumnType("int");

                    b.Property<int>("FlolorNu")
                        .HasColumnType("int");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Rent")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("WashRoom")
                        .HasColumnType("int");

                    b.Property<string>("unitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitID");

                    b.HasIndex("HomeId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("HomeRentManagement.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleID");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomeRentManagement.Data.BillGenerate", b =>
                {
                    b.HasOne("HomeRentManagement.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Floor", b =>
                {
                    b.HasOne("HomeRentManagement.Data.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("HomeRentManagement.Data.House", b =>
                {
                    b.HasOne("HomeRentManagement.Data.User", "Owner")
                        .WithMany("Houses")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Payment", b =>
                {
                    b.HasOne("HomeRentManagement.Data.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tenant");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Rental", b =>
                {
                    b.HasOne("HomeRentManagement.Data.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Role", b =>
                {
                    b.HasOne("HomeRentManagement.Data.Status", "statuss")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("statuss");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Tenant", b =>
                {
                    b.HasOne("HomeRentManagement.Data.House", "House")
                        .WithMany()
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Unit", "Unit")
                        .WithMany("Tenants")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Owner");

                    b.Navigation("Status");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Unit", b =>
                {
                    b.HasOne("HomeRentManagement.Data.House", "House")
                        .WithMany()
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("Owner");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("HomeRentManagement.Data.User", b =>
                {
                    b.HasOne("HomeRentManagement.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeRentManagement.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("HomeRentManagement.Data.Unit", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("HomeRentManagement.Data.User", b =>
                {
                    b.Navigation("Houses");
                });
#pragma warning restore 612, 618
        }
    }
}
