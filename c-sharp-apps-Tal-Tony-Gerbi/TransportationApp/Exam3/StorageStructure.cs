using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    abstract class StorageStructure:IContainable
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
        public bool Load(IPortable item)
        {
            return true;
        }
        public bool Load(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                return false;
            }
            return true;
        }
        public bool UnLoad(IPortable item)
        {
            return true;
        }
        public bool Unload(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                return true;
            }
            return false;
        }

        public string GetPricingList()
        {
            return "";
        }
    }
}
