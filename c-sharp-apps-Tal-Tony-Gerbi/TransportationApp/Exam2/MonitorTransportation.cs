﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam2
{
    public class MonitorTransportation
    {

        public void Test1()
        {
            //TODO: 

            //some tests:
            // public PublicVehicle(int line, int id, int maxSpeed, int seats)
            PublicVehicle p1 = new PublicVehicle(18, 8099065, 50, 80);
            Bus bus = new Bus(1, 2033355, 110, 50, 3);//int line, int id, int maxSpeed, int seats, int doors
            //int line, int id, int enginesNum, int wingLength, int rows, int columns
            PassengersAirplain passengersAirplain1 = new PassengersAirplain(605, 987653, 4, 10, 60, 6);

            Crone crone1 = new Crone(20, 5);
            PassengersTrain passengersTrain1 = new PassengersTrain(65, 9998774, 250, crone1, 5);
            bool allPassed = true;

            //test max speed
            if (p1.MaxSpeed != 0)
            {
                Console.WriteLine("Test 1 Error - Max Speed should be {0} but actual is {1}", 0, p1.MaxSpeed);
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 1 Passed ");

            }

            if (bus.MaxSpeed != 110)
            {
                Console.WriteLine("Test 2 Error - Max Speed should be {0} but actual is {1}", 110, bus.MaxSpeed);
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 2 Passed ");

            }
            bus.MaxSpeed = 200;

            if (bus.MaxSpeed != 110)
            {
                Console.WriteLine("Test 3 Error - Max Speed should be {0} but actual is {1}", 110, bus.MaxSpeed);
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 3 Passed ");

            }

            //test uplod some passenger and the currentPassengers after. 

            //cases that it's should be done. And not. 


            passengersAirplain1.CurrentPassengers = 300;

            passengersAirplain1.UploadPassengers(100);

            if (passengersAirplain1.CurrentPassengers == 353 && passengersAirplain1.RejecetedPassengers == 47)
            {
                Console.WriteLine("Test 4 Passed ");

            }
            else
            {

                Console.WriteLine("Test 4 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                    "And rejected should be {2} but actual is {3} ", 353, passengersAirplain1.CurrentPassengers,
                    47, passengersAirplain1.RejecetedPassengers);
                allPassed = false;

            }

            bus.UploadPassengers(40);
            bus.UploadPassengers(20);


            if (bus.CurrentPassengers == 55 && bus.RejecetedPassengers == 5)
            {
                Console.WriteLine("Test 5 Passed ");

            }
            else
            {

                Console.WriteLine("Test 5 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                  "And rejected should be {2} but actual is {3} ", 55, bus.CurrentPassengers,
                  15, bus.RejecetedPassengers);
                allPassed = false;

            }


            if (passengersTrain1.Id == 9998774)
            {
                Console.WriteLine("Test 6 Passed ");

            }
            else
            {

                Console.WriteLine("Test 6 Error - id  should be {0} but actual is {1} "
                   , 987653, passengersTrain1.Id);
                allPassed = false;

            }

            passengersTrain1.UploadPassengers(300);

            passengersTrain1.UploadPassengers(134);


            if (passengersTrain1.CurrentPassengers == 434 && passengersTrain1.RejecetedPassengers == 0)
            {
                Console.WriteLine("Test 7 Passed ");

            }
            else
            {

                Console.WriteLine("Test 7 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                  "And rejected should be {2} but actual is {3} ", 434, passengersTrain1.CurrentPassengers,
                  0, passengersTrain1.RejecetedPassengers);
                allPassed = false;

            }

            passengersTrain1.UploadPassengers(405);


            if (passengersTrain1.CurrentPassengers == 700 && passengersTrain1.RejecetedPassengers == 139
                && !passengersTrain1.HasRoom)
            {
                Console.WriteLine("Test 8 Passed ");

            }
            else
            {

                Console.WriteLine("Test 8 Error - CurrentPassengers should be {0} but actual is {1} \n" +
                  "And rejected should be {2} but actual is {3} and HasRoom should be False, but actual is {4}", 700, passengersTrain1.CurrentPassengers,
                  139, passengersTrain1.RejecetedPassengers, passengersTrain1.HasRoom);
                allPassed = false;

            }


            if (passengersTrain1.Crones[0].Equals(passengersTrain1.Crones[1]))
            {
                Console.WriteLine("Test 9 Error - each crone of the train should be different instance. ");
                allPassed = false;


            }
            else
            {

                Console.WriteLine("Test 9 Passed");

            }



            Console.WriteLine("\n*********************************\n");


            if (allPassed)
            {
                Console.WriteLine("All TEST PASSED - WELL DONE!! \n" +
                    "Yet it's not saying that everything work well. You should test yourself a little bit, also.");
            }
            else
            {
                Console.WriteLine("YOU HAVE FAILURES AT THE TESTS :( - SEE ABOVE");

            }
            Console.WriteLine("\n*********************************\n");
            Console.WriteLine("Function myTest and i did inside the function CountPlains");
            MyTest();
           
        }
        public  void MyTest()
        {
            PublicVehicle publicVehicle = new PublicVehicle(4, 100);
            Bus bus = new Bus(2, 101, 40, 4, 3);
            PassengersAirplain passengersAirplane = new PassengersAirplain(605, 987653, 4, 10, 60, 6);

            Crone crone1 = new Crone(20, 5);
            PassengersTrain passengersTrain = new PassengersTrain(65, 9998774, 250, crone1, 5);
            PublicVehicle[] allfamily = { publicVehicle, bus, passengersAirplane, passengersTrain };

            for (int i = 0; i < allfamily.Length; i++)
            {
                PublicVehicle duddy = allfamily[i];
                duddy.UploadPassengers(5);
                Console.WriteLine(duddy);
            }
            Console.WriteLine("function CountPlains");
            Console.WriteLine(CountPlains(allfamily));
        }
        public int CountPlains(PublicVehicle[] vehicles)
        {
            int count = 0;
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] is PassengersAirplain)
                {
                    count++;
                }
            }
            return count;
        }
    }
}