﻿using System;
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
        private Driver driver;
        private int maximum_Weight;
        private int maximum_Volume;
        private bool ready_To_Go;
        private bool over_Weight;
        private string current_Port;
        private string next_Port;
        private int next_Port_Distance;
        private double price;
        private int id ;
        private List<IPortable> items;
        private ShippingPriceCalculator shippingPriceCalculator;

        //public CarGoVehicleTransport(Driver driver, int maximum_Weight, int maximum_Volume, bool over_Weight, string current_Port, string next_Port, int next_Port_Distance, double price, int id, List<IPortable> items, ShippingPriceCalculator shippingPriceCalculator)
        //{
        //    this.driver = driver;
        //    this.maximum_Weight = maximum_Weight;
        //    this.maximum_Volume = maximum_Volume;
        //    this.ready_To_Go = false;
        //    this.over_Weight = false;
        //    this.current_Port = current_Port;
        //    this.next_Port = next_Port;
        //    this.next_Port_Distance = next_Port_Distance;
        //    this.price = price;
        //    this.id = new Random().Next(1000, 10000);
        //    this.items = items;
        //    this.shippingPriceCalculator = shippingPriceCalculator;
        //}

        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                items.Add(item);
                return true;
            }
            return false;
        }

        public bool Load(List<IPortable> items)
        {
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

        public int GetMaxVolume()
        {
            return maximum_Volume;
        }

        public int GetMaxWeight()
        {
            return maximum_Weight;
        }

        public int GetCurrentVolume()
        {
            int currentVolume = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentVolume += (int)items[i].GetVolume();
            }
            return currentVolume;
        }

        public int GetCurrentWeight()
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
        public override string ToString()
        {
            return $"maximum_Weight {maximum_Weight}";
        }
    }
}
