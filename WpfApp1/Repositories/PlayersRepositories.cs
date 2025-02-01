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
            dbConnection = Connect.DbConnection;
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

        public void DeletePlayerFromDb(long id)
        {
            var players = dbConnection.Players.Where(ks => ks.Id == id).ToList();
            var player = dbConnection.Players.Find(id);
            dbConnection.Players.Remove(player);
            dbConnection.SaveChanges();
        }
        public void UpdatePlayerInDb(long id, string newName, string newPassword, int newAge, long countryID)
        {
            var player = dbConnection.Players.FirstOrDefault(p => p.Id == id);

            player.Name = newName;
            player.Password = newPassword;
            player.Age = newAge;
            player.CountryId = countryID;

            dbConnection.SaveChanges();
        }
    }
}
