using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public abstract class CarGoVehicleTransport: IContainable
    {
        private Driver driver;
        private int maximum_Weight;
        private int maximum_Volume;
        private bool ready_To_Go;
        private bool over_Weight;
        private string current_Port;
        private string next_Port;
        private int next_Port_Distance;
        private double price;
        private int id = new Random().Next(1000, 10000);
        private List<IPortable> items;
        private ShippingPriceCalculator ShippingPriceCalculator;

        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                items.Add(item);
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!Load(items[i]))
                    return false;
            }
            return true;
        }

        public bool Unload(IPortable item)
        {
            return items.Remove(item);
        }

        public bool Unload(List<IPortable> items)
        {
            bool allRemoved = true;
            for (int i = 0; i < items.Count; i++)
            {
                if (!Unload(items[i]))
                    allRemoved = false;
            }
            return allRemoved;
        }

        public bool IsHaveRoom()
        {
            return GetCurrentVolume() < GetMaxVolume();
        }

        public bool IsOverload()
        {
            return GetCurrentWeight() > GetMaxWeight();
        }

        public int GetMaxVolume()
        {
            return maximum_Volume;
        }

        public int GetMaxWeight()
        {
            return maximum_Weight;
        }

        public int GetCurrentVolume()
        {
            int currentVolume = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentVolume += (int)items[i].GetVolume();
            }
            return currentVolume;
        }

        public int GetCurrentWeight()
        {
            int currentWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentWeight += (int)items[i].GetWeight();
            }
            return currentWeight;
        }
        public string GetPricingList()
        {
            return "";
        }
    }
}
