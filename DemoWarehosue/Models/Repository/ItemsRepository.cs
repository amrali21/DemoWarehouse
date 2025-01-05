using AutoMapper;
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
    }
}
