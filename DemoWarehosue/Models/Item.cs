using System;
using System.Collections.Generic;

#nullable disable

namespace DemoWarehosue.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int? StockQuantity { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual Category Category { get; set; }
    }
}
