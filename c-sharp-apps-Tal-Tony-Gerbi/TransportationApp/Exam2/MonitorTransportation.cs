using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam2
{
    public class MonitorTransportation
    {
        public static void Test1()
        {
            Bus bus = new Bus(1, 100, 1000, 40, 2);
            PassengersTrain train = new PassengersTrain(2, 101, 299,0, new Crone[] { new Crone(10, 5), new Crone(10, 5) }, 2);
            PassengersAirplain airplane = new PassengersAirplain(3, 102, 4, 50, 20, 6);

            bus.UploadPassengers(10);
            bus.UploadPassengers(30);
            bus.UploadPassengers(5);

            train.UploadPassengers(50);
            train.UploadPassengers(30);
            train.UploadPassengers(10);

            airplane.UploadPassengers(100);
            airplane.UploadPassengers(50);
            airplane.UploadPassengers(20);

            Console.WriteLine(bus);
            Console.WriteLine(train);
            Console.WriteLine(airplane);
        }

    }
}
