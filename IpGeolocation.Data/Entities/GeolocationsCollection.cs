using IpGeolocation.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Data.Entities
{
    [Table("GeolocationsCollections", Schema = "Geolocations")]
    public class GeolocationsCollection : BaseEntity
    {
        public int IPsTotalCount { get; set; }
        public int IPsInsertedCount { get; set; }
        public int IPsErrorCount { get; set; }
        public TimeSpan Time { get; set; }
    }
}
