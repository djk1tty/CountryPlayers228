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

namespace WpfApp1.Pages.CountryPages
{
    /// <summary>
    /// Логика взаимодействия для AddCountry.xaml
    /// </summary>
    public partial class AddCountry : Page
    {
        private PlayersRepositories playerRepository;
        private CountriesRepositories countriesRepository;
        private PlayersEntities dbConnection;

        public AddCountry()
        {
            InitializeComponent();
            countriesRepository = new CountriesRepositories();
            dbConnection = new PlayersEntities();

        }

        private void ButtonAddCountry(object sender, RoutedEventArgs e)
        {
            if (TextBoxAddCountry.Text.Length == 0)
            {
                MessageBox.Show("Ошибка.Длина названия страны не может быть 0");
                return;
            }

            if (dbConnection.Countries.Any(c => c.CountryName == TextBoxAddCountry.Text))
            {
                MessageBox.Show("Невозожно добавить страну с существующим названием");
                return;
            }
            try
            {
            countriesRepository.AddNewCountryToDb(TextBoxAddCountry.Text);
            MessageBox.Show("Страна успешно создана!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось создать страну");
            }
            EventPagesAggregator.NotifyGridPlayerInfromationDataUpdated();
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
