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
using WpfApp1.Repositories;

namespace WpfApp1.Pages.CountryPages
{
    /// <summary>
    /// Логика взаимодействия для DeleteCountry.xaml
    /// </summary>
    public partial class DeleteCountry : Page
    {
        CountriesRepositories countriesRepository;
        public DeleteCountry()
        {
            InitializeComponent();
            countriesRepository = new CountriesRepositories();
        }

        private void ButtonDeleteCountry(object sender, RoutedEventArgs e)
        {
            countriesRepository.RemoveCountryFromDb(TextBoxDeleteCountry.Text);
            EventPagesAggregator.NotifyGridPlayerInfromationDataUpdated();
        }
    }
}
