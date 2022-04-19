using IpGeolocation.Core.DataAccess.Interfaces;
using IpGeolocation.Core.Services.Interfaces;
using IpGeolocation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Core.Services
{
    public class GeolocationsCollectionService: IGeolocationsCollectionService
    {
        public IGeolocationsCollectionRepository _geolocationsCollectionRepository { get; set; }
        public GeolocationsCollectionService(IGeolocationsCollectionRepository geolocationsCollectionRepository)
        {
            _geolocationsCollectionRepository = geolocationsCollectionRepository;
        }

        public async Task<GeolocationsCollection> CreateNewGeolocationsCollection(int ipsCount)
        {
            return await _geolocationsCollectionRepository.InsertGeoCollectionAsync(new GeolocationsCollection()
            {
                IPsTotalCount = ipsCount,
                IPsInsertedCount = 0,
                IPsErrorCount = 0
            });
        }

        public async Task<GeolocationsCollection> UpdateGeoCollection(GeolocationsCollection geolocationsCollection)
        {
            return await _geolocationsCollectionRepository.UpdateGeoCollectionAsync(geolocationsCollection);
        }

        public async Task<GeolocationsCollection> GetGeoCollectionByGuidAsync(Guid guid)
        {
            return await _geolocationsCollectionRepository.GetGeoCollectionByGuidAsync(guid);
        }
    }
}
