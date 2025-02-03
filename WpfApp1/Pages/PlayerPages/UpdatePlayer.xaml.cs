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

            var countries = countriesRepositories.GetAllCountries();

            ComboBoxPlayerCountry.ItemsSource = countries;
            ComboBoxPlayerCountry.DisplayMemberPath = "CountryName";
            ComboBoxPlayerCountry.SelectedIndex = countries.FindIndex(item => item.Id == DataStorage.CurrentPlayer.CountryId);

            TextBoxName.Text = DataStorage.CurrentPlayer.Name;
            TextBoxPassword.Text = DataStorage.CurrentPlayer.Password;
            TextBoxAge.Text = DataStorage.CurrentPlayer.Age.ToString();
        }

        private void ButtonUpdate(object sender, RoutedEventArgs e)
        {
            if(TextBoxName.Text.Length == 0)
            {
                MessageBox.Show("Ошибка. Длина имени не может быть 0");
                return;
            }

            else if(TextBoxAge.Text.Length == 0)
            {
                MessageBox.Show("Ошибка. Длина возраста не может быть 0");
                return;
            }

            else if(TextBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("Ошибка. Длина пароля не может быть 0");
                return;
            }

            else if(ComboBoxPlayerCountry.SelectedItem == null)
            {
                MessageBox.Show("Ошибка. Выберите страну");
                return;
            }
            try
            {
                playerRepositories.UpdatePlayerInDb(
                    DataStorage.CurrentPlayer.Id,
                    TextBoxName.Text,
                    TextBoxPassword.Text,
                    int.Parse(TextBoxAge.Text),
                    ((Country)(ComboBoxPlayerCountry).SelectedItem).Id
                );

                MessageBox.Show("Игрок успешно обновлён.");

                EventPagesAggregator.NotifyGridPlayerInfromationDataUpdated();

                DataStorage.CurrentPlayer = null;
            }
            catch
            {
                MessageBox.Show("Ошибка обновления игрока.");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
