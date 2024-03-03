using POS.Data;
using POS.Models;
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

namespace POS.Views.UpdateForms
{
    /// <summary>
    /// Interaction logic for UpdateCategoryForm.xaml
    /// </summary>
    public partial class UpdateCategoryForm : UserControl
    {

        

        public UpdateCategoryForm()
        {
            
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a new instance of the Category class and update its properties
                POS.Models.CategoryMdl updatedCategory = new POS.Models.CategoryMdl
                {
                    category_id = ((POS.Models.CategoryMdl)DataContext).category_id, // Get the category_id from DataContext
                    category_name = txtCategoryName.Text,
                    description = txtDescription.Text,
                    // Update other properties as needed
                };

                // Use the CategoryRepo to update the category
                var categoryRepo = new CategoryRepo(new PosDbContext());
                categoryRepo.UpdateCategory(updatedCategory);

                // Show a success message
                MessageBox.Show("Category Updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Close the update form
                CloseWindow();
            }catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show($"An error occurred while adding the category: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void CloseWindow()
        {
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
