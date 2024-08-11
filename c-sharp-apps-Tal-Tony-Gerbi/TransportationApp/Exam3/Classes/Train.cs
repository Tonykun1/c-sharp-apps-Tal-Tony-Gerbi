using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Train : IShippingPriceCalculator, IContainable
    {
        private const double RatePerKm = 5;
        private int maxVolume;
        private int maxWeight;
        private int currentVolume;
        private int currentWeight;
        private List<IPortable> items;

        public Train(int maxVolume, int maxWeight)
        {
            this.maxVolume = maxVolume;
            this.maxWeight = maxWeight;
            this.items = new List<IPortable>();
            this.currentVolume = 0;
            this.currentWeight = 0;
        }

        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            return units * travelDistance * RatePerKm;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
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

        public bool Load(IPortable item)
        {
            int itemVolume = (int)item.GetVolume();
            int itemWeight = (int)item.GetWeight();
            if (IsHaveRoom(itemVolume, itemWeight) && !IsOverload(itemVolume, itemWeight))
            {
                items.Add(item);
                currentVolume += itemVolume;
                currentWeight += itemWeight;
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            foreach (var item in items)
            {
                if (!Load(item))
                    return false;
            }
            return true;
        }

        public bool Unload(IPortable item)
        {
            if (items.Remove(item))
            {
                currentVolume -= (int)item.GetVolume();
                currentWeight -= (int)item.GetWeight();
                return true;
            }
            return false;
        }

        public bool Unload(List<IPortable> items)
        {
            bool allRemoved = true;
            foreach (var item in items)
            {
                if (!Unload(item))
                    allRemoved = false;
            }
            return allRemoved;
        }

        public bool IsHaveRoom()
        {
            return currentVolume < maxVolume;
        }

        public bool IsHaveRoom(int itemVolume, int itemWeight)
        {
            return (currentVolume + itemVolume) <= maxVolume;
        }

        public bool IsOverload()
        {
            return currentWeight > maxWeight;
        }

        public bool IsOverload(int itemVolume, int itemWeight)
        {
            return (currentWeight + itemWeight) > maxWeight;
        }

        public double GetMaxVolume()
        {
            return maxVolume;
        }

        public double GetMaxWeight()
        {
            return maxWeight;
        }

        public double GetCurrentVolume()
        {
            return currentVolume;
        }

        public double GetCurrentWeight()
        {
            return currentWeight;
        }

        public string GetPricingList()
        {
            return "";
        }
    }

}
