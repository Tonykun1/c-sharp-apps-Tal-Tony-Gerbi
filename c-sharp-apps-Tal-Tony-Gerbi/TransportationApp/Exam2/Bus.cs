using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam2
{
    public class Bus:PublicVehicle
    {
        private readonly int doors;
        private bool bellStop = false;

        public Bus(int line, int id, int maxSpeed, int seats, int doors) :base(line,id, maxSpeed, seats)
        {
            this.doors = doors;
        }
        public Bus():base()
        {
            this.doors = 1;
        }
        public override void SetMaxSpeed(int maxSpeed )
        {
            if (this.maxSpeed <= 120)
            {
                this.maxSpeed = maxSpeed;
                return;
            }
            else
                this.maxSpeed = 120;
        }
    }
}
