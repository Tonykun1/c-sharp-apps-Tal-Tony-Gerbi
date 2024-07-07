using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam2
{
    public class PassengersAirplain:PublicVehicle
    {
        private int enginesNum;
        private int wingLength;
        private int rows;
        private int columns;
        public PassengersAirplain() : base() { }

        public PassengersAirplain(int line, int id, int enginesNum, int wingLength, int rows, int columns) : base(line, id, 0, rows * columns)
        {
            this.enginesNum = enginesNum;
            this.wingLength = wingLength;
            this.rows = rows;
            this.columns = columns;
            Seats -= 7;
        }
        public override int MaxSpeed
        {
            get => this.maxSpeed;
            set
            {
                if (value <= 1000)
                {
                    this.maxSpeed = value;
                }
                else
                {
                    this.maxSpeed = 1000;
                }
            }
        }

        public override string ToString()
        {
            return $"PassengersAirplane: {base.ToString()}, EnginesNum={enginesNum}, WingLength={wingLength}, Rows={rows}, Columns={columns}";
        }
    }
}
