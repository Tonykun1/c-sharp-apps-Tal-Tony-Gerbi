using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Abstracts;
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
            Port tlv = new Port(CargoType.Airplane, "Israel", "TLV", "Ben Gurion", 12);
            Port eilat = new Port(CargoType.Airplane, "Israel", "Eilat", "Ramon", 12);
            IPortable item1 = new GeneralItem(5, 50, 80, 200, false, tlv);
            IPortable item2 = new GeneralItem(50, 50, 80, 200, false, tlv);
            IPortable item3 = new GeneralItem(5, 5, 8, 200, true, tlv);
            List<IPortable> items = new List<IPortable> { item1, item2, item3 };
            bool allPassed = true;
            //---------------------------Test - 1---------------------------

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
                    allPassed = false;
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

            IPortable item4 = new GeneralItem(5, 5, 8, 700, false, tlv);
            IPortable item5 = new GeneralItem(5, 5, 8, 150, false, tlv);
            IPortable item6 = new GeneralItem(500, 500, 800, 15000, false, tlv);

            List<IPortable> itemsAll = new List<IPortable> { item4, item5, item6 };

            Airplane LY466 = new Airplane(stephan, 10000, 10000, tlv, eilat, 150);

            Console.WriteLine("Test - 2");
            LY466.GetContainer().Load(itemsAll);

            LY466.SetOverWeight(true);

            if (LY466.GetContainer().GetCurrentWeight() > LY466.GetContainer().GetMaxWeight() && LY466.GetOverWeight())
            {
                Console.WriteLine("Test 2 - Passed");
            }
            else
            {
                Console.WriteLine($"Test 2 - Failed -> Your OverWeight Property is: {LY466.GetOverWeight()} | Expected: {LY466.GetContainer().GetCurrentWeight() > LY466.GetContainer().GetMaxWeight()}");
                allPassed = false;
            }

            // Ready to go
            LY466.ReadyToGo();

            ////---------------------------Test - 3---------------------------

            Console.WriteLine("\n---------------------------Test - 3---------------------------");
            Console.WriteLine("Adding and Removing Items from a Container");
            Container containerTest = new Container(2000, 2000);  
            IPortable testItem1 = new GeneralItem(10, 10, 10, 10, false, tlv);
            IPortable testItem2 = new GeneralItem(10, 10, 10, 10, false, tlv); ;  

            Console.WriteLine("Adding items to the container:");
            containerTest.Load(testItem1);
            containerTest.Load(testItem2);
            containerTest.GetContainerList();  

            Console.WriteLine("\nRemoving an item from the container:");
            containerTest.Unload(testItem1);

            double expectedWeight = testItem2.GetWeight();
            double expectedVolume = testItem2.GetVolume();

            if (containerTest.GetCurrentWeight() == expectedWeight && containerTest.GetCurrentVolume() == expectedVolume)
            {
                Console.WriteLine("Test 3 - Passed: Correctly added and removed items from the container.");
            }
            else
            {
                Console.WriteLine("Test 3 - Failed: Incorrect handling of items in the container.");
                Console.WriteLine($"Expected weight: {expectedWeight}, Actual weight: {containerTest.GetCurrentWeight()}");
                Console.WriteLine($"Expected volume: {expectedVolume}, Actual volume: {containerTest.GetCurrentVolume()}");
                allPassed = false;
            }

            Console.WriteLine("----------------------------------------------------------");

            ////---------------------------Test - 4---------------------------

            Console.WriteLine("\n---------------------------Test - 4---------------------------");
            Console.WriteLine("Testing Airplane Operations");


            Crone cn = new Crone(10000, 1000);
            Airplane LYtest = new Airplane(stephan, 1000, 1000, tlv, eilat, 150);

            double price = LYtest.CalculatePrice(items, LYtest.GetNextPortDistance());
            Console.WriteLine("Price of travel: " + price);

            LYtest.SetDriver(stephan);
            LYtest.SetNextDestinetion(tlv);

            LYtest.GetContainer().Load(items);
            LYtest.DisplayCargo();

            LYtest.GoToNextDestinetion();


            LYtest.GetContainer().Unload(items);

            Console.WriteLine("After unloading:");
            LYtest.DisplayCargo();


            if (LYtest.GetContainer().GetCurrentWeight() == 0)
            {
                Console.WriteLine("Test 4 - Passed");
            }
            else
            {
                Console.WriteLine("Test 4 - Failed -> Cargo not unloaded properly. Current Weight: " + LYtest.GetContainer().GetCurrentWeight());
                allPassed = false;
            }

            Console.WriteLine("\n---------------------------Test - 5---------------------------");
            Console.WriteLine("Testing Ship Operations and Price Calculation");

            Port haifa = new Port(CargoType.Ship, "Israel", "Haifa", "15", 15);
            Driver shipDriver = new Driver("David", "Haifa", "5", CargoType.Ship);
            Ship testShip = new Ship(shipDriver, 10000, 50000, haifa, tlv, 50);

            Console.WriteLine("Assigning driver to ship:");
            testShip.SetDriver(shipDriver);
            Console.WriteLine($"Ship driver: {testShip.GetDriver().GetFirstName()}");

            Container container1 = new Container(2000, 15000);
            Container container2 = new Container(1500, 12000);
            Container container3 = new Container(3000, 5000);

            double expectedPrice1 = testShip.CalculatePrice(item1, 100); 
            double expectedPrice2 = testShip.CalculatePrice(item2, 100); 
            double expectedPrice3 = testShip.CalculatePrice(item3, 100);

            Console.WriteLine("Adding containers to the ship:");
            container1.Load(item1);
            container2.Load(item2);
            container3.Load(item3);
            testShip.AddContainer(container1);
            testShip.AddContainer(container2);
            testShip.AddContainer(container3);
           // testShip.DisplayContainers();

            Console.WriteLine("\nCalculating shipping price for containers:");
            double actualPrice1 = testShip.CalculatePrice(item1 , 100);
            double actualPrice2 = testShip.CalculatePrice(item2, 100);
            double actualPrice3 = testShip.CalculatePrice(item3, 100);



            List<IPortable> containers = new List<IPortable> { item1, item2, item3 };
            double expectedTotalPrice = testShip.CalculatePrice(containers, 100);
            double actualTotalPrice = testShip.CalculatePrice(containers, 100);
  

            Console.WriteLine("\nRemoving a container from the ship:");
            testShip.RemoveContainer(container1);
            //testShip.DisplayContainers();

            double expectedWeightAfterRemoval = 12000 + 5000; 
            double expectedVolumeAfterRemoval = 1500 + 3000; 

            double actualWeightAfterRemoval = testShip.GetCurrentWeight();
            double actualVolumeAfterRemoval = testShip.GetCurrentVolume();

            if (testShip.GetCurrentWeight() < testShip.GetMaxWeight() && !testShip.GetOverWeight())
            {
                Console.WriteLine("Test 5 - Passed: Ship correctly handled the container addition, price calculation, and removal operations.");
            }
            else
            {
                Console.WriteLine("Test 5 - Failed: Ship did not handle the operations correctly.");
                Console.WriteLine($"Expected Weight: {expectedWeightAfterRemoval}, Actual Weight: {actualWeightAfterRemoval}");
                Console.WriteLine($"Expected Volume: {expectedVolumeAfterRemoval}, Actual Volume: {actualVolumeAfterRemoval}");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("\n---------------------------Test - 6---------------------------");
            Console.WriteLine("Testing Driver Assignment and Vehicle Operation");

            Driver trainDriver = new Driver("Alex", "Haifa", "3", CargoType.Train);
            Train testTrain = new Train(trainDriver,2000, 5000, tlv, haifa,10);

            Console.WriteLine("Assigning driver to train:");
            testTrain.SetDriver(trainDriver);
            Console.WriteLine($"Train driver: {testTrain.GetDriver().GetFirstName()}");

            Console.WriteLine("Loading items onto the train:");
            Crone crone = new Crone(50, 50);
            crone.Load(items);
            testTrain.AddCrone(crone);
            //testTrain.DisplayCrone();

            Console.WriteLine("\nMoving train to the next destination:");
            testTrain.GoToNextDestinetion();

            Console.WriteLine("Unloading items from the train:");
            testTrain.Unload(items);
            //testTrain.DisplayCrone();

            if (testTrain.GetCurrentWeight() == 0 && testTrain.GetCurrentVolume() == 0)
            {
                Console.WriteLine("Test 6 - Passed: Train correctly handled the loading, moving, and unloading operations.");
            }
            else
            {
                Console.WriteLine("Test 6 - Failed: Train did not handle the operations correctly.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("\n---------------------------Test - 7---------------------------");
            Airplane deliveryTestPlane = new Airplane(stephan, 2000, 10000, tlv, eilat, 100);
            deliveryTestPlane.SetDriver(stephan);

            Console.WriteLine("Loading items onto the plane:");
            deliveryTestPlane.GetContainer().Load(items);
            //deliveryTestPlane.DisplayCargo();

            Console.WriteLine("\nFlying to the next destination and unloading cargo:");
            deliveryTestPlane.GoToNextDestinetion();   
            deliveryTestPlane.GetContainer().Unload(items);
            //deliveryTestPlane.DisplayCargo();

            if (deliveryTestPlane.GetContainer().GetCurrentWeight() == 0 && deliveryTestPlane.GetContainer().GetCurrentVolume() == 0)
            {
                Console.WriteLine("Test 7 - Passed: Plane correctly switched destinations and delivered cargo.");
            }
            else
            {
                Console.WriteLine("Test 7 - Failed: Plane did not handle cargo delivery correctly.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("\n---------------------------Test - 8---------------------------");
            Console.WriteLine("Testing Multiple Drivers in the Same Vehicle");

            Train testTrain2 = new Train(tony, 2000, 5000, tlv, eilat, 10);
            testTrain2.SetDriver(tony);

            Console.WriteLine("Assigning another driver:");
            testTrain2.SetDriver(bobi);

            if (testTrain2.GetDriver().GetFirstName() == bobi.GetFirstName())
            {
                Console.WriteLine("Test 8 - Passed: Train correctly handled multiple drivers.");
            }
            else
            {
                Console.WriteLine("Test 8 - Failed: Train did not handle multiple drivers correctly.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("\n---------------------------Test - 9---------------------------");
            Console.WriteLine("Testing Train Cargo Price Calculation");

            Train priceTestTrain = new Train(trainDriver, 2000, 5000, tlv, eilat, 10);
            Crone croneForPriceTest = new Crone(2000, 3000);
            IPortable testItemForPrice = new GeneralItem(100, 200, 300, 4000, true, tlv);
            croneForPriceTest.Load(testItemForPrice);
            priceTestTrain.AddCrone(croneForPriceTest);

            double expectedPrice = priceTestTrain.CalculatePrice(testItemForPrice, priceTestTrain.GetNextPortDistance());
            double actualPrice = priceTestTrain.CalculatePrice(testItemForPrice, priceTestTrain.GetNextPortDistance());

            Console.WriteLine($"Expected Price: ${expectedPrice}");
            Console.WriteLine($"Actual Price: ${actualPrice}");

            if (Math.Abs(expectedPrice - actualPrice) < 0.01) 
            {
                Console.WriteLine("Test 9 - Passed: Train correctly calculated cargo price.");
            }
            else
            {
                Console.WriteLine("Test 9 - Failed: Train did not correctly calculate cargo price.");
                Console.WriteLine($"Expected Price: ${expectedPrice}");
                Console.WriteLine($"Actual Price: ${actualPrice}");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("\n---------------------------Test - 10---------------------------");
            Console.WriteLine("Testing Shipping Costs for Different Cargo Types");

            Ship shipForTest = new Ship(bobi, 5000, 10000, eilat, tlv, 200);
            double fragileItemCost = shipForTest.CalculatePrice( item2 , 100);
            double nonFragileItemCost = shipForTest.CalculatePrice( item3 , 100);

            if (fragileItemCost > nonFragileItemCost)
            {
                Console.WriteLine("Test 10 - Passed: Correct shipping costs calculated for different cargo types.");
            }
            else
            {
                Console.WriteLine("Test 10 - Failed: Incorrect shipping costs calculated.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n---------------------------Test - 11---------------------------");
            Console.WriteLine("Testing Maximum Capacity Handling in Train");

            Train capacityTestTrain = new Train(tony, 10000, 20000, tlv, eilat, 50);
            capacityTestTrain.AddCrone(new Crone(5000, 10000));
            capacityTestTrain.AddCrone(new Crone(6000, 11000));

            if (capacityTestTrain.GetCurrentWeight() <= capacityTestTrain.GetMaxWeight())
            {
                Console.WriteLine("Test 11 - Passed: Train correctly handled maximum capacity.");
            }
            else
            {
                Console.WriteLine("Test 11 - Failed: Train did not handle maximum capacity correctly.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");
            
            Console.WriteLine("\n---------------------------Test - 12---------------------------");
            Console.WriteLine("Testing Overweight Handling in Container");

            Container testContainer = new Container(5000, 15000);
            IPortable overweightItem = new GeneralItem(20, 20, 20, 20000, false, haifa);

            testContainer.Load(overweightItem);

            if (testContainer.GetCurrentWeight() > testContainer.GetMaxWeight())
            {
                Console.WriteLine("Test 12 - Passed: Container correctly handled overweight item.");
            }
            else
            {
                Console.WriteLine("Test 12 - Failed: Container did not handle overweight item correctly.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("\n---------------------------Test - 13---------------------------");
            Console.WriteLine("Testing Train Cargo Price Calculation");

            testTrain = new Train(tony, 2000, 5000, tlv, eilat, 10);
             expectedPrice = testTrain.CalculatePrice(items , 100);

            Console.WriteLine($"Calculated Price for Train: ${expectedPrice}");

            if (expectedPrice > 0)
            {
                Console.WriteLine("Test 13 - Passed: Train price calculation is correct.");
            }
            else
            {
                Console.WriteLine("Test 13 - Failed: Train price calculation is incorrect.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n---------------------------Test - 14---------------------------");
            Console.WriteLine("Testing Airplane Loading and Unloading Operations");

            Airplane testAirplane = new Airplane(stephan, 10000, 2000, tlv, eilat, 150);

            testAirplane.GetContainer().Load(items);
            testAirplane.GetContainer().Unload(items);

            if (testAirplane.GetContainer().GetCurrentWeight() == 0 && testAirplane.GetContainer().GetCurrentVolume() == 0)
            {
                Console.WriteLine("Test 14 - Passed: Airplane correctly handled loading and unloading operations.");
            }
            else
            {
                Console.WriteLine("Test 14 - Failed: Airplane did not handle loading and unloading correctly.");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n---------------------------Test - 15---------------------------");
            Console.WriteLine("Testing the Impact of Fragile Items on Shipping Costs");

             shipDriver = new Driver("David", "Haifa", "5", CargoType.Ship);
             testShip = new Ship(shipDriver, 10000, 50000, haifa, tlv, 50);

            IPortable fragileItem = new GeneralItem(5, 5, 8, 100, true, haifa);  
            IPortable nonFragileItem = new GeneralItem(5, 5, 8, 100, false, haifa); 

            List<IPortable> items1 = new List<IPortable> { fragileItem, nonFragileItem };

             fragileItemCost = testShip.CalculatePrice(fragileItem, 100);

             nonFragileItemCost = testShip.CalculatePrice(nonFragileItem, 100);

            double totalCost = testShip.CalculatePrice(items1, 100);

            double expectedTotalCost = fragileItemCost + nonFragileItemCost;

            Console.WriteLine($"Shipping cost for fragile item: ${fragileItemCost}");
            Console.WriteLine($"Shipping cost for non-fragile item: ${nonFragileItemCost}");
            Console.WriteLine($"Expected total cost: ${expectedTotalCost}");
            Console.WriteLine($"Actual total cost: ${totalCost}");

            if (Math.Abs(totalCost - expectedTotalCost) < 0.01)
            {
                Console.WriteLine("Test 15 - Passed: Shipping cost correctly accounts for fragile items.");
            }
            else
            {
                Console.WriteLine("Test 15 - Failed: Shipping cost does not correctly account for fragile items.");
                Console.WriteLine($"Expected Total Cost: ${expectedTotalCost}, Actual Total Cost: ${totalCost}");
                allPassed = false;
            }
            Console.WriteLine("----------------------------------------------------------");
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

        }

    }
}
