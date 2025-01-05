using DemoWarehosue.Models;
using DemoWarehosue.Models.Repository;
using SpectroBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWarehosue.ViewModels
{
    class MainViewModel: BaseNotifyPropertyChanged
    {
        // model for list body
        // 
        public List<Item> allItems { get; set; }

        public MainViewModel()
        {
            //allItems = await RepoWrapper.Instance.itemsRepository.GetAllAsync()
        }

        void fetchAllItems()
        {

        }
    }
}
