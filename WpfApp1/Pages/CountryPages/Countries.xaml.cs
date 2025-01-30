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
using WpfApp1.Pages.PlayerPages;
using WpfApp1.PlayersModel;

namespace WpfApp1.Pages.CountryPages
{
    /// <summary>
    /// Логика взаимодействия для Countries.xaml
    /// </summary>
    public partial class Countries : Page
    {
        private PlayersEntities DbConnection;
        public Countries()
        {
            InitializeComponent();
            FillGridCountryInformation();
            EventPagesAggregator.GridPlayerInfromationDataUpdated += FillGridCountryInformation;
        }
        public void FillGridCountryInformation()
        {
            var data = Connect.conn.Countries.ToList();
            this.GridCountryInfromation.ItemsSource = data;
        }
        private void ButtonAddCountries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCountry());
        }

        private void ButtonDeleteCountries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeleteCountry());
        }

    }
}
