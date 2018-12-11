using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace NmarketTestApp.Models
{
    public class Building
    {
        public Building () { }

        public Guid Id { get; set; }

        [Key]
        public int BuildingId { get; set; }

        public string Name { get; set; }

        public int Queue { get; set; }

        public string Housing { get; set; }

        public int DistrictId { get; set; }


        public virtual ICollection<Flat> Flats { get; set; }

        public District District { get; set; }
    }
}
