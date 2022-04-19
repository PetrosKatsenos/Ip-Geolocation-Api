using IpGeolocation.Data.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Data.CommonEntities
{
    [Table("Countries")]
    public class Country : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string TimeZone { get; set; }
        [MaxLength(20)]
        public string Currency { get; set; }
        [MaxLength(2)]
        public string A2 { get; set; }
        [MaxLength(3)]
        public string A3 { get; set; }
    }
}
