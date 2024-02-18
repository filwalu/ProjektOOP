using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{
  public class Motorcycle : Vehicle {
    public override int RequiredParkingSpaces => 1;
    public Motorcycle(string registrationNumber, string color) : base(registrationNumber, color) { }
}
}
