using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam2
{
    public class PassengersTrain:PublicVehicle
    {
        private Crone[] crones = null;
        private int cronesAmount = 0;

        public PassengersTrain(int line, int id, int maxSpeed, int seats, Crone[] crones, int cronesAmount):base(line,id,maxSpeed, seats)
        {
            this.crones = crones;
            this.cronesAmount = cronesAmount;
        }
    }
}
