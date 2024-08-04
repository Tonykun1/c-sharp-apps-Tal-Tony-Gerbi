using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public interface IPortable
    {
        public double GetArea();
        public int[] GetSize();
        public double GetVolume();
        public double GetWeight();
        public void PackageItem();
        public bool IsPackaged();
        public void UnPackage();
        public bool IsFragile();
        public string GetLocation();
        public bool IsLoaded();
    }
}
