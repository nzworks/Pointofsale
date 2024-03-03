using POS.Data;
using POS.Models;
using POS.Views.Category;
using POS.Views.EventClasses;
using POS.Views.UpdateForms;
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
    /// Interaction logic for FoodCategories.xaml
    /// </summary>
    public partial class FoodCategories : Page
    {
        private readonly CategoryRepo categoryRepo;
        private ObservableCollection<CategoryMdl> categories;
        public FoodCategories()
        {
            InitializeComponent();
            DataContext = this;
            categoryRepo = new CategoryRepo(new PosDbContext());
            LoadCategoriesAsync();
        }

        private async void LoadCategoriesAsync()
        {
            try
            {
                var categoriesList = await Task.Run(() => categoryRepo.GetAllCategories());
                categories = new ObservableCollection<CategoryMdl>(categoriesList);
                categoryDataGrid.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            // Subscribe to the CategoryAdded event of AddCategoryForm
            AddCategoryForm addCategoryForm = addCategoryWindow.AddCategoryFormControl;

            
            addCategoryForm.CategoryAdded += AddCategoryForm_CategoryAdded;


            addCategoryWindow.ShowDialog();
            
        }

        private void AddCategoryForm_CategoryAdded(object sender, CategoryEventArgs e)
        {
            // Add the new category to the ObservableCollection
            categories.Add(e.CategoryAdded);
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the clicked button
            Button button = sender as Button;

            // Get the category associated with the clicked button
            POS.Models.CategoryMdl category = (POS.Models.CategoryMdl)button.DataContext;

            // Assuming you have a method to open the modal form with the category data
            OpenModalFormForEdit(category);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            // Get the category associated with the clicked button
            POS.Models.CategoryMdl category = (POS.Models.CategoryMdl)button.DataContext;
            DeleteCategoryModal delete = new DeleteCategoryModal(category);
            delete.ShowDialog();
            categories.Remove(category);
        }

        private void OpenModalFormForEdit(POS.Models.CategoryMdl category)
        {
            // Create and show the modal form for editing
            UpdateCategoryModal editForm = new UpdateCategoryModal(category);
            editForm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txtSearch.Text;

            if (categories != null)
            {
                // Clear any previous filters
                categoryDataGrid.Items.Filter = null;

                // Apply a new filter based on the search term
                categoryDataGrid.Items.Filter = (obj) =>
                {
                    CategoryMdl category = obj as CategoryMdl;
                    return category.category_name.ToLower().Contains(searchTerm) || // Check if category name contains search term (case-insensitive)
                           category.description.ToLower().Contains(searchTerm); // Check if description contains search term (case-insensitive)
                           
                };
            }
        }
    }
}
