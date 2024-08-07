using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Crone : IContainable
    {
        private int maxVolume;
        private int maxWeight;
        private int currentVolume;
        private int currentWeight;
        private List<IPortable> items;
        private int maxCapacity;

        public Crone(int maxVolume, int maxWeight, int maxCapacity)
        {
            this.maxVolume = maxVolume;
            this.maxWeight = maxWeight;
            this.maxCapacity = maxCapacity;
            this.currentVolume = 0;
            this.currentWeight = 0;
            this.items = new List<IPortable>();
        }

        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                items.Add(item);
                currentVolume += (int)item.GetVolume();
                currentWeight += (int)item.GetWeight();
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            foreach (var item in items)
            {
                if (!Load(item))
                {
                    return false; 
                }
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
            foreach (var item in items)
            {
                if (!Unload(item))
                {
                    return false; 
                }
            }
            return true;
        }

        public bool IsHaveRoom()
        {
            return items.Count < maxCapacity;
        }

        public bool IsOverload()
        {
            return currentVolume > maxVolume || currentWeight > maxWeight;
        }

        public int GetMaxVolume()
        {
            return maxVolume;
        }

        public int GetMaxWeight()
        {
            return maxWeight;
        }

        public int GetCurrentVolume()
        {
            return currentVolume;
        }

        public int GetCurrentWeight()
        {
            return currentWeight;
        }

        public string GetPricingList()
        {
            // Implement pricing logic if needed
            return "Pricing information";
        }
    }
}
