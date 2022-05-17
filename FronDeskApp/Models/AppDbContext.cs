using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FronDeskApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageType> StorageTypes { get; set; }
        public DbSet<CustomerStorage> CustomerStorages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed StorageTypes
            modelBuilder.Entity<StorageType>().HasData(
                    new StorageType
                    {
                        StorageTypeId = 1,
                        Name = "Small",
                        Description = "Small",
                    },
                    new StorageType
                    {
                        StorageTypeId = 2,
                        Name = "Medium",
                        Description = "Medium",
                    },
                    new StorageType
                    {
                        StorageTypeId = 3,
                        Name = "Large",
                        Description = "Large",
                    }
                );

            //Seed Storages
            modelBuilder.Entity<Storage>().HasData(
                    new Storage
                    {
                        StorageId = 1,
                        StorageTypeId = 1,
                        Row = 1
                    },
                    new Storage
                    {
                        StorageId = 2,
                        StorageTypeId = 1,
                        Row = 1
                    },
                    new Storage
                    {
                        StorageId = 3,
                        StorageTypeId = 1,
                        Row = 1
                    },
                    new Storage
                    {
                        StorageId = 4,
                        StorageTypeId = 2,
                        Row = 1
                    },
                    new Storage
                    {
                        StorageId = 5,
                        StorageTypeId = 3,
                        Row = 1
                    },
                    new Storage
                    {
                        StorageId = 6,
                        StorageTypeId = 3,
                        Row = 1
                    }
                );
        }
    }
}
