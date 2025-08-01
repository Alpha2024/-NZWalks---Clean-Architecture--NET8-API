﻿

using Microsoft.EntityFrameworkCore;
using NZwalks.Core.Domain.Entities;

namespace NZwalks.Infrasture.ApplicationContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Region> regions { get; set; }
        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Walk> walks { get; set; }
        public DbSet<Image> images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>().ToTable("region");
            modelBuilder.Entity<Walk>().ToTable("walk");
            modelBuilder.Entity<Difficulty>().ToTable("difficulty");
            modelBuilder.Entity<Image>().ToTable("images");


            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    Name = "Easy",
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    Name = "Medium",
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    Name = "Hard",
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);



            // Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null,
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null,
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null,
                    CreatedAt = new DateTime(2025-01-12),
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "system"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}
