using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public class IPriceCalculator:IShippingPriceCalculator
    {
        private const double TrainRate = 5;
        private const double ShipRate = 20;
        private const double AirplaneRate = 50;

        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int unitCount = CalculateUnitCount(item);
            double rate = GetRate(item);
            return unitCount * travelDistance * rate;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            int totalUnits = 0;

            for (int i = 0; i<items.Count; i++)
            {
                totalUnits += CalculateUnitCount(items[i]);
            }
            double rate = GetRate(items[0]); 
            return totalUnits * travelDistance * rate;
        }

        private int CalculateUnitCount(IPortable item)
        {
            int volumeUnits = (int)(item.GetVolume() / 100);
            int weightUnits = (int)item.GetWeight();
            int unitCount = volumeUnits + weightUnits;

            if (item.IsFragile() || item is ElectricDevice) 
            {
                unitCount *= 2;
            }

            return unitCount;
        }

        private double GetRate(IPortable item)
        {
            return TrainRate;
        }
    }
}
