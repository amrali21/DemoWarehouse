using DemoWarehosue.Models;
using DemoWarehosue.Models.Repository;
using DemoWarehosue.Models.UI;
using DemoWarehosue.ViewModels.Common;
using SpectroBridge;
using SpectroBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoWarehosue.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        private List<ItemView> _allItems = new List<ItemView>();
        public List<ItemView> allItems { get => _allItems; set { _allItems = value; OnPropertyChanged(); } }


        PutItem currentItem = new();
        public PutItem CurrentItem { get => currentItem; set { currentItem = value; OnPropertyChanged(nameof(CurrentItem)); } }


        bool _EditMode = false;
        public bool EditMode { get => _EditMode; set { _EditMode = value; OnPropertyChanged(); } }



        Command _EditCommand;
        public Command EditCommand { get => _EditCommand; set { 
                _EditCommand = value;
                OnPropertyChanged(nameof(EditCommand)); } }

        public MainViewModel()
        {
            _ = fetchAllItems();
            EditCommand = new((o) =>
            {
                StartEditMode((int)o);

            }, (o) => true);
        }

        // what action do we want to execute? same logic

        async Task fetchAllItems()
        {

            try
            {
                RepoWrapper wp = new();
                allItems = await wp.itemsRepository.GetItemsView();
            }
            catch (Exception e)
            {
                SafeMessageBox.Show($"{e.Message}", "Error loading items data", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public void StartEditMode(int Id)
        {
            EditMode = true;
            CurrentItem = allItems.Where(i => i.Id == Id)
                .Select(i => new PutItem
            {
                Id = i.Id,
                Name = i.Name,
                CategoryId = i.CategoryId,
                StockQuantity = i.StockQuantity
            }).First();
        }
    }
}
