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

        public PassengersAirplain(int line, int id, int enginesNum, int wingLength, int rows, int columns)
            : base(line, id, 0, rows * columns - 7)
        {
            this.EnginesNum = enginesNum;
            this.WingLength = wingLength;
            this.Rows = rows;
            this.Columns = columns;
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
            }
        }

        public int EnginesNum { get => enginesNum; set => enginesNum = value; }
        public int WingLength { get => wingLength; set => wingLength = value; }
        public int Rows { get => rows; set => rows = value; }
        public int Columns { get => columns; set => columns = value; }

        public override string ToString()
        {
            return $"{base.ToString()} => PassengersAirplane: EnginesNum={EnginesNum}, WingLength={WingLength}, Rows={Rows}, Columns={Columns}";
        }
    }
}
