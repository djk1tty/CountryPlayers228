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
using WpfApp1.Repositories;

namespace WpfApp1.Pages.PlayerPages
{
    /// <summary>
    /// Логика взаимодействия для UpdatePlayer.xaml
    /// </summary>
    public partial class UpdatePlayer : Page
    {
        private PlayersRepositories playerRepositories;
        private CountriesRepositories countriesRepositories;
        public UpdatePlayer()
        {
            InitializeComponent();
            
            playerRepositories = new PlayersRepositories();
            countriesRepositories = new CountriesRepositories();

            PlayerLoginComboBox.ItemsSource = playerRepositories.GetAllPlayers();
            PlayerLoginComboBox.DisplayMemberPath = "Login";

            ComboBoxPlayerCountry.ItemsSource = countriesRepositories.GetAllCountries();
            ComboBoxPlayerCountry.DisplayMemberPath = "CountryName";
        }

        private void PlayerLoginComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxName.Text = ((Player)PlayerLoginComboBox.SelectedItem).Name;
            TextBoxPassword.Text = ((Player)PlayerLoginComboBox.SelectedItem).Password;
            TextBoxAge.Text = ((Player)PlayerLoginComboBox.SelectedItem).Age.ToString();
        }
        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            playerRepositories.UpdatePlayerInDb(
                TextBoxName.Text,
                TextBoxPassword.Text,
                int.Parse(TextBoxAge.Text),
                ((Country)(ComboBoxPlayerCountry).SelectedItem).Id
            );
            EventPagesAggregator.NotifyGridPlayerInfromationDataUpdated();
        }
    }
}
