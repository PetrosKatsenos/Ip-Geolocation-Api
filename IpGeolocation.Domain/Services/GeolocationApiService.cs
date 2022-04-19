using IpGeolocation.Core.Services.Interfaces;
using IpGeolocation.Data.Dtos;
using IpGeolocation.Data.Jsons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using CommonLibraries.Interfaces;
using CommonLibraries;
using System.Collections.Concurrent;
using IpGeolocation.Core.DataAccess.Interfaces;
using IpGeolocation.Data.Entities;
using System.Diagnostics;

namespace IpGeolocation.Core.Services
{
    public class GeolocationApiService: IGeolocationApiService
    {
        public IHttpHelper _httpHelper { get; set; }
        public IGeolocationsCollectionService _geolocationsCollectionService { get; set; }
        public GeolocationApiService(IHttpHelper httpHelper, IGeolocationsCollectionService geolocationsCollectionService)
        {
            _httpHelper = httpHelper;
            _geolocationsCollectionService = geolocationsCollectionService;
        }

        public async Task<GeolocationJson> GetGeolocationAsync(string ip)
        {
            if (ip.IsIP())
            {
                string apikey = AppSettings.GetKey("ApiKey");
                string baseUrl = AppSettings.GetKey("GeolocationURL");

                string url = $"{baseUrl}/{ip}?apikey={apikey}";

                var geolocaton = await _httpHelper.GetAsync<GeolocationApiJson>(url);

                return geolocaton.Adapt<GeolocationJson>();
            }

            return null;
        }

        public async Task<Guid> GetGeolocationsAsync(List<string> ips)
        {
            var collection = await _geolocationsCollectionService.CreateNewGeolocationsCollection(ips?.Count ?? 0);

            Stopwatch time = new Stopwatch();
            time.Start();

            foreach (string ip in ips)
            {
                try
                {
                    var geolocation = GetGeolocationAsync(ip);
                    if (geolocation is null) collection.IPsErrorCount++;
                    else collection.IPsInsertedCount++; 
                }
                catch (Exception ex) 
                {
                    collection.IPsErrorCount++;
                }

                collection.Time = time.Elapsed;
                await _geolocationsCollectionService.UpdateGeoCollection(collection);
            }

            time.Stop();

            return collection.Id;
        }


        public async Task<List<GeolocationJson>> GetGeolocationsParallelAsync(List<string> ips)
        {
            ConcurrentBag<GeolocationJson> bag = new ConcurrentBag<GeolocationJson>();
            Parallel.ForEach(ips, async(ip) =>
            {
                var geolocaton = await GetGeolocationAsync(ip);

                if(geolocaton is not null) 
                    bag.Add(geolocaton);
            });

            return bag.ToList();
        }

        public async Task<string> GetGeolocationsProcessAsync(Guid guid)
        {
            var collection = await _geolocationsCollectionService.GetGeoCollectionByGuidAsync(guid);

            if(collection is null)
                return $"Don't found the Collection";

            var estimatedTime = (collection.Time / (collection.IPsInsertedCount + collection.IPsErrorCount)) * (collection.IPsTotalCount- (collection.IPsInsertedCount + collection.IPsErrorCount));
            return $"Have been processed {collection.IPsInsertedCount}/{collection.IPsTotalCount} IPs, the estimated completion time {estimatedTime.Hours:00}:{estimatedTime.Minutes:00}:{estimatedTime.Seconds:00}.{estimatedTime.Milliseconds}";
        }
    }
}
