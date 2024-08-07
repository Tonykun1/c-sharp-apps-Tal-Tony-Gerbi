using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class ElectricDevice : Item
    {
        private int watt;
        private int hdmiSlot;
        public ElectricDevice(int watt, int hdmiSlot, int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation)
       : base(width, length, height, weight, isFragile, currentLocation)
        {
            this.watt = watt;
            this.hdmiSlot = hdmiSlot;
        }
        public void HDMISlot()
        {
            Console.WriteLine($"on ur Electric Device u have {hdmiSlot}");
        }


    }
}
