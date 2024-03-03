using POS.Data;
using POS.Models;
using POS.Views.CustomUserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace POS.Views.FoodItemViews
{
    /// <summary>
    /// Interaction logic for AddFoodItemModal.xaml
    /// </summary>
    public partial class AddFoodItemModal : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MenuItems> foodItems;
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
        public AddFoodItemModal(ObservableCollection<MenuItems> menuItems)
        {
            InitializeComponent();
            this.foodItems = menuItems;
            DataContext = this;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void AddFoodItemModal_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }
        // Load categories into ComboBox when the window is loaded
        private async void LoadCategories()
        {
            try
            {
                var categoryRepo = new CategoryRepo(new PosDbContext());
                var categories = await Task.Run(() => categoryRepo.GetAllCategories());
                Categories = new ObservableCollection<CategoryMdl>(categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve data from input fields
                string foodItemName = txtFoodItemName.Text;
                string description = txtDescription.Text;
                decimal price;
                bool isPriceValid = decimal.TryParse(txtPrice.Text, out price); // Try to parse the price as an integer

                // Get selected categories
                List<CategoryMdl> selectedCategories = comboBoxMulti.SelectedItems.Cast<CategoryMdl>().ToList();

                // Validate input data
                if (string.IsNullOrWhiteSpace(foodItemName) || selectedCategories.Count == 0 || !isPriceValid)
                {
                    MessageBox.Show("Please fill in all required fields with valid data and select at least one category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Create a new MenuItems instance
                MenuItems newMenuItem = new MenuItems
                {
                    item_name = foodItemName,
                    item_description = description,
                    item_price = price // Assign the parsed price to the item_price property
                };

                

                // Add the new food item to the database
                var menuItemsRepo = new MenuItemsRepo(new PosDbContext());
                menuItemsRepo.AddMenuItem(newMenuItem);

                foreach (var category in selectedCategories)
                {
                    MenuItemCategory menuItemCategory = new MenuItemCategory
                    {
                        MenuItemId = newMenuItem.menuitem_id,
                        CategoryId = category.category_id
                    };
                    menuItemsRepo.AddMenuItemCategory(menuItemCategory); // Add MenuItemCategory to the database
                }

                // Show success message
                MessageBox.Show("Food item added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Close the modal window
                Close();
            }
            catch (Exception ex)
            {
                // Show error message if an exception occurs
                MessageBox.Show($"An error occurred while adding the food item: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                if (ex.InnerException != null)
                {
                    // Display inner exception details
                    MessageBox.Show($"Inner Exception: {ex.InnerException.Message}", "Inner Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }
}
