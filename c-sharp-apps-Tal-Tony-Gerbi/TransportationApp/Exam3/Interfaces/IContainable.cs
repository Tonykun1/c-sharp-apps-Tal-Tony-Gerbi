using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public interface IContainable
    {
        public bool Load(IPortable item);
        public bool Load(List<IPortable> items);
        public bool Unload(IPortable item);
         public bool Unload(List<IPortable> items);
        public bool IsHaveRoom();
        public bool IsOverload();
        public double GetMaxVolume();
        public double GetMaxWeight();
        public double GetCurrentVolume();
        public double GetCurrentWeight();
        public string GetPricingList();
    }
}
