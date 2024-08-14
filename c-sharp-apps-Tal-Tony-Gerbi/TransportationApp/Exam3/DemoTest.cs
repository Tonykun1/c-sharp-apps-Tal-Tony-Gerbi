using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Interfaces;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
    public class DemoTest
    {
        public static void RunTests()
        {
            //1 test
            Driver nick = new Driver("Nick", "haif", "1", CargoType.Airplane);
            Driver stephan = new Driver("stephan", "kosher", "2", CargoType.Airplane);
            Driver bobi = new Driver("bobi", "bonten", "1", CargoType.Ship);
            Driver[] AllDrivers = { nick, stephan, bobi };
            int count = 0;
            int place = 0;
            for (int i = 0; i < AllDrivers.Length; i++)
            {
                if (AllDrivers[i].GetType() == CargoType.Airplane)
                {
                    count++;
                }
                else
                {
                    place = i;
                }
            }
            if (count >= 1)
            {
                Console.WriteLine($"Test 1 Passed ");
            }
            else
            {
                Console.WriteLine($"Test 1 fail  u have license {AllDrivers[place].GetType()} and u need license to be on {CargoType.Airplane}");
            }
            //2 test 
            //if(stephan.Approve(CargoType.Airplane, "Eilat"))
            //{
            //    Console.WriteLine($"Test 2 Passed ");
            //}
            //3 test
            //Port tlv = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            //Port eilat = new Port(CargoType.Airplane, "Israel", "Eilat", "Ben Gurion", 12);
            //IPortable item3 = new GeneralItem(5, 5, 8, 20, false, tlv);
            //IPortable item1 = new GeneralItem(5, 5, 8, 20, false, tlv);
            //IPortable item2 = new GeneralItem(5, 5, 8, 20, false, tlv);
            //List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            //Airplane LY466 = new Airplane(stephan, 10, 10, tlv, eilat, 150);
            //Container con=new Container(20,20);
            //LY466.GetContainer().Load(items);
            //LY466.DisplayCargo();
            //4 TEST 
            Port tlv = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port eilat = new Port(CargoType.Airplane, "Israel", "Eilat", "Ben Gurion", 12);
            IPortable item3 = new GeneralItem(5, 5, 8, 20, false, tlv);
            IPortable item1 = new GeneralItem(5, 5, 8, 20, false, tlv);
            IPortable item2 = new GeneralItem(5, 5, 8, 20, false, tlv);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            Container con1 = new Container(20, 20);
            Container con2 = new Container(20, 20);
            Ship ST775 = new Ship(bobi, 20, 1000, tlv, eilat, 150);
            con1.Load(items);
            ST775.AddContainer(con1);

        }

    }
}
