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
    /// Логика взаимодействия для Players.xaml
    /// </summary>
    public partial class Players : Page
    {
        private PlayersRepositories playersRepository;
        public Players()
        {
            InitializeComponent();

            playersRepository  = new PlayersRepositories();

            FillGridPlayerInformation();

            EventPagesAggregator.GridPlayerInfromationDataUpdated += FillGridPlayerInformation;
        }
        public void FillGridPlayerInformation()
        {
            this.GridPlayerInfromation.ItemsSource = playersRepository.GetAllPlayers();
        }
        private void ButtonAddPlayers(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPlayer());
        }

        private void ButtonDeletePlayers(object sender, RoutedEventArgs e)
        {
            DataStorage.CurrentPlayer = (Player)GridPlayerInfromation.SelectedItem;
            if(DataStorage.CurrentPlayer == null)
            {
                MessageBox.Show("Ошибкаю Выберите игрока для удаления")
                return;
            }
            playersRepository.DeletePlayerFromDb(DataStorage.CurrentPlayer.Id);

            FillGridPlayerInformation();

            DataStorage.CurrentPlayer = null;
        }

        private void ButtonUpdatePlayers(object sender, RoutedEventArgs e)
        {
            DataStorage.CurrentPlayer = (Player)GridPlayerInfromation.SelectedItem;
            
            NavigationService.Navigate(new UpdatePlayer());
        }
    }
}
