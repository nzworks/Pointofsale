using POS.Data;
using POS.Models;
using POS.Views.FoodItemViews;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for FoodItems.xaml
    /// </summary>
    public partial class FoodItems : Page
    {
        private readonly MenuItemsRepo foodItemRepo;
        private ObservableCollection<MenuItems> foodItems;
        public FoodItems()
        {
            InitializeComponent();
            DataContext = this;
            foodItemRepo = new MenuItemsRepo(new PosDbContext());
            LoadFoodItemsAsync();
        }

        private async void LoadFoodItemsAsync()
        {
            try
            {
                var categoryRepo = new CategoryRepo(new PosDbContext());
                var foodList = await Task.Run(() => foodItemRepo.GetAllMenuItemsWithCategories());

                foreach (var foodItem in foodList)
                {
                    /*foodItem.Category = await Task.Run(() => categoryRepo.GetCategoryById(foodItem.category_id));*/
                }
                foodItems = new ObservableCollection<MenuItems>(foodList);
                foodItemDataGrid.ItemsSource = foodItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddFoodItem_Click(object sender, RoutedEventArgs e)
        {

            AddFoodItemModal addFoodItemModal = new AddFoodItemModal(foodItems);
            addFoodItemModal.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MenuItems menuItems = (MenuItems)button.DataContext;
            UpdateFoodItemModal updateFoodItemModal= new UpdateFoodItemModal(menuItems);
            updateFoodItemModal.ShowDialog();

            if (updateFoodItemModal.DialogResult == true)
            {
                // Update the foodItems collection with the modified menuItems object
                int index = foodItems.IndexOf(menuItems);
                foodItems[index] = updateFoodItemModal.DataContext as MenuItems;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
