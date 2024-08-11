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
    public class Ship :CarGoVehicleTransport, IShippingPriceCalculator
    {
        private const double RatePerKm = 20;
        private List<Container> container;
        private double currentVolume;
        private double currentWeight;
        public Ship(Driver driver, double maximumWeight, double maximumVolume, string current_Port, string next_Port, int next_Port_Distance) : base(driver, maximumWeight, maximumVolume, current_Port, next_Port, next_Port_Distance)
        {
            container =null;
            this.currentVolume = 0;
            this.currentWeight = 0;
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
        public void addContainer()
        {
            for (int i = 0;i < container.Count;i++)
            {
                if(currentWeight>GetMaxWeight())
                 container.Add(container[i]);
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
        public List<Container> GetContainer()
        {
            return container;
        }
    }
}
