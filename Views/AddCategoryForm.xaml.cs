using System;
using System.Windows;
using System.Windows.Controls;
using POS.Models;
using POS.Data;
using POS.Views.EventClasses;

namespace POS.Views
{
    /// <summary>
    /// Interaction logic for AddCategoryForm.xaml
    /// </summary>
    public partial class AddCategoryForm : UserControl
    {
        public event EventHandler<CategoryEventArgs> CategoryAdded;

        public AddCategoryForm()
        {
            InitializeComponent();
        }

       

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CategoryRepo _categoryRepo = new CategoryRepo(new PosDbContext());
                // Create a new Category object with data from the form
                POS.Models.CategoryMdl newCategory = new POS.Models.CategoryMdl
                {
                    category_name = txtCategoryName.Text,
                    description = txtDescription.Text
                    // Add additional properties as needed
                };

                // Save the new category to the database
                _categoryRepo.AddCategory(newCategory);

                CategoryAdded?.Invoke(this, new CategoryEventArgs(newCategory));

                // Show a success message
                MessageBox.Show("Category added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Close the parent window or user control
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.Close();
                }
                else
                {
                    UserControl parentUserControl = Parent as UserControl;
                    if (parentUserControl != null)
                    {
                        var parentGrid = parentUserControl.Parent as Grid;
                        if (parentGrid != null)
                        {
                            parentGrid.Children.Remove(parentUserControl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show($"An error occurred while adding the category: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                if (ex.InnerException != null)
                {
                    // Display inner exception details
                    MessageBox.Show($"Inner Exception: {ex.InnerException.Message}", "Inner Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the parent window or user control
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
            else
            {
                UserControl parentUserControl = Parent as UserControl;
                if (parentUserControl != null)
                {
                    var parentGrid = parentUserControl.Parent as Grid;
                    if (parentGrid != null)
                    {
                        parentGrid.Children.Remove(parentUserControl);
                    }
                }
            }
        }
    }
}
