﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces
{
    public interface IShippingPriceCalculator
    {
        public  double CalculatePrice(IPortable item, int travelDistance);
        public double CalculatePrice(List<IPortable> items, int travelDistance);
    }
}
