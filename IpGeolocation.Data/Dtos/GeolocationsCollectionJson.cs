using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Data.Dtos
{
    public class GeolocationsCollectionJson
    {
        public int IPsTotalCount { get; set; }
        public int IPsInsertedCount { get; set; }
        public int EstimetatedTime { get; set; }
    }
}
