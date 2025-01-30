using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using WpfApp1.Pages.PlayerPages;
using WpfApp1.PlayersModel;

namespace WpfApp1.Repositories
{
    internal class PlayersRepositories
    {
        private PlayersEntities dbConnection;

        public PlayersRepositories()
        {
            dbConnection = DbConnect.DbConnection;
        }
        public List<Player> GetAllPlayers()
        {
            return dbConnection.Players.ToList();
        }

        public void AddNewPlayerToDb(string login, string password, string name, int age, long countryID)
        {
            var player = new Player()
            {
                Name = name,
                Login = login,
                Password = password,
                CountryId = countryID,
                Age = age,
            };

            dbConnection.Players.Add(player);
            dbConnection.SaveChanges();
        }

        public void DeletePlayerFromDb(string login)
        {
            try
            {
                var players = dbConnection.Players.Where(ks => ks.Login == login).ToList();
                var player = dbConnection.Players.Find(login);
                dbConnection.Players.Remove(player);
                dbConnection.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка, не удалось удалить игрока из базы данных.");
            }
        }
        public void UpdatePlayerInDb(string name, string password,  int age, long countryID)
        {
            var player = new Player()
            {
                Name = name,
                Password = password,
                CountryId = countryID,
                Age = age,
            };

            dbConnection.SaveChanges();
        }
    }
}
