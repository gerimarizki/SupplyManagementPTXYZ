using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SupplyManagement.Models;
using static NuGet.Packaging.PackagingConstants;

namespace SupplyManagement.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ManagerLogistic> Managers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // entitas unique
            modelBuilder.Entity<User>()
                      .HasIndex(u => new
                      {
                          u.UserID,
                          u.Email,
                      }).IsUnique();

            modelBuilder.Entity<Company>()
                     .HasIndex(u => new
                     {
                         u.CompanyID,
                         u.CompanyEmail,
                     }).IsUnique();

            modelBuilder.Entity<ManagerLogistic>()
                       .HasIndex(u => new
                       {
                           u.ManagerID,
                           u.ManagerEmail,
                       }).IsUnique();

            modelBuilder.Entity<Vendor>()
                       .HasIndex(u => new
                       {
                           u.VendorID
                       }).IsUnique();


            modelBuilder.Entity<Project>()
                        .HasIndex(u => new
                        {
                            u.ProjectID
                        }).IsUnique();

            modelBuilder.Entity<Company>()
            .Property(p => p.CompanyPhoto)
            .HasColumnType("varbinary(255)"); 

            // Company - User (One to One)
            modelBuilder.Entity<User>()
                .HasOne(user => user.Company)
                .WithOne(company => company.User)
                .HasForeignKey<User>(user => user.CompanyID)
                .IsRequired(false); // User bisa tidak memiliki CompanyID

            // User - ManagerLogistics
            modelBuilder.Entity<User>()
                .HasOne(user => user.ManagerLogistic)
                .WithOne(manager => manager.User)
                .HasForeignKey<User>(user => user.ManagerID)
                .IsRequired(false); // User bisa tidak memiliki ManagerID

            // User - Vendor (One to One)
            modelBuilder.Entity<Vendor>()
                .HasOne(vendor => vendor.User)
                .WithOne(user => user.Vendor)
                .HasForeignKey<Vendor>(Vendor => Vendor.UserID)
                .IsRequired(false);

            // Vendor - Project (One To Many)
            modelBuilder.Entity<Project>()
                .HasOne(project => project.Vendor)
                .WithMany(vendor => vendor.Projects)
                .HasForeignKey(project => project.VendorID);

        }

    }
}
