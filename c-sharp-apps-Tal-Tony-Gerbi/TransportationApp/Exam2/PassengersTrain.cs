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

        public PassengersTrain()
        {

        }
        public PassengersTrain(int line, int id, int maxSpeed, int seats, Crone[] crones, int cronesAmount) : base(line, id, maxSpeed, seats)
        {
            this.crones = crones;
            this.cronesAmount = cronesAmount;
            for (int i = 0; i < crones.Length; i++)
            {
                Seats += crones[i].GetSeats();
            }
        }
        public override int MaxSpeed
        {
            get => this.maxSpeed;
            set
            {
                if (value <= 300)
                {
                    this.maxSpeed = value;
                }
                else
                {
                    this.maxSpeed = 300;
                }
            }
        }

        public override bool CalculateHasRoom()
        {
            int totalSeats = 0;
            for (int i = 0; i < crones.Length; i++)
            {
                totalSeats += crones[i].GetSeats() + crones[i].GetExtras();
            }
            return (totalSeats - CurrentPassengers) > 0;
        }

        public override string ToString()
        {
            return $"PassengersTrain: {base.ToString()}, CronesAmount={cronesAmount}";
        }
    }
}
