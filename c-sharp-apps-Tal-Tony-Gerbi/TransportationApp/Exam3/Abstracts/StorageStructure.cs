using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts
{
    public abstract class StorageStructure : IContainable
    {
        private string country;
        private string city;
        private string adress;
        private int numAdress;

        public StorageStructure(string country, string city, string adress, int numAdress)
        {
            this.country = country;
            this.city = city;
            this.adress = adress;
            this.numAdress = numAdress;
        }
        public string GetCity()
        {
            return city;
        }
        public bool Load(IPortable item)
        {
            return true;
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
            return true;
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
            return true;
        }

        public bool IsOverload()
        {
            return false;
        }

        public double GetMaxVolume()
        {
            return 1000;
        }

        public double GetMaxWeight()
        {
            return 1000;
        }

        public double GetCurrentVolume()
        {
            return 0;
        }

        public double GetCurrentWeight()
        {
            return 0;
        }
        public virtual string GetPricingList()
        {
            return "";
        }
        public override string ToString()
        {
            return $"country is {country},city {city}, address {adress} numAddress {numAdress} ";
        }
    }
}
