using IpGeolocation.Data.Entities;

namespace IpGeolocation.Core.DataAccess.Interfaces
{
    public interface IGeolocationsCollectionRepository
    {
        Task<GeolocationsCollection> InsertGeoCollectionAsync(GeolocationsCollection geolocationsCollection);
        Task<GeolocationsCollection> UpdateGeoCollectionAsync(GeolocationsCollection geolocationsCollection);
        Task<GeolocationsCollection> GetGeoCollectionByGuidAsync(Guid guid);
    }
}