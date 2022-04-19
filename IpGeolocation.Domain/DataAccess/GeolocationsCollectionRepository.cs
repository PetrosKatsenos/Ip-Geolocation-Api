using IpGeolocation.Core.DataAccess.Interfaces;
using IpGeolocation.Data;
using IpGeolocation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Core.DataAccess
{
    public class GeolocationsCollectionRepository: IGeolocationsCollectionRepository
    {
        private IpGeolocationDbContext _Context;
        public GeolocationsCollectionRepository()
        {
            _Context = new IpGeolocationDbContext();
        }

        public async Task<GeolocationsCollection> InsertGeoCollectionAsync(GeolocationsCollection geolocationsCollection)
        {
            geolocationsCollection.EntityModifiedAt = DateTime.UtcNow;
            geolocationsCollection.EntityCreatedAt = DateTime.UtcNow;

            await _Context.AddAsync(geolocationsCollection);
            await _Context.SaveChangesAsync();
            
            return geolocationsCollection;
        }
        public async Task<GeolocationsCollection> UpdateGeoCollectionAsync(GeolocationsCollection geolocationsCollection)
        {
            geolocationsCollection.EntityModifiedAt = DateTime.UtcNow;
            _Context.Update(geolocationsCollection);
            await _Context.SaveChangesAsync();

            return geolocationsCollection;
        }
        public async Task<GeolocationsCollection> GetGeoCollectionByGuidAsync(Guid guid)
        {
           return await _Context.GeolocationsCollection.FindAsync(guid);
        }
    }
}
