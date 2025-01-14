using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWarehosue.Models.Repository
{
    public class RepoWrapper
    {
        public ItemsRepository itemsRepository { get; set; }
        public CategoryRepository gategoryRepository { get; set; }

        public RepoWrapper() {
            DbContext _context = new DemoWarehouseContext();

            itemsRepository = new ItemsRepository(_context);
            gategoryRepository = new CategoryRepository(_context);
        }

    }
}
