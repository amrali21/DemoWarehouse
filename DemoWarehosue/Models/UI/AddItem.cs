using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWarehosue.Models.UI
{
    public class AddItem
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int? StockQuantity { get; set; }
    }
}
