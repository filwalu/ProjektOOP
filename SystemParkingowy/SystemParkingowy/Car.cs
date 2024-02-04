using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{
    public class Car : Vehicle
    {
        public Car(string registrationNumber) : base(registrationNumber)
        {
            RequiredParkingSpaces = 2;
        }

        public int RequiredParkingSpaces { get; }
    }
}
