using System;
using System.Collections.Generic;
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
            bool allPassed = true;

            StorageStructure SS1 = new StorageStructure("Israel", "tel-aviv", "Ben Gurion", 12);
            StorageStructure SS2 = new StorageStructure("Israel", "tel-aviv", "Ben Gurion", 22);
            StorageStructure SS3 = new StorageStructure("Israel", "tel-aviv", "Ben Gurion", 32);
            IPortable item1 = new GeneralItem(10, 10, 5, 50, false, SS1);
            IPortable item2 = new GeneralItem(10, 10, 3, 30, true, SS2);
            IPortable item3 = new GeneralItem(5, 5, 8, 20, false, SS3);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };

            Train trainTransport = new Train(100,101);
            Ship shipTransport = new Ship();
            Airplane airplaneTransport = new Airplane();

            double expectedPrice1 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 100 * 5;
            double actualPrice1 = trainTransport.CalculatePrice(item1, 100);
            if (actualPrice1 != expectedPrice1)
            {
                Console.WriteLine($"Test 1 Failed - Expected: {expectedPrice1}, Actual: {actualPrice1}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 1 Passed");
            }

            double expectedPrice2 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 100 * 5;
            double actualPrice2 = trainTransport.CalculatePrice(item2, 100);
            if (actualPrice2 != expectedPrice2)
            {
                Console.WriteLine($"Test 2 Failed - Expected: {expectedPrice2}, Actual: {actualPrice2}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 2 Passed");
            }

            double expectedPrice3 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 100 * 5;
            double actualPrice3 = trainTransport.CalculatePrice(items, 100);
            if (actualPrice3 != expectedPrice3)
            {
                Console.WriteLine($"Test 3 Failed - Expected: {expectedPrice3}, Actual: {actualPrice3}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 3 Passed");
            }

            double expectedPrice4 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 200 * 20;
            double actualPrice4 = shipTransport.CalculatePrice(item1, 200);
            if (actualPrice4 != expectedPrice4)
            {
                Console.WriteLine($"Test 4 Failed - Expected: {expectedPrice4}, Actual: {actualPrice4}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 4 Passed");
            }

   
            double expectedPrice5 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 200 * 20;
            double actualPrice5 = shipTransport.CalculatePrice(item2, 200);
            if (actualPrice5 != expectedPrice5)
            {
                Console.WriteLine($"Test 5 Failed - Expected: {expectedPrice5}, Actual: {actualPrice5}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 5 Passed");
            }

    
            double expectedPrice6 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 200 * 20;
            double actualPrice6 = shipTransport.CalculatePrice(items, 200);
            if (actualPrice6 != expectedPrice6)
            {
                Console.WriteLine($"Test 6 Failed - Expected: {expectedPrice6}, Actual: {actualPrice6}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 6 Passed");
            }

          
            double expectedPrice7 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 300 * 50;
            double actualPrice7 = airplaneTransport.CalculatePrice(item1, 300);
            if (actualPrice7 != expectedPrice7)
            {
                Console.WriteLine($"Test 7 Failed - Expected: {expectedPrice7}, Actual: {actualPrice7}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 7 Passed");
            }

          
            double expectedPrice8 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 300 * 50;
            double actualPrice8 = airplaneTransport.CalculatePrice(item2, 300);
            if (actualPrice8 != expectedPrice8)
            {
                Console.WriteLine($"Test 8 Failed - Expected: {expectedPrice8}, Actual: {actualPrice8}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 8 Passed");
            }

            double expectedPrice9 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 300 * 50;
            double actualPrice9 = airplaneTransport.CalculatePrice(items, 300);
            if (actualPrice9 != expectedPrice9)
            {
                Console.WriteLine($"Test 9 Failed - Expected: {expectedPrice9}, Actual: {actualPrice9}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 9 Passed");
            }

 
            double expectedPrice10 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 150 * 5;
            double actualPrice10 = trainTransport.CalculatePrice(item1, 150);
            if (actualPrice10 != expectedPrice10)
            {
                Console.WriteLine($"Test 10 Failed - Expected: {expectedPrice10}, Actual: {actualPrice10}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 10 Passed");
            }

           
            double expectedPrice11 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 150 * 5;
            double actualPrice11 = trainTransport.CalculatePrice(item2, 150);
            if (actualPrice11 != expectedPrice11)
            {
                Console.WriteLine($"Test 11 Failed - Expected: {expectedPrice11}, Actual: {actualPrice11}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 11 Passed");
            }

        
            double expectedPrice12 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 250 * 20;
            double actualPrice12 = shipTransport.CalculatePrice(item1, 250);
            if (actualPrice12 != expectedPrice12)
            {
                Console.WriteLine($"Test 12 Failed - Expected: {expectedPrice12}, Actual: {actualPrice12}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 12 Passed");
            }

          
            double expectedPrice13 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 250 * 20;
            double actualPrice13 = shipTransport.CalculatePrice(item2, 250);
            if (actualPrice13 != expectedPrice13)
            {
                Console.WriteLine($"Test 13 Failed - Expected: {expectedPrice13}, Actual: {actualPrice13}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 13 Passed");
            }

           
            double expectedPrice14 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 350 * 50;
            double actualPrice14 = airplaneTransport.CalculatePrice(item1, 350);
            if (actualPrice14 != expectedPrice14)
            {
                Console.WriteLine($"Test 14 Failed - Expected: {expectedPrice14}, Actual: {actualPrice14}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 14 Passed");
            }

            
            double expectedPrice15 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 350 * 50;
            double actualPrice15 = airplaneTransport.CalculatePrice(item2, 350);
            if (actualPrice15 != expectedPrice15)
            {
                Console.WriteLine($"Test 15 Failed - Expected: {expectedPrice15}, Actual: {actualPrice15}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 15 Passed");
            }

            Console.WriteLine("\n*********************************\n");
            if (allPassed)
            {
                Console.WriteLine("All TESTS PASSED - WELL DONE!!");
            }
            else
            {
                Console.WriteLine("YOU HAVE FAILURES IN THE TESTS :( - SEE ABOVE");
            }
            Console.WriteLine("\n*********************************\n");
        }

    }
}
