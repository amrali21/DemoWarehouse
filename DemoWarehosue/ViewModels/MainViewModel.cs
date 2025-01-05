using DemoWarehosue.Models;
using DemoWarehosue.Models.Repository;
using DemoWarehosue.Models.UI;
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
        private List<ItemView> _allItems = new List<ItemView>();
        public List<ItemView> allItems { get => _allItems; set { _allItems = value; OnPropertyChanged(); } }

        public MainViewModel()
        {
            _ = fetchAllItems();
        }

        async Task fetchAllItems()
        {

            try
            {
                allItems = await RepoWrapper.Instance.itemsRepository.GetItemsView();

            }catch(Exception e)
            {

            }
        }
    }
}
