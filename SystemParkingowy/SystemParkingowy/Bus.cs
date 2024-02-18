using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{

public class Bus : Vehicle {
    public override int RequiredParkingSpaces => 3;
    public Bus(string registrationNumber, string color) : base(registrationNumber, color) { }
}


}