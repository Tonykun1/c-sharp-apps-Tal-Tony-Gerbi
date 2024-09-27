using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class CarGoVehicle:CarGoVehicleTransport
    {
        public CarGoVehicle(Driver driver, double maximumWeight, double maximumVolume, StorageStructure current_Port, StorageStructure next_Port, int next_Port_Distance)
: base( driver,  maximumWeight,  maximumVolume,  current_Port,  next_Port,  next_Port_Distance)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
