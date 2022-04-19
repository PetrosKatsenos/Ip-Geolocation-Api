using IpGeolocation.Data.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpGeolocation.Data.Entities;
using IpGeolocation.Data.CommonEntities;
using CommonLibraries;

namespace IpGeolocation.Data
{
    public class IpGeolocationDbContext : DbContext
    {
        public IpGeolocationDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.GetKey("ConnectionString"));
        }

        //public DbSet<Geolocation> Geolocation { get; set; }
        public DbSet<GeolocationsCollection> GeolocationsCollection { get; set; }
        //public DbSet<Country> Country { get; set; }



        public override int SaveChanges()
        {
            SetCreatedModifiedValues();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetCreatedModifiedValues();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetCreatedModifiedValues()
        {
            var dt = DateTimeOffset.UtcNow;
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.EntityCreatedAt = dt;
                entry.Entity.EntityModifiedAt = dt;
            }
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.EntityModifiedAt = dt;
            }
        }

    }
}
