using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Data
{
    public class BoxInventory
    { 
        [Key]
        public int Id { get; set; }

        public int Weight { get; set; }

        public int Volume { get; set; }

        public bool CanHoldLiquid { get; set; }

        public double Cost { get; set; }

        public int InventoryCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
