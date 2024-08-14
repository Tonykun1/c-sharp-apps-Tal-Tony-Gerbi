using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class GeneralItem : Item
    {
        private int id;
        public GeneralItem(int width, int length, int height, double weight, bool isFragile, StorageStructure currentLocation)
: base(width, length, height, weight, isFragile, currentLocation)
        {
            this.id = new Random().Next(1, 100);
        }
        public int GetID()
        {
            return id;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
