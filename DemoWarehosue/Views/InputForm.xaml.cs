using DemoWarehosue.Models;
using DemoWarehosue.Models.Repository;
using DemoWarehosue.Models.UI;
using DemoWarehosue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
        }

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
    }
}
