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
using WpfApp1.PlayersModel;

namespace WpfApp1.Pages.PlayerPages
{
    /// <summary>
    /// Логика взаимодействия для Players.xaml
    /// </summary>
    public partial class Players : Page
    {
        private PlayersEntities dbConnect;
        public void FillGridPlayerInformation()
        {
            this.GridPlayerInfromation.ItemsSource = dbConnect.Players.ToList();
        }
        public Players()
        {
            InitializeComponent();
            FillGridPlayerInformation();
            EventPagesAggregator.GridPlayerInfromationDataUpdated += FillGridPlayerInformation;
        }
        private void ButtonAddPlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPlayer());
        }

        private void ButtonDeletePlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeletePlayer());
        }

        private void ButtonUpdatePlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdatePlayer());
        }
    }
}
