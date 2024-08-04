using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3
{
  public class DemoTest
    {
        public static void RunTests()
        {
            bool allPassed = true;

            // Setup
            GeneralItem item1 = new GeneralItem(10, 10, 5, 50, false, "Warehouse A");
            GeneralItem item2 = new GeneralItem(10, 10, 3, 30, true, "Warehouse B");
            GeneralItem item3 = new GeneralItem(5, 5, 8, 20, false, "Warehouse C");
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };

            // Test 1: Single item, train, non-fragile
            IPriceCalculator trainCalculator = new IPriceCalculator(5);
            double expectedPrice1 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 100 * 5;
            double actualPrice1 = trainCalculator.CalculatePrice(item1, 100);
            if (actualPrice1 != expectedPrice1)
            {
                Console.WriteLine($"Test 1 Failed - Expected: {expectedPrice1}, Actual: {actualPrice1}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 1 Passed");
            }

            // Test 2: Single item, train, fragile
            double expectedPrice2 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 100 * 5;
            double actualPrice2 = trainCalculator.CalculatePrice(item2, 100);
            if (actualPrice2 != expectedPrice2)
            {
                Console.WriteLine($"Test 2 Failed - Expected: {expectedPrice2}, Actual: {actualPrice2}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 2 Passed");
            }

            // Test 3: Multiple items, train
            double expectedPrice3 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 100 * 5;
            double actualPrice3 = trainCalculator.CalculatePrice(items, 100);
            if (actualPrice3 != expectedPrice3)
            {
                Console.WriteLine($"Test 3 Failed - Expected: {expectedPrice3}, Actual: {actualPrice3}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 3 Passed");
            }

            // Test 4: Single item, ship, non-fragile
            IPriceCalculator shipCalculator = new IPriceCalculator(20);
            double expectedPrice4 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 200 * 20;
            double actualPrice4 = shipCalculator.CalculatePrice(item1, 200);
            if (actualPrice4 != expectedPrice4)
            {
                Console.WriteLine($"Test 4 Failed - Expected: {expectedPrice4}, Actual: {actualPrice4}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 4 Passed");
            }

            // Test 5: Single item, ship, fragile
            double expectedPrice5 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 200 * 20;
            double actualPrice5 = shipCalculator.CalculatePrice(item2, 200);
            if (actualPrice5 != expectedPrice5)
            {
                Console.WriteLine($"Test 5 Failed - Expected: {expectedPrice5}, Actual: {actualPrice5}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 5 Passed");
            }

            // Test 6: Multiple items, ship
            double expectedPrice6 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 200 * 20;
            double actualPrice6 = shipCalculator.CalculatePrice(items, 200);
            if (actualPrice6 != expectedPrice6)
            {
                Console.WriteLine($"Test 6 Failed - Expected: {expectedPrice6}, Actual: {actualPrice6}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 6 Passed");
            }

            // Test 7: Single item, airplane, non-fragile
            IPriceCalculator airplaneCalculator = new IPriceCalculator(50);
            double expectedPrice7 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 300 * 50;
            double actualPrice7 = airplaneCalculator.CalculatePrice(item1, 300);
            if (actualPrice7 != expectedPrice7)
            {
                Console.WriteLine($"Test 7 Failed - Expected: {expectedPrice7}, Actual: {actualPrice7}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 7 Passed");
            }

            // Test 8: Single item, airplane, fragile
            double expectedPrice8 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 300 * 50;
            double actualPrice8 = airplaneCalculator.CalculatePrice(item2, 300);
            if (actualPrice8 != expectedPrice8)
            {
                Console.WriteLine($"Test 8 Failed - Expected: {expectedPrice8}, Actual: {actualPrice8}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 8 Passed");
            }

            // Test 9: Multiple items, airplane
            double expectedPrice9 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 300 * 50;
            double actualPrice9 = airplaneCalculator.CalculatePrice(items, 300);
            if (actualPrice9 != expectedPrice9)
            {
                Console.WriteLine($"Test 9 Failed - Expected: {expectedPrice9}, Actual: {actualPrice9}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 9 Passed");
            }

            // Test 10: Multiple items, short distance
            double expectedPrice10 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 10 * 5;
            double actualPrice10 = trainCalculator.CalculatePrice(items, 10);
            if (actualPrice10 != expectedPrice10)
            {
                Console.WriteLine($"Test 10 Failed - Expected: {expectedPrice10}, Actual: {actualPrice10}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 10 Passed");
            }

            // Test 11: Single item, short distance
            double expectedPrice11 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 10 * 5;
            double actualPrice11 = trainCalculator.CalculatePrice(item1, 10);
            if (actualPrice11 != expectedPrice11)
            {
                Console.WriteLine($"Test 11 Failed - Expected: {expectedPrice11}, Actual: {actualPrice11}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 11 Passed");
            }

            // Test 12: Single item, medium distance
            double expectedPrice12 = ((item1.GetVolume() / 100) + item1.GetWeight()) * 100 * 5;
            double actualPrice12 = trainCalculator.CalculatePrice(item1, 100);
            if (actualPrice12 != expectedPrice12)
            {
                Console.WriteLine($"Test 12 Failed - Expected: {expectedPrice12}, Actual: {actualPrice12}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 12 Passed");
            }

            // Test 13: Single item, fragile, long distance
            double expectedPrice13 = (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) * 1000 * 5;
            double actualPrice13 = trainCalculator.CalculatePrice(item2, 1000);
            if (actualPrice13 != expectedPrice13)
            {
                Console.WriteLine($"Test 13 Failed - Expected: {expectedPrice13}, Actual: {actualPrice13}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 13 Passed");
            }

            // Test 14: Multiple items, long distance
            double expectedPrice14 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 1000 * 5;
            double actualPrice14 = trainCalculator.CalculatePrice(items, 1000);
            if (actualPrice14 != expectedPrice14)
            {
                Console.WriteLine($"Test 14 Failed - Expected: {expectedPrice14}, Actual: {actualPrice14}");
                allPassed = false;
            }
            else
            {
                Console.WriteLine("Test 14 Passed");
            }

            // Test 15: Multiple items, very long distance
            double expectedPrice15 = (((item1.GetVolume() / 100) + item1.GetWeight()) + (((item2.GetVolume() / 100) + item2.GetWeight()) * 2) + ((item3.GetVolume() / 100) + item3.GetWeight())) * 10000 * 5;
            double actualPrice15 = trainCalculator.CalculatePrice(items, 10000);
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
                Console.WriteLine("All TEST PASSED - WELL DONE!!");
            }
            else
            {
                Console.WriteLine("YOU HAVE FAILURES AT THE TESTS :( - SEE ABOVE");
            }
            Console.WriteLine("\n*********************************\n");
        }
    }
}
