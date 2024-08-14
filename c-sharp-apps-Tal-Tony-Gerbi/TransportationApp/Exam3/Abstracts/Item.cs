using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts
{
    public abstract class Item : IPortable
    {
        private int width;
        private int length;
        private int height;
        private double weight;
        private bool isFragile;
        private bool isPackaged;
        private bool isLoaded;
        private StorageStructure currentLocation;
        protected int id;

        public Item(int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.weight = weight;
            this.isFragile = isFragile;
            this.isPackaged = false;
            this.isLoaded = false;
            this.currentLocation = currentLocation;
            this.id = new Random().Next(1000,10000);
        }

        public int GetID()
        {
                return id;
        }
        public void SetLocation(StorageStructure location)
        {
            currentLocation = location;
        }
        public double GetArea()
        {
            return length * width;
        }
        public double[] GetSize()
        {
            return new double[] { width, length, height };
        }
        public double GetVolume()
        {
            return width * length * height;
        }
        public double GetWeight()
        {
            return weight;
        }
        public void PackageItem()
        {
            isPackaged = true;
        }
        public bool IsPackaged()
        {
            return isPackaged;
        }
        public void UnPackage()
        {
            isPackaged = false;
        }
        public bool IsFragile()
        {
            return isFragile;
        }
        public bool IsLoaded()
        {
            return isLoaded;
        }
        public void LoadedItem()
        {
            isLoaded = true;
        }
        public StorageStructure GetLocation()
        {
            return currentLocation;
        }
        public override string ToString()
        {
            return $"volume {GetVolume()} | isFragile = {isFragile} | isPackaged ={isPackaged} | isLoaded ={isLoaded} | currentLocation = {currentLocation.GetCity()}";
        }
    }
}
