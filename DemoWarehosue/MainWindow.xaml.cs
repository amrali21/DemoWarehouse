using DemoWarehosue.Models.Repository;
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

namespace DemoWarehosue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }

        int count = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //(DataContext as MainViewModel).DisplayText = "text changed from parent " + ++count;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Id = (int)((Button)sender).Tag;
            (DataContext as MainViewModel).StartEditMode(Id);
            //(DataContext as MainViewModel).
            // what to do with this id? launch the edit mode.
        }
    }
}
