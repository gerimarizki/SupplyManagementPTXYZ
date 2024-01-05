using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Numerics;
using SupplyManagement.Model;

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
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique Entity
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

      
            // User - ManagerLogistics
            modelBuilder.Entity<User>()
                .HasOne(user => user.ManagerLogistic)
                .WithOne(manager => manager.User)
                .HasForeignKey<ManagerLogistic>(manager => manager.ManagerID)
                .IsRequired(false); // User bisa tidak punya ManagerID

            // Company - User (One to One)
            modelBuilder.Entity<User>()
                .HasOne(user => user.Company)
                .WithOne(company => company.User)
                .HasForeignKey<User>(user => user.CompanyID)
                .IsRequired(false); // User bisa tidak punya CompanyID

            // User - Vendor (One to One)
            modelBuilder.Entity<Vendor>()
                .HasOne(vendor => vendor.User)
                .WithOne(user => user.Vendor)
                .HasForeignKey<User>(user => user.UserID);

            // Vendor - Project (One To Many)
            modelBuilder.Entity<Project>()
                .HasOne(project => project.Vendor)
                .WithMany(vendor => vendor.Projects)
                .HasForeignKey(project => project.VendorID);

        
            modelBuilder.Entity<Company>()
            .Property(p => p.CompanyPhoto)
            .HasColumnType("varbinary(100)"); // Use varbinary for MySQL for Photo

        }
    }
}
