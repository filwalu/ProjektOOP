using System;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace SystemParkingowy
{
    public class Program 
    {
        static void Main(string[] args)
        {
            var car1 = new Car("KR12345");
            var motorcycle1 = new Motorcycle("KR67890");
            var bus1 = new Bus("KR54321");

            Console.WriteLine($"Samochód {car1.RegistrationNumber} wymaga {car1.RequiredParkingSpaces} miejsca.");
            Console.WriteLine($"Motocykl {motorcycle1.RegistrationNumber} wymaga {motorcycle1.RequiredParkingSpaces} miejsca.");
            Console.WriteLine($"Autobus {bus1.RegistrationNumber} wymaga {bus1.RequiredParkingSpaces} miejsc.");
        }
    }
}