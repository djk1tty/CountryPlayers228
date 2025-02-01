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
    /// Логика взаимодействия для DeletePlayer.xaml
    /// </summary>
    public partial class DeletePlayer : Page
    {
        PlayersRepositories playersRepository;
        public DeletePlayer()
        {
            InitializeComponent();
            playersRepository = new PlayersRepositories();
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
