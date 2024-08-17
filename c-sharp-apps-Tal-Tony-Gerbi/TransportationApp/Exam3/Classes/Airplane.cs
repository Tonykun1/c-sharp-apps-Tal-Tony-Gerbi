using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Airplane :CarGoVehicleTransport, IShippingPriceCalculator
    {
        private const double RatePerKm = 50;
        private Container container;
        private double currentWeight;
        public Airplane(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance) : base( driver,  maximumWeight,  maximumVolume,  current_Port,  next_Port,  next_Port_Distance)
        {
            container = new Container(maximumWeight, maximumVolume);
            this.cargoType = CargoType.Airplane;
            currentWeight = 0;
        }
        public double CalculatePrice(IPortable item, int travelDistance)
        {
            int units = CalculateUnits(item);
            return units * travelDistance * RatePerKm;
        }
        public void SetCurrentWeight(double weight)
        {
            this.currentWeight = weight;
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
        public double CalPricePlane()
        {
            return CalculatePrice(container.GetList(), GetNextPortDistance());
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
        public Container GetContainer()
        {
            return container;
        }
        public void DisplayCargo()
        {
            Console.WriteLine($"Number of items in cargo: {GetContainer().GetItem().Count}");
            for (int i = 0; i < GetContainer().GetItem().Count; i++)
            {
                Console.WriteLine(GetContainer().GetItem()[i]);
            }
            UpdateWeight();
        }
        public void UpdateWeight()
        {
            if (container.GetCurrentWeight() > GetMaxWeight())
            {
                SetOverWeight(true);
                Console.WriteLine($"OVERLOAD WARNING!\nCurrent Weight:{container.GetCurrentWeight()} | Vehicle Max Weight:{GetMaxWeight()}");
            }
            else
            {
                Console.WriteLine($"\nCurrent Weight:{container.GetCurrentWeight()} | Vehicle Max Weight:{GetMaxWeight()}");
            }
        }

    }
}
