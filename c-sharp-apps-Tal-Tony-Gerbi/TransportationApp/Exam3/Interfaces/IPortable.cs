using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public interface IPortable
    {
        public double GetArea();
        public double[] GetSize();
        public double GetVolume();
        public double GetWeight();
        public void PackageItem();
        public bool IsPackaged();
        public void UnPackage();
        public bool IsFragile();
        public StorageStructure GetLocation();
        public bool IsLoaded();
    }
}
