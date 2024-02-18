using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace SystemParkingowy
{
    public class Program
    {
    public static void Main(string[] args) {
        
        Parking parking = new Parking();
        
        bool exit = false;
        while (!exit) {
            Console.WriteLine("1. Check Availability");
            Console.WriteLine("2. Enter Parking");
            Console.WriteLine("3. Exit Parking");
            Console.WriteLine("4. General Information");
            Console.WriteLine("5. Exit");

            string option = Console.ReadLine();
            switch (option) {
                case "1":
                    // Check availability for cars
                    Console.WriteLine($"Available spots: {parking.CheckAvailability(1)}");
                    break;
                case "2":
                    
                    // Process vehicle entry (simplified for cars)
                    Console.WriteLine("Enter spot ID (e.g., '1A'):");
                    string spotId = Console.ReadLine(); // Get the spot ID from the user
                    Console.WriteLine("Enter registration number:");
                    string regNumber = Console.ReadLine();
                    Console.WriteLine("Enter color:");
                    string color = Console.ReadLine();
                    parking.EnterParking(spotId, new Car(regNumber, color)); // Pass in both spot ID and the new car
                    Console.WriteLine("Vehicle entered.");
                    break;
                   case "3":
                    // Process vehicle exit
                    Console.WriteLine("Enter registration number for exiting vehicle:");
                    regNumber = Console.ReadLine();
                    parking.ExitParking(regNumber);
                    Console.WriteLine("Vehicle exited.");
                    break;
                case "4":
                    // Show general information
                    Console.WriteLine("General Parking Information...");
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
}