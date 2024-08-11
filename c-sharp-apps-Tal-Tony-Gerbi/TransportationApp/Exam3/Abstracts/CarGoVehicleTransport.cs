using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts
{
    public abstract class CarGoVehicleTransport : IContainable
    {

        protected Driver driver;
        private double maximumWeight;
        private double maximumVolume;
        private bool ready_To_Go;
        private bool over_Weight;
        private string current_Port;
        private string next_Port;
        private int next_Port_Distance;
        private double price;
        private int id;
        private List<IPortable> items;

        protected CarGoVehicleTransport(Driver driver, double maximumWeight, double maximumVolume, string current_Port, string next_Port, int next_Port_Distance)
        {
            this.id = new Random().Next(1000, 10000);
            this.driver = driver;
            this.maximumWeight = maximumWeight;
            this.maximumVolume = maximumVolume;
            this.ready_To_Go = false;
            this.over_Weight = false;
            this.current_Port = current_Port;
            this.next_Port = next_Port;
            this.next_Port_Distance = next_Port_Distance;
            this.price = 0;
        }
        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                //אופציה להוסיף הדפסה על הצלחת המטען
                items.Add(item);
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
            //אופציה להוסיף הדפסה על הצלחת המטען
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

        public double GetMaxVolume()
        {
            return maximumVolume;
        }
        public double GetMaxWeight()
        {
            return maximumWeight;
        }
        public int GetNextPortDistance()
        {
            return next_Port_Distance;
        } 
        public double GetCurrentVolume()
        {
            int currentVolume = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentVolume += (int)items[i].GetVolume();
            }
            return currentVolume;
        }
        public double GetCurrentWeight()
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
        public void PrintItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }

        }
        public virtual string ToString()
        {
            return $"maximum_Weight {maximumWeight}, items  ";
        }
    }
}
