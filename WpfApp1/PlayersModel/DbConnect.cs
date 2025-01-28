using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.PlayersModel
{
    internal class DbConnect
    {
        public static PlayersEntities DbConnection
        {
            get
            {
                return new PlayersEntities();
            }
        }
    }
}
