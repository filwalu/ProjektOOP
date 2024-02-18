using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SystemParkingowy {
    public class Parking {
        protected Dictionary<string, Vehicle> spots = new Dictionary<string, Vehicle>();
         public Parking(Dictionary<string, Vehicle> initialSpots) {
        spots = initialSpots;
         }
        public const string ParkingStateFile = @"\SystemParkingowy\SystemParkingowy\parking_state.txt"; 

        public Parking() {
            InitializeParkingSpots();
            LoadParkingState();
        }

        public bool CheckAvailability(int requiredSpaces) {
            // Logic to check available spaces
            return spots.Count(s => s.Value == null) >= requiredSpaces;
        }

        public void EnterParking(string spotId, Vehicle vehicle) {
            // Assign the vehicle to a specific spot
            if (spots.ContainsKey(spotId) && spots[spotId] == null) {
                spots[spotId] = vehicle;
                SaveParkingState();
            }
        }

        public void ExitParking(string spotId) {
            // Find the vehicle by spotId and free the spot
            if (spots.ContainsKey(spotId) && spots[spotId] != null) {
                spots[spotId] = null;
                SaveParkingState();
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
    // Clear the current state before loading
    InitializeParkingSpots(); 

    // Check if the file exists before trying to read
    if (File.Exists(ParkingStateFile)) {
        var lines = File.ReadAllLines(ParkingStateFile);
        foreach (var line in lines) {
            var parts = line.Split(',');
            if (parts.Length == 3) { // Assuming line format is "spotId,registrationNumber,color"
                string spotId = parts[0];
                string registrationNumber = parts[1];
                string color = parts[2];

                // Based on registration number and color, create the appropriate vehicle object
                // This assumes a simple system where all vehicles are considered 'Car'
                // You might need a more complex logic if there are different types of vehicles
                spots[spotId] = new Car(registrationNumber, color);
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
