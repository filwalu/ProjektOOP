using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SystemParkingowy
{

    internal class CheckIfEmpty : Parking
{
    public CheckIfEmpty() : base(new Dictionary<string, Vehicle>()) {
        // Initializes the base Parking class without any initial spots
    }

    public void DisplayParkingStatus() {
        // Create the layout of parking spots
        for (int row = 1; row <= 4; row++) {
            for (char col = 'A'; col <= 'D'; col++) {
                string spot = $"{row}{col}";

                // Check if the spot is occupied
                if (spots.ContainsKey(spot)) { // Use the inherited Spots property
                    Console.Write("## ");
                } else {
                    Console.Write($"{spot} ");
                }
            }
            Console.WriteLine();
        }
    }

    private int ConvertSpotLabelToKey(string label)
    {
        // Example conversion logic
        int row = int.Parse(label.Substring(0, 1)); // Extract the row number
        char col = label[1]; // Extract the column character
        int colOffset = col - 'A'; // Calculate the column offset from 'A'
        return (row - 1) * 4 + colOffset + 1; // Calculate the integer key based on row and column
    }
}
    
}