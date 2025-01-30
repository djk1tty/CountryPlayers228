using System;
using System.Collections.Generic;
using System.Data.Common;
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
using WpfApp1.Repositories;

namespace WpfApp1.Pages.PlayerPages
{
    /// <summary>
    /// Логика взаимодействия для AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Page
    {

        private PlayersRepositories playerRepository;
        private CountriesRepositories countriesRepository;
        private PlayersEntities dbConnection;

        public AddPlayer()
        {
            InitializeComponent();
            playerRepository = new PlayersRepositories();
            countriesRepository = new CountriesRepositories();
            dbConnection = new PlayersEntities();

            CountrySelectComboBox.ItemsSource = countriesRepository.GetAllCountries();
            CountrySelectComboBox.DisplayMemberPath = "CountryName";
        }

        private void ButtonPlayerAdd(object sender, RoutedEventArgs e)
        {
            playerRepository.AddNewPlayerToDb(
            nameBox.Text,
            loginBox.Text,
            passwordBox.Text,
            int.Parse(ageBox.Text),
            ((Country)CountrySelectComboBox.SelectedItem).Id);

            long countryID2 = ((Country)CountrySelectComboBox.SelectedItem).Id;
            var playercount = dbConnection.Countries.Where(x => x.Id == countryID2).First().PlayerCount;
            ////_context.Country.First().PlayerCount++;
            var countryID = dbConnection.Countries.FirstOrDefault(p => p.Id == countryID2);
            EventPagesAggregator.NotifyGridPlayerInfromationDataUpdated();
            if (countryID != null)
            {
                dbConnection.Countries.First().PlayerCount += 1;


                dbConnection.SaveChanges();
            }
            else
            {
                MessageBox.Show("Страна не найдена");
            }
            dbConnection.SaveChanges();
        }
    }
}
