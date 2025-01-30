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
            countriesRepository.AddNewCountryToDb(
                TextBoxAddCountry.Text);
        }
    }
}
