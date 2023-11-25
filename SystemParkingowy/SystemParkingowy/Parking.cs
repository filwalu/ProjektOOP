using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    internal class Parking
    {
        Dictionary<string, string> parkingSpots = new Dictionary<string, string>();
        public Parking(Dictionary<string, string> parkingSpots)
        {
            this.parkingSpots = parkingSpots;
        }
    }
}
