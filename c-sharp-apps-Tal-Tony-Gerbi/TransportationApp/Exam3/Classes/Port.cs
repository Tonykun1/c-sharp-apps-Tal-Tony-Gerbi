using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Port : StorageStructure
    {
        private CargoType driverType;
        private List<IPortable> items;
        public Port(CargoType driverType, string country, string city, string address, int numAddress)
        : base(country, city, address, numAddress)
        {
            this.driverType = driverType;
        }
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
                return true;
            }
            return false;
        }

        public bool Unload(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!Unload(items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsHaveRoom()
        {
            return ((base.GetCurrentVolume() < base.GetMaxVolume()) && (base.GetCurrentWeight() < base.GetMaxWeight()));
        }

        public bool IsOverload()
        {
            return base.GetCurrentWeight() > base.GetMaxWeight();
        }

        public double GetMaxVolume()
        {
            return base.GetMaxVolume();
        }

        public double GetMaxWeight()
        {
            return base.GetMaxWeight();
        }

        public double GetCurrentVolume()
        {
            return base.GetCurrentVolume();
        }

        public double GetCurrentWeight()
        {
            return base.GetCurrentWeight();
        }
        public override string GetPricingList()
        {
            return "";
        }
        public override string ToString()
        {
            return $"{base.ToString()} ";
        }
    }
}
