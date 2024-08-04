using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public class Port:StorageStructure
    {
        private CargoType driverType;

        public Port(string country, string city, string adress, int numAdress) :base( country,  city,  adress,  numAdress)
        {
        }
    }
}
