using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NmarketTestApp.Models
{
    public class District
    {
        public District() { }

        public Guid Id { get; set; }

        [Key]
        public int DistrictId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
