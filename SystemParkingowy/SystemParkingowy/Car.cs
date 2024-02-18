using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{
public class Car : Vehicle {
    public override int RequiredParkingSpaces => 1;
    public Car(string registrationNumber, string color) : base(registrationNumber, color) { }
}
}
