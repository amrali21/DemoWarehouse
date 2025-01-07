using DemoWarehosue.Models;
using DemoWarehosue.Models.Repository;
using DemoWarehosue.Models.UI;
using DemoWarehosue.ViewModels;
using SpectroBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWarehosue.Views
{
    /// <summary>
    /// Interaction logic for InputForm.xaml
    /// </summary>
    public partial class InputForm : UserControl
    {
        public InputForm()
        {
            InitializeComponent();
            _ = loadData();
        }

        async Task loadData()
        {
            try
            {
                await Task.Delay(1000);
                Categories = await RepoWrapper.Instance.gategoryRepository.GetAllAsync();
            }
            catch (Exception ex) 
            { 
            
            }
        }


        string _TestProp = "test label content";
        public string TestProp { get => _TestProp; set { _TestProp = value; OnPropertyChanged(nameof(TestProp)); } }


        List<string> _tests = new List<string> { "hi", "hi2", "hi3" };
        public List<string> tests { get => _tests; set { _tests = value; OnPropertyChanged(nameof(tests)); } }


        List<Category> _Categories;
        public List<Category> Categories { get => _Categories; set { _Categories = value; OnPropertyChanged(nameof(Categories)); } }


        Category _SelectedCategory;
        Category SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(nameof(SelectedCategory)); } }



        public static readonly DependencyProperty MyItemProperty =
            DependencyProperty.Register("MyItem", typeof(PutItem), typeof(InputForm), new PropertyMetadata(new PutItem()));

        public static readonly DependencyProperty EditModeProperty =
            DependencyProperty.Register("EditMode", typeof(bool), typeof(InputForm), new PropertyMetadata(default(bool)));

        public PutItem MyItem
        {
            get => (PutItem)GetValue(MyItemProperty);
            set => SetValue(MyItemProperty, value);
        }

        public bool? EditMode
        {
            get => (bool)GetValue(EditModeProperty);
            set => SetValue(EditModeProperty, value);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EditMode != false)
            {
                await  RepoWrapper.Instance.itemsRepository.UpdateAsync(
                    new Item { 
                        Id = MyItem.Id,
                        Name = MyItem.Name, 
                        CategoryId = MyItem.CategoryId, 
                        StockQuantity = MyItem.StockQuantity,
                        LastUpdated = DateTime.Now
                    });

                // reset
                CancelEdit();
                // exit edit mode
            }
            else {
                await RepoWrapper.Instance.itemsRepository.AddAsync(
                    new Item
                    {
                        Id = MyItem.Id,
                        Name = MyItem.Name,
                        CategoryId = MyItem.CategoryId,
                        StockQuantity = MyItem.StockQuantity,
                        LastUpdated = DateTime.Now
                    });

                Reset();
                // reset
            }
        }

        private void Reset() =>
            MyItem = new PutItem();

        private void CancelEdit()
        {
            EditMode = false;
            Reset();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
