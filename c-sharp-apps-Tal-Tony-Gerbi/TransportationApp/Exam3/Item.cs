using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public class Item: IPortable
    {
        private int width;
        private int length;
        private int height;
        private double weight;
        private bool isFragile;
        private bool isPackaged;
        private bool isLoaded;
        private string currentLocation;

        public Item(int width, int length, int height, double weight, bool isFragile, string currentLocation)
        {
            this.width = width;
            this.length = length;
            this.height = height;
            this.weight = weight;
            this.isFragile = isFragile;
            this.isPackaged = false;
            this.isLoaded = false;
            this.currentLocation = currentLocation;
        }


        public void SetLocation(string location)
        {
            this.currentLocation = location;
        }
        public double GetArea()
        {
            return this.length*this.width;
        }
        public int[] GetSize()
        {
            return new int[] { this.width , this.length , this.height };
        }
        public double GetVolume()
        {
            return this.width * this.length * this.height;
        }
        public double GetWeight() {  
            return this.weight; 
        }
        public void PackageItem() { 
            this.isPackaged = true;
        }
        public bool IsPackaged()
        {
            return isPackaged;
        }
        public void UnPackage()
        {
            isPackaged=false;
        }
        public bool IsFragile()
        {
            return isFragile;
        }
        public string GetLocation()
        {
            return currentLocation;
        }
        public bool IsLoaded()
        {
            return isLoaded;
        }
    }
}
