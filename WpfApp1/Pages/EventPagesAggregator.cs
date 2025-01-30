using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Pages
{
    internal static class EventPagesAggregator
    {
        public static event Action GridPlayerInfromationDataUpdated;

        public static void NotifyGridPlayerInfromationDataUpdated()
        {
            GridPlayerInfromationDataUpdated.Invoke();
        }
    }

}
