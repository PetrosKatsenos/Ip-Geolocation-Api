using IpGeolocation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Core.Services.Interfaces
{
    public interface IGeolocationsCollectionService
    {
        Task<GeolocationsCollection> CreateNewGeolocationsCollection(int ipsCount);
        Task<GeolocationsCollection> UpdateGeoCollection(GeolocationsCollection geolocationsCollection);
        Task<GeolocationsCollection> GetGeoCollectionByGuidAsync(Guid guid);
    }
}
