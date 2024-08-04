using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public class Port:StorageStructure
    {
        private CargoType driverType;

        public Port(CargoType driverType, string country, string city, string address, int numAddress)
        : base(country, city, address, numAddress)
        {
            this.driverType = driverType;
        }
        public  bool Load(IPortable item)
        {
            return true;
        }
        public  bool Load(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                return false;
            }
            return true;
        }
        public  bool UnLoad(IPortable item)
        {
            return true;
        }
        public  bool Unload(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                return true;
            }
            return false;
        }

        public  override string GetPricingList()
        {
            return "";
        }
    }
}
