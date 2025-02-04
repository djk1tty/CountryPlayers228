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
using WpfApp1.Repositories;

namespace WpfApp1.Pages.CountryPages
{
    /// <summary>
    /// Логика взаимодействия для Countries.xaml
    /// </summary>
    public partial class Countries : Page
    {
        private PlayersEntities DbConnection;
        private CountriesRepositories CountriesRepositories;
        
        public Countries()
        {
            InitializeComponent();
            FillGridCountryInformation();
            EventPagesAggregator.GridPlayerInfromationDataUpdated += FillGridCountryInformation;
            CountriesRepositories = new CountriesRepositories();
        }

        public void FillGridCountryInformation()
        {
            var data = Connect.DbConnection.Countries.ToList();
            this.GridCountryInfromation.ItemsSource = data;
        }

        private void ButtonAddCountries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCountry());
        }

        private void ButtonDeleteCountries(object sender, RoutedEventArgs e)
        {
            if (GridCountryInfromation.SelectedItem == null)
            {
                MessageBox.Show("Выберите страну для удаления");
                return;
            }
            if (DataStorage.CurrentCountry.PlayerCount > 0)
            {
                MessageBox.Show("Невозможно удалить страну, в которой есть игроки");
                return;
            }
            else
            {
                try
                {
                    CountriesRepositories.RemoveCountryFromDb(DataStorage.CurrentCountry.Id);
                    DataStorage.CurrentCountry = null;
                    MessageBox.Show("Страна успешно удалена!");
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("Не удалось удалить страну"); 
                }
                FillGridCountryInformation();

            }

        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
