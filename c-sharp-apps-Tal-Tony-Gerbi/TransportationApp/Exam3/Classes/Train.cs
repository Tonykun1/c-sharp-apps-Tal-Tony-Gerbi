using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Train(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance, int numberOfCrones)
            : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            crones = new List<Crone>();
            for (int i = 0; i < numberOfCrones; i++)
            {
                crones.Add(new Crone(maximumVolume / numberOfCrones, maximumWeight / numberOfCrones));
            }
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
            for (int i = 0; i < items.Count; i++)
            {
                totalUnits += CalculateUnits(items[i]);
            }
            return totalUnits * travelDistance * RatePerKm;
        }

        public void AddToCrone(IPortable item)
        {
            foreach (var crone in crones)
            {
                if (crone.Load(item))
                {
                    currentVolume += item.GetVolume();
                    currentWeight += item.GetWeight();
                    Console.WriteLine("Item added to a Crone successfully!");
                    if (IsOverload() && !GetOverWeight())
                    {
                        SetOverWeight(true);
                        Console.WriteLine("The train is now overloaded.");
                    }
                    return;
                }
            }
            Console.WriteLine("No Crone has enough room for this item.");
        }

        public void AddToCrone(List<IPortable> items)
        {
            foreach (var item in items)
            {
                AddToCrone(item);
            }
        }

        public List<Crone> GetCrones()
        {
            return crones;
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
