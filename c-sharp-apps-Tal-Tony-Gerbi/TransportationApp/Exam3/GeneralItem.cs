using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public  class GeneralItem:Item
    {
        public GeneralItem( int width, int length, int height, double weight, bool isFragile, string currentLocation)
: base(width, length, height, weight, isFragile, currentLocation)
        {

        }
    }
}
