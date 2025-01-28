using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages.CountryPages;
using WpfApp1.PlayersModel;

namespace WpfApp1.Repositories
{
        internal class CountriesRepositories
        {
            private PlayersEntities dbConnection;

            public CountriesRepositories()
            {
                dbConnection = DbConnect.DbConnection;
            }

            public List<Country> GetAllCountries()
            {
                return dbConnection.Countries.ToList();
            }

            public void AddNewCountryToDb(string name)
            {
                var country = new Country()
                {
                    CountryName = name,
                };

                dbConnection.Countries.Add(country);
                dbConnection.SaveChanges();
            }

            public void RemoveCountryFromDb(int id)
            {
                var countries = dbConnection.Countries.Where(ks => ks.Id == id).ToList();
                var country = dbConnection.Countries.Find(id);


                if (countries.Any())
                {
                    dbConnection.Countries.RemoveRange(countries);
                    dbConnection.SaveChanges();
                }

                dbConnection.SaveChanges();
            }
        }
}
