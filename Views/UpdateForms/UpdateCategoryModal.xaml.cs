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

namespace POS.Views.UpdateForms
{
    /// <summary>
    /// Interaction logic for UpdateCategoryModal.xaml
    /// </summary>
    public partial class UpdateCategoryModal : Window
    {
        
        public UpdateCategoryModal(POS.Models.CategoryMdl category)
        {
            
            InitializeComponent();
            DataContext = category;
            
        }
    }
}
