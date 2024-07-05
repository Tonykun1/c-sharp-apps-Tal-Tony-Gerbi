using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam2
{
    public class PublicVehicle
    {
        private int line = 0;
        private int id = 0;
        protected int maxSpeed = 0;
        private int currentPassengers = 0;
        private int rejecetedPassengers = 0;
        private int seats = 0;
        private bool hasRoom = true;

        public PublicVehicle()
        {
            this.line = 0;
            this.id = 0;
            this.maxSpeed = 0;
            this.seats = 0;
        }

        public PublicVehicle(int line, int id)
        {
            this.line = line;
            this.id = id;
        }

        public PublicVehicle(int line, int id, int maxSpeed, int seats)
        {
            this.line = line;
            this.id = id;
            this.seats = seats;
            if(maxSpeed > 40)
            this.maxSpeed = 40;
            else 
            this.maxSpeed = maxSpeed;
        }

        public bool HasRoom { get => hasRoom; set => hasRoom = value; }
        public int CurrentPassengers { get => currentPassengers; set => currentPassengers = value; }
        public int Line { get => line; set => line = value; }
        public int Id { get => id; set => id = value; }
        public int Seats { get => seats; set => seats = value; }


        public virtual void SetMaxSpeed(int maxSpeed)
        {
            if (this.maxSpeed <= 40)
            {
                this.maxSpeed = maxSpeed;
                return;
            }
             this.maxSpeed = 40;
        }
        public virtual bool CalculateHasRoom()
        {
            return (this.seats - this.currentPassengers) > 0;
            
        }
        public virtual void oUploadPassengers(int passengers)
        {
            if(CalculateHasRoom())
            {
                Console.WriteLine("No Vehicle is full");
                return;
            }
            if(this.seats >= this.currentPassengers+passengers)
            {
                this.currentPassengers += passengers;
                if (this.currentPassengers == this.seats)
                    hasRoom = false;
                else
                {
                    this.rejecetedPassengers = (this.CurrentPassengers+passengers)-this.seats;
                    hasRoom = false;
                }
            }
        }
        public override string ToString()
        {
            return $"";
        }
    }
}
