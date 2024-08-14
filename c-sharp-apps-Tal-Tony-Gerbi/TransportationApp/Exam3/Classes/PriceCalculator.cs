using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class PriceCalculator : IShippingPriceCalculator
    {
        private CargoType type; 
        private double price;

        public PriceCalculator(CargoType type, double price)
        {
            this.type = type;
            this.price = price;
        }

        private double CalculateUnits(IPortable item)
        {
            double units = item.GetVolume() / 100 + item.GetWeight();
            if (item.IsFragile())
            {
                units *= 2;
            }
            return units;
        }

        public double CalculatePrice(IPortable item, int travelDistance)
        {
            double units = CalculateUnits(item);
            return units * travelDistance * price;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            double totalUnits = 0;
            for (int i = 0; i < items.Count; i++)
            {
                totalUnits += CalculateUnits(items[i]);
            }
            return totalUnits * travelDistance * price;
        }
    }
}

