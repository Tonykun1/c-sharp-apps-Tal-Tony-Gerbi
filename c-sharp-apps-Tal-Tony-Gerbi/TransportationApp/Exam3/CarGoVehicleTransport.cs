using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    abstract class CarGoVehicleTransport: IContainable
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
        private IPriceCalculator iPriceCalculator;

        public bool Load(IPortable item)
        {
            items.Add(item);
            return true;
        }
        public bool Load(List<IPortable> items)
        {
            for(int i = 0; i<items.Count; i++)
            {
                this.items.Add(items[i]);
            }
            return true;
        }
        public bool UnLoad(IPortable item)
        {
            return items.Remove(item);
        }
        public bool Unload(List<IPortable> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
               return  this.items.Remove(items[i]);
            }
            return false;
        }

        public  string GetPricingList()
        {
            return "";
        }
    }
}
