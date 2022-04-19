using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Data.Dtos
{
    public class GeolocationJson
    {
        public string Ip { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Time_zone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; } 
    }
}
