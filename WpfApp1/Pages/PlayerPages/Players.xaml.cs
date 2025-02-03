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
            FillGridPlayerInformation();

            playersRepository  = new PlayersRepositories();

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
                MessageBox.Show("Ошибка. Выберите игрока для удаления");
                return;
            }
            try
            {
                
                playersRepository.DeletePlayerFromDb(DataStorage.CurrentPlayer.Id);
                MessageBox.Show("Игрок был удален");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка. Игрок не был удален");
            }
            FillGridPlayerInformation();

            DataStorage.CurrentPlayer = null;
        }

        private void ButtonUpdatePlayers(object sender, RoutedEventArgs e)
        {
            DataStorage.CurrentPlayer = (Player)GridPlayerInfromation.SelectedItem;
            
            NavigationService.Navigate(new UpdatePlayer());
        }

        private void ButtonGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
