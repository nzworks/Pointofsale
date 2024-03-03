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
using System.Windows.Shapes;

namespace POS.Views.Category
{
    /// <summary>
    /// Interaction logic for DeleteCategoryModal.xaml
    /// </summary>
    public partial class DeleteCategoryModal : Window
    {
        public DeleteCategoryModal(POS.Models.CategoryMdl category)
        {
            InitializeComponent();
            DataContext = category;
        }

        private void btnYesDelete_Click(object sender, RoutedEventArgs e)
        {
            int category_id = ((CategoryMdl)DataContext).category_id;

            var categoryRepo = new CategoryRepo(new PosDbContext());
            categoryRepo.DeleteCategory(category_id);

            // Close the delete modal window
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
