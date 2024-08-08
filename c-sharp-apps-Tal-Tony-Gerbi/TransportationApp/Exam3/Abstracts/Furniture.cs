using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes;
namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts
{
    public  class Furniture : Item
    {
        private bool isModular;
        public Furniture(bool isModular, int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation)
          : base(width, length, height, weight, isFragile, currentLocation)
        {
            this.isModular = isModular;
        }
        public void EasyDilivery()
        {
            if (isModular)
                Console.WriteLine("Your Furniture is compactable and easy to diliver!");
            else
                Console.WriteLine("Your Furniture is not compactable makes it harder to diliver!");
        }
    }
}
