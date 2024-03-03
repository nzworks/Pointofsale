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

namespace POS.Views.CustomUserControls
{
    /// <summary>
    /// Interaction logic for CheckBoxLists.xaml
    /// </summary>
    public partial class CheckBoxLists : UserControl
    {
        public static readonly DependencyProperty CategoriesProperty = DependencyProperty.Register("Categories", typeof(IEnumerable<CategoryMdl>), typeof(CheckBoxLists));

        public IEnumerable<CategoryMdl> Categories
        {
            get { return (IEnumerable<CategoryMdl>)GetValue(CategoriesProperty); }
            set { SetValue(CategoriesProperty, value); }
        }
        public CheckBoxLists()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
