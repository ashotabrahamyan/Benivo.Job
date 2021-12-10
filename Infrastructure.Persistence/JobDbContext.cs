using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions options) : base(options)
        {

        } 
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //   => options.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database=Job;Trusted_Connection=True;MultipleActiveResultSets=true");
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Location> Location { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
              new Categories
              {
                  Id = 1,
                  Name = "Engineering",
                  CreateDate = DateTime.UtcNow,
                  LastUpdate = DateTime.UtcNow,
                  IsDeleted = false
              },
               new Categories
               {
                   Id = 2,
                   Name = "Fashion",
                   CreateDate = DateTime.UtcNow,
                   LastUpdate = DateTime.UtcNow,
                   IsDeleted = false
               },
               new Categories
               {
                   Id = 3,
                   Name = "Real Estate",
                   CreateDate = DateTime.UtcNow,
                   LastUpdate = DateTime.UtcNow,
                   IsDeleted = false
               }
              );
            modelBuilder.Entity<Location>().HasData(
              new Location
              {
                  Id = 1,
                   Country = "Armenia",
                   City = "Yerevan", 
                  CreateDate = DateTime.UtcNow,
                  LastUpdate = DateTime.UtcNow,
                  IsDeleted = false
              },
               new Location
               {
                   Id = 2,
                   Country = "Gyumri",
                   City = "Yerevan",
                   CreateDate = DateTime.UtcNow,
                   LastUpdate = DateTime.UtcNow,
                   IsDeleted = false
               },
               new Location
               {
                   Id = 3,
                   Country = "Dilijan",
                   City = "Yerevan",
                   CreateDate = DateTime.UtcNow,
                   LastUpdate = DateTime.UtcNow,
                   IsDeleted = false
               },
               new Location
               {
                   Id = 4,
                   Country = "Sevan",
                   City = "Yerevan",
                   CreateDate = DateTime.UtcNow,
                   LastUpdate = DateTime.UtcNow,
                   IsDeleted = false
               }
              );
            modelBuilder.Entity<Job>().HasData(
                new Job()
                {
                    Id = 10,
                    Title = "Senior Node.js Developer",
                    Description = "fectively and take part in team discussions.",
                    LocationId = 3,
                    EmploymentType = 1,
                    ImageUrl = "www.google.com",
                    CategoryId = 3,
                    CreateDate = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Job()
                {
                    Id = 11,
                    Title = "Senior Node.js Developer",
                    Description = "fectively and take part in team discussions.",
                    LocationId = 3,
                    EmploymentType = 1,
                    ImageUrl = "www.google.com",
                    CategoryId = 3,
                    CreateDate = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow,
                    IsDeleted = false
                },
                 new Job()
                 {
                     Id = 12,
                     Title = "Senior Node.js Developer",
                     Description = "fectively and take part in team discussions.",
                     LocationId = 3,
                     EmploymentType = 1,
                     ImageUrl = "www.google.com",
                     CategoryId = 3,
                     CreateDate = DateTime.UtcNow,
                     LastUpdate = DateTime.UtcNow,
                     IsDeleted = false
                 },
                 new Job()
                 {
                     Id = 13,
                     Title = "Senior Node.js Developer",
                     Description = "fectively and take part in team discussions.",
                     LocationId = 3,
                     EmploymentType = 1,
                     ImageUrl = "www.google.com",
                     CategoryId = 3,
                     CreateDate = DateTime.UtcNow,
                     LastUpdate = DateTime.UtcNow,
                     IsDeleted = false
                 } 
                ); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
