using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
using System.ComponentModel.DataAnnotations;
namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Ship : CarGoVehicleTransport, IShippingPriceCalculator
    {
        private const double RatePerKm = 20;
        private List<Container> container;
        private double currentVolume;
        private double currentWeight;

        public Ship(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance) : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            container = new List<Container>();
            this.currentVolume = 0;
            this.currentWeight = 0;
            this.cargoType = CargoType.Ship;
        }
        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            return units * travelDistance * RatePerKm;
        }
        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            int totalUnits = 0;
            for (int i = 0; i < items.Count; i++)
            {
                totalUnits += CalculateUnits(items[i]);
            }
            return totalUnits * travelDistance * RatePerKm;
        }
        public void AddContainer(Container newcontainer)
        {
            Console.WriteLine($"Attempting to add container with volume {newcontainer.GetCurrentVolume()} and weight {newcontainer.GetCurrentWeight()}");
            if (currentVolume + newcontainer.GetCurrentVolume() <= GetMaxVolume())
            {
                this.container.Add(newcontainer);
                currentVolume += newcontainer.GetCurrentVolume();
                currentWeight += newcontainer.GetCurrentWeight();
                Console.WriteLine($"Container added. Current volume: {currentVolume}, Current weight: {currentWeight}");
                if (IsOverload() && !GetOverWeight())
                {
                    SetOverWeight(true);
                    SetReadyToGo(false);
                    Console.WriteLine("OVERWEIGHT WARNING!");
                }
            }
            else
            {
                Console.WriteLine("Not enough volume to add the container");
            }
        }
        public void DisplayContainers()
        {
            for (int i = 0; i < container.Count; i++)
            {
                Console.WriteLine($"Container : {i + 1}");
                container[i].GetContainerList();
                Console.WriteLine("-------------------------------------------------------");
            }
        }
        public void RemoveContainer(Container newcontainer)
        {
            this.container.Remove(newcontainer);
            currentVolume -= newcontainer.GetCurrentVolume();
            currentWeight -= newcontainer.GetCurrentWeight();
            Console.WriteLine("Contanier remove successfully!");
            if (currentWeight < GetMaxWeight())
            {
                SetOverWeight(false);
                SetReadyToGo(true);
                Console.WriteLine("overweight removed and ready to sail!");
            }
        }
        public void RemoveAtContainer(int index)
        {
            Container newcontainer = this.container[index];
            this.container.RemoveAt(index);
            currentVolume -= newcontainer.GetCurrentVolume();
            currentWeight -= newcontainer.GetCurrentWeight();
            Console.WriteLine("Contanier remove successfully!");
            if (currentWeight < GetMaxWeight())
            {
                SetOverWeight(false);
                SetReadyToGo(true);
                Console.WriteLine("overweight removed and ready to sail!");
            }
        }
        public int CalculateUnits(IPortable item)
        {
            int units = (int)(item.GetVolume() / 100) + (int)item.GetWeight();
            if (item.IsFragile())
            {
                units *= 2;
            }
            return units;
        }
        public List<Container> GetContainers()
        {
            return container;
        }
        public Container GetContainer()
        {
            return container[0];
        }
    }
}
