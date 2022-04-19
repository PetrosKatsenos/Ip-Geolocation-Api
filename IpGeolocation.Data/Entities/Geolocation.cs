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
    [Table("Geolocations", Schema = "Geolocations")]
    public class Geolocation : BaseEntity
    {
        [MaxLength(100)]
        public string Ip { get; set; }

        [MaxLength(2)]
        public string CountryCode { get; set; }

        [MaxLength(50)]
        public string CountryName { get; set; }

        //public int CountryId { get; set; }
        //[ForeignKey("CountryId")]
        //public virtual CountryName CountryNames { get; set; }


        [Column(TypeName = "decimal(12, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(12, 8)")]
        public decimal Longitude { get; set; }

        public int GeolocationsCollectionId { get; set; }
        [ForeignKey("GeolocationsCollectionId")]
        public virtual GeolocationsCollection GeolocationCollections { get; set; }
    }
}
