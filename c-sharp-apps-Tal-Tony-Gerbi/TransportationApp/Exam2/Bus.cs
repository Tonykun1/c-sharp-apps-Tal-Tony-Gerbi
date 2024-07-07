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
        public override int MaxSpeed
        {
            get => this.maxSpeed;
            set
            {
                if (value <= 120)
                {
                    this.maxSpeed = value;
                }
                else
                {
                    this.maxSpeed = 120;
                }
            }
        }
        public override bool CalculateHasRoom()
        {
            return (Math.Round(Seats * 1.1) - CurrentPassengers) > 0;
        }
        public override string ToString()
        {
            return $"Bus: {base.ToString()}, Doors={doors}, BellStop={bellStop}";
        }
    }
}
