using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public class ShippingPriceCalculator : IShippingPriceCalculator
    {
        public double CalculatePrice(IPortable item, int travelDistance)
        {
            throw new NotImplementedException();
        }

        public double CalculatePrice(List<IPortable> items, int travelDistance)
        {
            throw new NotImplementedException();
        }
    }
}
