using AutoMapper;
using DemoWarehosue.Models.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWarehosue.Models.Repository
{
    public class ItemsRepository: GenericRepository<Item>
    {
        private readonly DbContext _context;

        public ItemsRepository(DbContext context/*, IMapper mapper*/) : base(context/*, mapper*/)
        {
            _context = context;
        }

        public async Task<List<ItemView>> GetItemsView()
        {
            return await (_context as DemoWarehouseContext).Items.Select(i => new
            ItemView
            {
                Id = i.Id,
                Name = i.Name,
                Category = i.Category.Name,
                StockQuantity = i.StockQuantity,
                LastUpdated = i.LastUpdated
            }).ToListAsync();
        }
    }
}
