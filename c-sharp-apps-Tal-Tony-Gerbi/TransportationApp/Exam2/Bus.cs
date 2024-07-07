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
            if(this.maxSpeed>maxSpeed)
            this.maxSpeed = 120;
            else
                this.maxSpeed = maxSpeed;
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

            }
        }
        public override bool CalculateHasRoom()
        {
            return (Math.Round(Seats * 1.1) - CurrentPassengers) > 0;
        }
        public override void UploadPassengers(int pass)
        {
            if (CalculateHasRoom())
            {
                if (Math.Round(Seats * 1.1) == CurrentPassengers + pass)
                {
                    HasRoom = false;
                    CurrentPassengers += pass;
                }
                else
                {
                    Console.WriteLine((int)Math.Round(Seats * 1.1));
                    Console.WriteLine((CurrentPassengers + pass));

                    RejecetedPassengers = ((int)Math.Round(Seats * 1.1))- (CurrentPassengers + pass);
                    
                    CurrentPassengers += pass - RejecetedPassengers;
                    HasRoom = false;
                }
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} + Bus: Doors={doors}, BellStop={bellStop}";
        }
    }
}
