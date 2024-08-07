using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Tal_Tony_Gerbi.TransportationApp.Exam3.Classes
{
    public class Driver
    {
        private string firstName;
        private string lastName;
        private string id;
        private CargoType driverType;

        public Driver()
        {

        }
        public Driver(string firstName, string lastName, string id, CargoType driverType)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.driverType = driverType;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }
        public string GetId()
        {
            return id;
        }
        public void SetId(string id)
        {
            this.id = id;
        }
        public CargoType GetType()
        {
            return driverType;
        }
        public void SetType(CargoType type)
        {
            driverType = type;
        }
        public bool Approve(CargoType type, string nextDestination)
        {
            bool driveAnswer = false;
            Console.WriteLine($"Driver {firstName}  {lastName} is ready to go? ");
            string answer = Console.ReadLine();

            if (answer == "yes" || answer == "y" || answer == "YES" || answer == "Y")
                driveAnswer = true;
            if (driveAnswer && type == driverType)
            {
                Console.WriteLine($"Driver {firstName} {lastName} approves the vehicle for the next destination: {nextDestination}");
                return true;
            }
            else
            {
                Console.WriteLine($"Driver {firstName} {lastName} is not authorized to approve this type of vehicle.");
                return false;
            }

        }
    }
}
