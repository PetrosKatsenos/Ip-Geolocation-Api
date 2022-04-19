using IpGeolocation.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Core.Services.Interfaces
{
    public interface IGeolocationApiService
    {
        Task<GeolocationJson> GetGeolocationAsync(string ip);
        Task<Guid> GetGeolocationsAsync(List<string> ips);
        Task<List<GeolocationJson>> GetGeolocationsParallelAsync(List<string> ips);
        Task<string> GetGeolocationsProcessAsync(Guid guid);
    }
}
