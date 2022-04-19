using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpGeolocation.Data.BaseEntities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset EntityCreatedAt { get; set; }

        [Required]
        public DateTimeOffset EntityModifiedAt { get; set; }
    }
}
