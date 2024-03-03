using MahApps.Metro.Controls;
using POS.Data;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace POS.Views.FoodItemViews
{
    /// <summary>
    /// Interaction logic for UpdateFoodItemModal.xaml
    /// </summary>
    public partial class UpdateFoodItemModal : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<CategoryMdl> _categories;
        public ObservableCollection<CategoryMdl> Categories
        {
            get { return _categories; }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    OnPropertyChanged();
                }
            }
        }

        public UpdateFoodItemModal(MenuItems menuItems)
        {
            InitializeComponent();
            DataContext = menuItems;
        }

        private void AddFoodItemModal_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }

        private async void LoadCategories()
        {
            try
            {
                var categoryRepo = new CategoryRepo(new PosDbContext());
                var categories = await Task.Run(() => categoryRepo.GetAllCategories());
                Categories = new ObservableCollection<CategoryMdl>(categories);
                /*cmbCategory.SelectedItem = _menuItem.Categories.FirstOrDefault();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MenuItemsRepo itemsRepo = new MenuItemsRepo(new PosDbContext());
                MenuItems menuItemToUpdate = DataContext as MenuItems;
                string itemName = txtFoodItemName.Text;
                string itemDescription = txtDescription.Text;
                decimal itemPrice;
                bool isPriceValid = decimal.TryParse(txtPrice.Text, out itemPrice); // Try to parse the price as an integer
                CategoryMdl selectedCategory = cmbCategory.SelectedItem as CategoryMdl;

                // Validate input data
                if (string.IsNullOrWhiteSpace(itemName) || selectedCategory == null || !isPriceValid)
                {
                    MessageBox.Show("Please fill in all required fields with valid data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                menuItemToUpdate.item_name = itemName;
                menuItemToUpdate.item_description = itemDescription;
                menuItemToUpdate.item_price = itemPrice;

                itemsRepo.UpdateMenuItem(menuItemToUpdate);

                MessageBox.Show("Menu item updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the food item: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
