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

        private Driver driver;
        private double maximumWeight;
        private double maximumVolume;
        private bool ready_To_Go;
        private bool over_Weight;
        private StorageStructure current_Port;
        private StorageStructure next_Port;
        private int next_Port_Distance;
        private double price;
        private int id;
        private List<IPortable> items;
        protected CargoType cargoType;

        public CarGoVehicleTransport(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance)
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
            this.cargoType = CargoType.NULL;
            this.items = new List<IPortable>();

        }
        public void SetDriver(Driver driver)
        {
            this.driver = driver;
        }
        public Driver GetDriver() { 
            return this.driver; 
        }
        public bool Load(IPortable item)
        {
            if (IsHaveRoom() && !IsOverload())
            {
                items.Add(item);
                Console.WriteLine("seccufully");
                return true;
            }
            else
            {
                Console.WriteLine("no space");
            }
            return false;
        }
        public List<IPortable> GetListItem()
        {
            return items;
        }
        public bool Load(List<IPortable> items)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (!Load(items[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public bool GetOverWeight()
        {
            return over_Weight;
        }
        public void SetReadyToGo(bool readyToGo)
        {
            this.ready_To_Go = readyToGo;
        }
        public bool GetReadyToGo()
        {
            return this.ready_To_Go;
        }
        public void SetOverWeight(bool overWeight)
        {
            this.over_Weight = overWeight;
        }
        public bool Unload(IPortable item)
        {
            return items.Remove(item);
        }
        public void ReadyToGo()
        {

            if (driver.Approve(cargoType, next_Port) && !GetOverWeight())
            {
                ready_To_Go = true;
                Console.WriteLine($"{cargoType} Ready To Go!");
            }
            else
            {
                ready_To_Go = false;
                if (GetOverWeight())
                {
                    Console.WriteLine("Can't Approve You are Over Weight!");
                }
                else
                {
                    Console.WriteLine("Driver Didn't Approve!");
                }
            }
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
        public void GoToNextDestinetion()
        {
            ReadyToGo();
            if (next_Port == null)
            {
                Console.WriteLine("i dont have any next Destinetion port");
            }
            else if (ready_To_Go)
            {
                current_Port = next_Port;
                next_Port = null;
                Console.WriteLine($"{cargoType} u here");
            }
            else
            {

                Console.WriteLine("go to next port");
            }
        }
        public void SetNextDestinetion(StorageStructure nextPort)
        {
            Console.WriteLine($"{driver.GetLastName()}  u need to back");
            this.next_Port = nextPort;
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
            double currentVolume = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentVolume += items[i].GetVolume();
            }
            return currentVolume;
        }

        public double GetCurrentWeight()
        {
            double currentWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                currentWeight += items[i].GetWeight();
            }
            return currentWeight;
        }
        public virtual string GetPricingList()
        {
            return "";
        }
        public virtual string ToString()
        {
            return $"maximum_Weight {maximumWeight}, items  ";
        }
    }
}
