using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SystemParkingowy {
    public class Parking {
        public const string ParkingStateFile = "C:\\Users\\filip\\ProjektOOP\\SystemParkingowy\\SystemParkingowy\\parking_state.txt";
        protected Dictionary<string, Vehicle> spots = new Dictionary<string, Vehicle>();
        public Parking(Dictionary<string, Vehicle> initialSpots) {
        spots = initialSpots;
         }
         

        public Parking() {
            InitializeParkingSpots();
            LoadParkingState();
        }

        public bool CheckAvailability(int requiredSpaces) {
            // Logic to check available spaces
            return spots.Count(s => s.Value == null) >= requiredSpaces;
        }

    public void EnterParking(Vehicle vehicle) {
    int requiredSpaces = vehicle.RequiredParkingSpaces;
    List<string> assignedSpots = new List<string>();

    // Find and assign the required number of spots
    for (int i = 0; i < requiredSpaces; i++) {
        var freeSpot = spots.FirstOrDefault(s => s.Value == null).Key;
        if (!string.IsNullOrEmpty(freeSpot)) {
            spots[freeSpot] = vehicle;
            assignedSpots.Add(freeSpot);

            // Move to the next available spot for multi-spot vehicles
            spots.Remove(freeSpot);
        }
    }

    // Log each assigned spot to parking_state.txt
    foreach (var spot in assignedSpots) {
        File.AppendAllText(ParkingStateFile, $"{vehicle.GetType().Name} {vehicle.RegistrationNumber} {spot}\n");
    }

    if (assignedSpots.Any()) {
        Console.WriteLine($"{vehicle.GetType().Name} {vehicle.RegistrationNumber} parked at spots: {string.Join(", ", assignedSpots)}.");
    } else {
        Console.WriteLine("No available spots.");
    }
}


    private string FindFreeSpot(int requiredSpaces) {
        // Here you would implement the logic to find the appropriate number of free contiguous spots
        // For simplicity, let's assume each vehicle only requires one spot
        foreach (var spot in spots) {
            if (spot.Value == null) {
                return spot.Key; // Return the first free spot
            }
        }
        return null; // If no spots are available, return null
    }
    public void ExitParking(string registrationNumber) {
    // Load the current parking state from the file
    var allEntries = File.ReadAllLines(ParkingStateFile).ToList();
    var vehicleEntries = allEntries.Where(line => line.Contains(registrationNumber)).ToList();

    if (vehicleEntries.Any()) {
        // Remove the vehicle's entries from the list
        allEntries = allEntries.Except(vehicleEntries).ToList();

        // Update the file with the new state
        File.WriteAllLines(ParkingStateFile, allEntries);

        Console.WriteLine($"Vehicle {registrationNumber} has exited.");
    } else {
        Console.WriteLine($"Vehicle {registrationNumber} not found.");
    }
}



        private void InitializeParkingSpots() {
            for (int row = 1; row <= 10; row++) {
                for (char col = 'A'; col <= 'J'; col++) {
                    spots[$"{row}{col}"] = null; // null indicates the spot is empty
                }
            }
        }

    private void LoadParkingState() {
    InitializeParkingSpots(); // Reset spots before loading the state

    if (File.Exists(ParkingStateFile)) {
        var lines = File.ReadAllLines(ParkingStateFile);
        foreach (var line in lines) {
            var parts = line.Split(' ');
            if (parts.Length == 3) {
                string vehicleType = parts[0];
                string registrationNumber = parts[1];
                string spotId = parts[2];

                Vehicle vehicle = null;
                switch (vehicleType) {
                    case "Car":
                        vehicle = new Car(registrationNumber, ""); // Assuming color is not used here
                        break;
                    case "Motorcycle":
                        vehicle = new Motorcycle(registrationNumber, "");
                        break;
                    case "Bus":
                        vehicle = new Bus(registrationNumber, "");
                        break;
                }

                if (vehicle != null && !spots.ContainsKey(spotId)) {
                    spots.Add(spotId, vehicle); // Ensure spots are uniquely assigned
                }
            }
        }
    }
}


private void SaveParkingState() {
    var lines = new List<string>();
    foreach (var spot in spots) {
        // Only save occupied spots
        if (spot.Value != null) {
            lines.Add($"{spot.Key},{spot.Value.RegistrationNumber},{spot.Value.Color}");
        }
    }
    File.WriteAllLines(ParkingStateFile, lines);
}
    }
}
