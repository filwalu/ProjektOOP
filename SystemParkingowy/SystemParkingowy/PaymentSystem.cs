using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{
    using System;
    using System.Collections.Generic;

    public class PaymentSystem
    {
        private Dictionary<string, double> parkingRates; // Słownik przechowujący stawki za godzinę dla różnych numerów rejestracyjnych

        public PaymentSystem()
        {
            
            parkingRates = new Dictionary<string, double>
        {
            { "KR12345", 4.0 }, // Przykładowa stawka dla numeru rejestracyjnego KR12345
            { "KR67890", 4.0 }, 
            
        };
        }

        public double CalculateParkingFee(string registrationNumber, int hoursParked)
        {
            if (parkingRates.ContainsKey(registrationNumber))
            {
                double hourlyRate = parkingRates[registrationNumber];
                return hourlyRate * hoursParked;
            }
            else
            {
                Console.WriteLine($"Brak stawki dla numeru rejestracyjnego {registrationNumber}.");
                return 0.0; 
            }
        }
    }

}
