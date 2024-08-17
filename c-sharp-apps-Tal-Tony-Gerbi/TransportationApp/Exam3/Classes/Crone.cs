using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Crone : IContainable
    {
        private double maxVolume;
        private double maxWeight;
        private double currentVolume;
        private double currentWeight;
        private List<IPortable> items;
        public Crone(Crone crone)
        {
            this.maxWeight = crone.maxWeight;
            this.maxVolume = crone.maxVolume;
            this.currentVolume = 0;
            this.currentWeight = 0;
            this.items = new List<IPortable>();
        }
        public Crone(double maxVolume, double maxWeight)
        {
            this.maxVolume = maxVolume;
            this.maxWeight = maxWeight;
            this.currentVolume = 0;
            this.currentWeight = 0;
            this.items = new List<IPortable>();
        }

        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                item.PackageItem();
                item.LoadedItem();
                items.Add(item);
                currentVolume += item.GetVolume();
                currentWeight += item.GetWeight();
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
                    Console.WriteLine("total volume in container: " + currentVolume);
                    Console.WriteLine($"Number of items in cargo: {this.items.Count}");
                    return false;
                }
            }
            Console.WriteLine("total volume in container: " + currentVolume);
            Console.WriteLine($"Number of items in cargo: {this.items.Count}");
            return true;
        }
        public bool Unload(IPortable item)
        {
            if (items.Remove(item))
            {
                currentVolume -= item.GetVolume();
                currentWeight -= item.GetWeight();
                return true;
            }
            return false;
        }
        public void ShowCroneList()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (IsHaveRoom() && !IsOverload())
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"item: {items[i].GetID()}  added seccufully to container \ntotal item  in container is {items.Count}");
                    currentVolume += items[i].GetVolume();
                    currentWeight += items[i].GetWeight();
                    Console.WriteLine(items[i]);
                    Console.WriteLine("-------------------------------");
                }
                else
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("no space in crone");
                    Console.WriteLine("-------------------------------");
                }
            }
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
            return ((currentVolume<maxVolume)&&(currentWeight<maxWeight));
        }

        public bool IsOverload()
        {
            return currentWeight > maxWeight;
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
        public bool Contains(IPortable item)
        {
            return items.Contains(item);
        }
        public string GetPricingList()
        {
            return "";
        }
    }
}
