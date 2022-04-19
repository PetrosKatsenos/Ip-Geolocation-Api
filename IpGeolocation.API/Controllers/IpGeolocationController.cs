using IpGeolocation.Core.Services.Interfaces;
using IpGeolocation.Data.Dtos;
using IpGeolocation.Data.Jsons;
using Microsoft.AspNetCore.Mvc;

namespace IpGeolocation.API.Controllers
{
    [Route("/[Action]")]
    [ApiController]
    public class IpGeolocationController : ControllerBase
    {

        //private readonly ILogger<IpGeolocationController> _logger;

        //public IpGeolocationController(ILogger<IpGeolocationController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet(Name = "GetGeolocation")]
        [ProducesResponseType(typeof(GeolocationJson), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetGeolocation(string Ip,
            [FromServices] IGeolocationApiService geolocationApiService)
        {
            try
            {
                var geolocation = await geolocationApiService.GetGeolocationAsync(Ip);
                if (geolocation is null)
                    return BadRequest("Can't find data for this IP");
                return Ok(geolocation);
            }
            catch (Exception ex)
            {
                //TODO LogError
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "GetGeolocations")]
        [ProducesResponseType(typeof(GeolocationJson), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetGeolocationParallel(List<string> Ips,
          [FromServices] IGeolocationApiService geolocationApiService)
        {
            try
            {
                var geolocation = await geolocationApiService.GetGeolocationsAsync(Ips);

                return Ok(geolocation);
            }
            catch (Exception ex)
            {
                //TODO LogError
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(Name = "GetGeolocationsProcess")]
        [ProducesResponseType(typeof(GeolocationJson), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetGeolocationsProcess(Guid guid,
            [FromServices] IGeolocationApiService geolocationApiService)
        {
            try
            {
                var geolocation = await geolocationApiService.GetGeolocationsProcessAsync(guid);

                return Ok(geolocation);
            }
            catch (Exception ex)
            {
                //TODO LogError
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost(Name = "GetGeolocations")]
        //[ProducesResponseType(typeof(GeolocationJson), 200)]
        //[ProducesResponseType(typeof(string), 400)]
        //public async Task<IActionResult> GetGeolocationParallel(List<string> Ips,
        //   [FromServices] IGeolocationApiService geolocationApiService)
        //{
        //    try
        //    {
        //        var geolocation = await geolocationApiService.GetGeolocationsAsync(Ips);
        //        if (geolocation is null)
        //            return BadRequest("Can't find data for this IP");
        //        return Ok(geolocation);
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO LogError
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}