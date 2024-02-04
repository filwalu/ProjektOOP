using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{
    public class Bus : Vehicle
    {
        public Bus(string registrationNumber) : base(registrationNumber)
        {
            RequiredParkingSpaces = 3;
        }

        public int RequiredParkingSpaces { get; }
    }
}