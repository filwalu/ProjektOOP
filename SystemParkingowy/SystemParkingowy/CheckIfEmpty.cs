using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle;

namespace SystemParkingowy
{

    internal class CheckIfEmpty : Parking
    {
        public CheckIfEmpty(Dictionary<string, string> parkingSpots) : base(parkingSpots)
        {
        }

        public void DisplayParkingStatus()
        {
            // Tworzenie układu miejsc parkingowych
            for (int row = 1; row <= 4; row++)
            {
                for (char col = 'A'; col <= 'D'; col++)
                {
                    string spot = $"{row}{col}";

                    // Sprawdź, czy miejsce jest zajęte
                    if (parkingSpots.ContainsKey(spot))
                    {
                        Console.Write("## ");
                    }
                    else
                    {
                        Console.Write($"{spot} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}