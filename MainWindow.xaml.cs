using POS.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                if (clickedButton.Name == "menu_settings")
                {
                    contentFrame.Navigate(new Uri("Views/SettingsView.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Regular button clicked");
                }
            }
        }

        private void NavigateToPage(Page page)
        {
            
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}