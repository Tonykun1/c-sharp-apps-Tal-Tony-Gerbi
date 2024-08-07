using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class ShippingPriceCalculator : IShippingPriceCalculator
    {
        private double ratePerKm;

        public ShippingPriceCalculator(double ratePerKm)
        {
            this.ratePerKm = ratePerKm;
        }

        public double CalculatePrice(IPortable item, int travelDistance)
        {
            double units = item.GetVolume() / 100 + item.GetWeight();
            if (item.IsFragile())
            {
                units *= 2;
            }
            return units * travelDistance * ratePerKm;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            double totalUnits = 0;
            for (int i = 0; i < items.Count; i++)
            {
                double units = items[i].GetVolume() / 100 + items[i].GetWeight();
                if (items[i].IsFragile())
                {
                    units *= 2;
                }
                totalUnits += units;
            }
            return totalUnits * travelDistance * ratePerKm;
        }
    }
}
