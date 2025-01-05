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
        
        public RepoWrapper()
        {
            itemsRepository = new ItemsRepository(DemoWarehouseContext.Instance);
            gategoryRepository = new CategoryRepository(DemoWarehouseContext.Instance);
        }

    }
}
