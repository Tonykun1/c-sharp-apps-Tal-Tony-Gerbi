using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public  class Train:IShippingPriceCalculator
    {
        private const double RatePerKm = 5;

        public  double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            return units * travelDistance * RatePerKm;
        }

        public  double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            int totalUnits = 0;
            foreach (var item in items)
            {
                totalUnits += CalculateUnits(item);
            }
            return totalUnits * travelDistance * RatePerKm;
        }

        private int CalculateUnits(IPortable item)
        {
            int units = (int)(item.GetVolume() / 100) + (int)item.GetWeight();
            if (item.IsFragile())
            {
                units *= 2;
            }
            return units;
        }
    }
}
