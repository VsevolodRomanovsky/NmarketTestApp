using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace NmarketTestApp.Models
{
    public class Flat
    {
        public Flat() { }

        public Guid Id { get; set; }

        [Key]
        public int FlatId { get; set; }

        public int RoomsCount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalArea { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal KitchenArea { get; set; }

        public int Floor { get; set; }

        public int BuildingId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Building Building { get; set; }
    }
}
