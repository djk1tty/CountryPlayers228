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

namespace WpfApp1.Pages.PlayerPages
{
    /// <summary>
    /// Логика взаимодействия для Players.xaml
    /// </summary>
    public partial class Players : Page
    {
        public Players()
        {
            InitializeComponent();
        }
        private void AddPlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPlayer());
        }

        private void DeletePlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeletePlayer());
        }

        private void UpdatePlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdatePlayer());
        }

        private void ShowPlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShowPlayers());
        }
    }
}
