using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Train : CarGoVehicleTransport, IShippingPriceCalculator
    {
        private const double RatePerKm = 5;
        private List<Crone> crones;
        private double currentVolume;
        private double currentWeight;
        private int numberOfCrones;
        public Train(Driver driver, Crone crone, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance, int numberOfCrones)
            : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            crones = new List<Crone>();
            this.numberOfCrones = numberOfCrones;
            for (int i = 0; i < numberOfCrones; i++)
            {
                crones.Add(new Crone(crone));
            }
            currentVolume = 0;
            currentWeight = 0;
            this.cargoType = CargoType.Train;
        }
        public Train(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance)
         : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            crones = new List<Crone>();
            currentVolume = 0;
            currentWeight = 0;
            this.cargoType = CargoType.Train;
        }
        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            return units * travelDistance * RatePerKm;
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            int totalUnits = 0;
            for (int i = 1; i < items.Count; i++)
            {
                totalUnits += CalculateUnits(items[i]);
            }
            return totalUnits * travelDistance * RatePerKm;
        }

        public void AddCrone(Crone newcrone)
        {
            this.crones.Add(newcrone);
            currentVolume += newcrone.GetCurrentVolume();
            currentWeight += newcrone.GetCurrentWeight();
            Console.WriteLine("New crone added successfully!");
            if (IsOverload() && !GetOverWeight())
            {
                SetOverWeight(true);
                SetReadyToGo(false);
                Console.WriteLine("OVERWIGHT WARRNING!");
            }
        }
        public void DisplayCrone()
        {
            for (int i = 0; i < crones.Count; i++)
            {
                Console.WriteLine($"crone : {i + 1}");
                crones[i].ShowCroneList();
                Console.WriteLine("-------------------------------------------------------");
            }
        }
        public void RemoveCrone(Crone newcrone)
        {
             this.crones.Remove(newcrone);
             currentVolume -= newcrone.GetCurrentVolume();
             currentWeight -= newcrone.GetCurrentWeight();
             this.numberOfCrones--;
             Console.WriteLine("Crone removed successfully!");
              if (!IsOverload() && GetOverWeight())
              {
                  SetOverWeight(false);
                  SetReadyToGo(true);
                  Console.WriteLine("Overweight removed and ready to go!");
              }
        }
        public void RemoveCroneByIndex(int index)
        {
            if (index >= 0 && index < crones.Count)
            {
                Crone newcrone = crones[index];
                crones.RemoveAt(index);
                currentVolume -= newcrone.GetCurrentVolume();
                currentWeight -= newcrone.GetCurrentWeight();
                numberOfCrones--;  
                Console.WriteLine($"Crone at index {index + 1} removed successfully!");

                if (!IsOverload() && GetOverWeight())
                {
                    SetOverWeight(false);
                    SetReadyToGo(true);
                    Console.WriteLine("Overweight removed and ready to go!");
                }
            }
            else
            {
                Console.WriteLine("Invalid crone index!");
            }
        }
        public List<Crone> GetCrones()
        {
            return crones;
        }
        public Crone GetCrone()
        {
            return crones[0];
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
    }
}
