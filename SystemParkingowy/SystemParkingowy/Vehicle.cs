using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{


   public abstract class Vehicle {
    public string RegistrationNumber { get; }
    public string Color { get; }
    public abstract int RequiredParkingSpaces { get; }

    protected Vehicle(string registrationNumber, string color) {
        RegistrationNumber = registrationNumber;
        Color = color;
    }
}
}