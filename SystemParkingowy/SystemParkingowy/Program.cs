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
        
        string asciiArtPath = "C:\\Users\\filip\\ProjektOOP\\SystemParkingowy\\SystemParkingowy\\ascii.txt";
        
        if (File.Exists(asciiArtPath)) {
        string asciiArt = File.ReadAllText(asciiArtPath);
        Console.WriteLine(asciiArt);
        }
        
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
                    
                    Console.WriteLine($"Available spots: {parking.CheckAvailability(1)}");
                    Thread.Sleep(1000); 
                    Console.Clear(); 
                    break;
                case "2":
                    Console.WriteLine("Enter registration number:");
                    string regNumber = Console.ReadLine();
                    
                    Console.WriteLine("Enter color:");
                    string color = Console.ReadLine();
                    Console.WriteLine("Choose vehicle type [1] Car [2] Motorcycle [3] Bus:");
                    string typeChoice = Console.ReadLine();


                    Vehicle vehicle = null;
                    switch (typeChoice) {
                        case "1":
                            vehicle = new Car(regNumber, color);
                            break;
                        case "2":
                            vehicle = new Motorcycle(regNumber, color);
                            break;
                        case "3":
                            vehicle = new Bus(regNumber, color);
                            break;
                        default:
                            Console.WriteLine("Invalid vehicle type selected.");
                            break;
                        }

                        if (vehicle != null) {
                            parking.EnterParking(vehicle);
                        }
                        
                        
                        Thread.Sleep(1000); 
                        Console.Clear(); 
                        break;

                            

                case "3":
                Console.WriteLine("Enter registration number for exiting vehicle:");
                string exitRegNumber = Console.ReadLine();
                
                

                
                parking.ExitParking(exitRegNumber);
               
                
                Console.WriteLine($"Vehicle with registration number {exitRegNumber} has exited.");
                Thread.Sleep(1000); 
                Console.Clear(); 
                break;
                case "4":
                        // Show general information
                        Console.WriteLine("Filip Walat 67204 Projekt programowanie obiektowe");
                        Thread.Sleep(1000); 
                        Console.Clear();
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