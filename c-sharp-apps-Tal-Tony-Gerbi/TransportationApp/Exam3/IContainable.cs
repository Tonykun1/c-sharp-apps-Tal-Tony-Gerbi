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
        public bool UnLoad(IPortable item);
        public  bool Unload(List<IPortable> items);
        public string GetPricingList();
    }
}
