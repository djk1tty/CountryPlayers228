using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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
        private Player playerCountry;

        public AddPlayer()
        {
            InitializeComponent();
            
            playerRepository = new PlayersRepositories();
            countriesRepository = new CountriesRepositories();
            dbConnection = new PlayersEntities();
            playerCountry = new Player();

            CountrySelectComboBox.ItemsSource = countriesRepository.GetAllCountries();
            CountrySelectComboBox.DisplayMemberPath = "CountryName";
        }

        private void ButtonPlayerAdd(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text.Length == 0) 
            {
                MessageBox.Show("Ошибка. Длина имени не может быть 0");
                return;
            }

            if (loginBox.Text.Length == 0) 
            {
                MessageBox.Show("Ошибка. Длина логина не может быть 0");
                return;
            }

            if (passwordBox.Text.Length == 0) 
            {
                MessageBox.Show("Ошибка. Длина пароля не может быть 0");
                return;
            }

            if (ageBox.Text.Length == 0) 
            {
                MessageBox.Show("Ошибка. Длина возраста не может быть 0");
                return;
            }

            if (CountrySelectComboBox.SelectedItem == null) 
            {
                MessageBox.Show("Ошибка. Выберите страну проживания");
                return;     
            }

            try
            {
                playerRepository.AddNewPlayerToDb(
                nameBox.Text,
                loginBox.Text,
                passwordBox.Text,
                int.Parse(ageBox.Text),
                ((Country)CountrySelectComboBox.SelectedItem).Id);
                MessageBox.Show("Игрок добавлен!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка добавления игрока в таблицу.");
            }
            EventPagesAggregator.NotifyGridPlayerInfromationDataUpdated();
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
