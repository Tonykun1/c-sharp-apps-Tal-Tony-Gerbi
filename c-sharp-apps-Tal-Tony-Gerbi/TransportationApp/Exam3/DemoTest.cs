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
            Driver nick = new Driver("Nick", "haif", "1", CargoType.Airplane);
            Driver stephan = new Driver("stephan", "kosher", "2", CargoType.Airplane);
            Driver bobi = new Driver("bobi", "bonten", "1", CargoType.Ship);
            Driver tony = new Driver("tony", "LOLICON", "1", CargoType.Train);
            Driver[] AllDrivers = { nick, tony, bobi, stephan };
            //---------------------------Test - 1---------------------------
            /*
            Console.WriteLine("Test 1 - This Test Focus On Finding Drivers For The Mission From List Of Drivers[]\n");
            int countPilot = 0;
            int countShip = 0;
            int countTrain = 0;
            for (int i = 0; i < AllDrivers.Length; i++)
            {


                if (AllDrivers[i].GetType() == CargoType.NULL)
                {
                    Console.WriteLine($"Test 1: Faild -  Null Type Driver!");
                    Console.WriteLine("----------------------------------------------------------");
                    return;
                }
                else
                {
                    switch (AllDrivers[i].GetType())
                    {
                        case CargoType.Airplane: countPilot++; break;
                        case CargoType.Ship: countShip++; break;
                        case CargoType.Train: countTrain++; break;
                        default: Console.WriteLine("Unexpected Erorr!"); break;
                    }
                    Console.Write($"Found {AllDrivers[i].GetType()} Driver: ");
                    Console.WriteLine(AllDrivers[i].GetFirstName());
                }
            }
            Console.WriteLine($"\nTest 1 - Passed -> Found {countPilot} Pilots | {countShip} Sailers | {countTrain} Train Operator");
            Console.WriteLine("----------------------------------------------------------");
            */
            ////---------------------------Test - 2---------------------------
            /*
            Port tlv = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port eilat = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 12);

            IPortable item1 = new GeneralItem(5, 5, 8, 2000, false, tlv);
            IPortable item2 = new GeneralItem(5, 5, 8, 20, false, tlv);
            IPortable item3 = new GeneralItem(5, 5, 8, 20, false, tlv);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            Airplane LY466 = new Airplane(stephan, 10000, 1000, tlv, eilat, 150);
            Console.WriteLine("Test - 2");
            LY466.GetContainer().Load(items);
            //LY466.DisplayCargo();
           LY466.SetOverWeight(true);
            if(LY466.GetContainer().GetCurrentWeight() > LY466.GetContainer().GetMaxWeight() && LY466.GetOverWeight())
            {
                Console.WriteLine("Test 2 - Passed");
            }
            else
            {
                Console.WriteLine($"Test 2 - Failed -> Your OverWeight Prosperity is: {LY466.GetOverWeight()} | Expected: {LY466.GetContainer().GetCurrentWeight() > LY466.GetContainer().GetMaxWeight()}");
            }
            LY466.ReadyToGo();
            */
           ////---------------------------Test - 4---------------------------
            /*
            Console.WriteLine("Test - 4");
            Port tlv = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port eilat = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 12);

            IPortable item1 = new GeneralItem(5, 5, 8, 20, false, tlv);
            IPortable item2 = new GeneralItem(5, 5, 8, 20, false, tlv);
            IPortable item3 = new GeneralItem(5, 5, 8, 20, false, tlv);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            Crone cn = new Crone(10000, 1000);
            Airplane LYtest = new Airplane(null, 1000, 1000, tlv, eilat, 150);

            Console.WriteLine("price of travel "+LYtest.CalculatePrice(items, LYtest.GetNextPortDistance()));
            LYtest.SetDriver(stephan);
            LYtest.GoToNextDestinetion();
            LYtest.SetNextDestinetion(tlv);
            LYtest.GetContainer().Load(items);
            LYtest.DisplayCargo();
            LYtest.GoToNextDestinetion();
            LYtest.GetContainer().Unload(items);
            */

        }

    }
}
