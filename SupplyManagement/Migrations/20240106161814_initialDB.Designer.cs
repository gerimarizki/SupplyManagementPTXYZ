﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplyManagement.Data;

#nullable disable

namespace SupplyManagement.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20240106161814_initialDB")]
    partial class initialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SupplyManagement.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("companyID");

                    b.Property<string>("ApprovalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("approvalStatus");

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("companyEmail");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("companyName");

                    b.Property<string>("CompanyPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("companyPhone");

                    b.Property<byte[]>("CompanyPhoto")
                        .IsRequired()
                        .HasColumnType("varbinary(255)")
                        .HasColumnName("companyPhoto");

                    b.HasKey("CompanyID");

                    b.HasIndex("CompanyID", "CompanyEmail")
                        .IsUnique();

                    b.ToTable("tb_m_company");
                });

            modelBuilder.Entity("SupplyManagement.Models.ManagerLogistic", b =>
                {
                    b.Property<int>("ManagerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ManagerID");

                    b.Property<string>("ManagerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("managerEmail");

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("managerName");

                    b.Property<string>("ManagerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("managerPhone");

                    b.HasKey("ManagerID");

                    b.HasIndex("ManagerID", "ManagerEmail")
                        .IsUnique();

                    b.ToTable("tb_m_manager");
                });

            modelBuilder.Entity("SupplyManagement.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProjectID");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("projectName");

                    b.Property<int>("VendorID")
                        .HasColumnType("int");

                    b.HasKey("ProjectID");

                    b.HasIndex("ProjectID")
                        .IsUnique();

                    b.HasIndex("VendorID");

                    b.ToTable("tb_m_project");
                });

            modelBuilder.Entity("SupplyManagement.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<int>("ManagerID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Password");

                    b.Property<int>("UserType")
                        .HasColumnType("int")
                        .HasColumnName("UserType");

                    b.HasKey("UserID");

                    b.HasIndex("CompanyID")
                        .IsUnique();

                    b.HasIndex("ManagerID")
                        .IsUnique();

                    b.HasIndex("UserID", "Email")
                        .IsUnique();

                    b.ToTable("tb_m_user");
                });

            modelBuilder.Entity("SupplyManagement.Models.Vendor", b =>
                {
                    b.Property<int>("VendorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VendorID");

                    b.Property<string>("BusinessType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("businessType");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("companyType");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("vendorName");

                    b.HasKey("VendorID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.HasIndex("VendorID")
                        .IsUnique();

                    b.ToTable("tb_m_vendor");
                });

            modelBuilder.Entity("SupplyManagement.Models.Project", b =>
                {
                    b.HasOne("SupplyManagement.Models.Vendor", "Vendor")
                        .WithMany("Projects")
                        .HasForeignKey("VendorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("SupplyManagement.Models.User", b =>
                {
                    b.HasOne("SupplyManagement.Models.Company", "Company")
                        .WithOne("User")
                        .HasForeignKey("SupplyManagement.Models.User", "CompanyID");

                    b.HasOne("SupplyManagement.Models.ManagerLogistic", "ManagerLogistic")
                        .WithOne("User")
                        .HasForeignKey("SupplyManagement.Models.User", "ManagerID");

                    b.Navigation("Company");

                    b.Navigation("ManagerLogistic");
                });

            modelBuilder.Entity("SupplyManagement.Models.Vendor", b =>
                {
                    b.HasOne("SupplyManagement.Models.User", "User")
                        .WithOne("Vendor")
                        .HasForeignKey("SupplyManagement.Models.Vendor", "UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SupplyManagement.Models.Company", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("SupplyManagement.Models.ManagerLogistic", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("SupplyManagement.Models.User", b =>
                {
                    b.Navigation("Vendor")
                        .IsRequired();
                });

            modelBuilder.Entity("SupplyManagement.Models.Vendor", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
