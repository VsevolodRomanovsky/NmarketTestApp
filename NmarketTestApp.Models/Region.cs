using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NmarketTestApp.Models
{
    public class Region
    {
        public Region() { }

        public Guid Id { get; set; }

        [Key]
        public int RegionId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
