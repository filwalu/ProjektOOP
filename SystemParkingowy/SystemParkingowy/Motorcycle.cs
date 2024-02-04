using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber) : base(registrationNumber)
        {
            RequiredParkingSpaces = 1;
        }

        public int RequiredParkingSpaces { get; }
    }
}
