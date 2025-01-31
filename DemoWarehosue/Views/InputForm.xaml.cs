﻿using DemoWarehosue.Models;
using DemoWarehosue.Models.Repository;
using DemoWarehosue.Models.UI;
using DemoWarehosue.ViewModels;
using SpectroBridge;
using SpectroBridge.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            this.wp = new RepoWrapper();

            _ = loadData();
        }

        async Task loadData()
        {
            try
            {
                Categories3 = await wp.gategoryRepository.GetCategoriesView();

            }
            catch (Exception ex) 
            {
                SafeMessageBox.Show($"{ex.Message}", "Error fetching category data", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }


        public static readonly DependencyProperty MyItemProperty =
            DependencyProperty.Register("MyItem", typeof(PutItem), typeof(InputForm), new PropertyMetadata(new PutItem()));

        public static readonly DependencyProperty EditModeProperty =
            DependencyProperty.Register("EditMode", typeof(bool), typeof(InputForm), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty CategoriesProperty =
            DependencyProperty.Register("Categories", typeof(List<CategoryView>), typeof(InputForm), new PropertyMetadata(new List<CategoryView>()));

        public static readonly DependencyProperty SelectedCategoryProperty =
            DependencyProperty.Register("SelectedCategory", typeof(CategoryView), typeof(InputForm), new PropertyMetadata(new CategoryView()));


        public RepoWrapper wp { get; set; }
        public PutItem MyItem { get => (PutItem)GetValue(MyItemProperty); set => SetValue(MyItemProperty, value); }
        public bool? EditMode { get => (bool)GetValue(EditModeProperty); set => SetValue(EditModeProperty, value); }
        public List<CategoryView> Categories3 { get => (List<CategoryView>)GetValue(CategoriesProperty); set => SetValue(CategoriesProperty, value); }
        public CategoryView SelectedCategory { get => (CategoryView)GetValue(SelectedCategoryProperty); set { SetValue(SelectedCategoryProperty, value); MyItem.CategoryId = value.Id; } }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MyItem.Name == "" || MyItem.CategoryId == 0 || MyItem.StockQuantity == null)
            {
                SafeMessageBox.Show($"Please fill all missing data", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Warning); 
                
                return;
            }


            if (EditMode != false)
            {
                await  wp.itemsRepository.UpdateAsync(
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
                await wp.itemsRepository.AddAsync(
                    new Item
                    {
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
