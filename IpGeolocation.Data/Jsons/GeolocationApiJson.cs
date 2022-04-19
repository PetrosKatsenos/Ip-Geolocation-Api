using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Data.Jsons
{
    public class GeolocationApiJson
    {
        public string Ip { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Region_code { get; set; }
        public string Region_name { get; set; }
        public string City { get; set; }
        public string Zip_code { get; set; }
        public string Time_zone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Metro_code { get; set; }
    }
}
