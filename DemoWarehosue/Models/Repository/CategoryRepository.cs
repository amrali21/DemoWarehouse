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
    public class CategoryRepository : GenericRepository<Category>
    {
        private readonly DbContext _context;

        public CategoryRepository(DbContext context/*, IMapper mapper*/) : base(context/*, mapper*/)
        {
            _context = context;
        }

        public async Task<List<CategoryView>> GetCategoriesView()
        {
            return await (_context as DemoWarehouseContext).Categories.Select(i => new
            CategoryView
            {
                Id = i.Id,
                Name = i.Name
            }).ToListAsync();
        }
    }
}
