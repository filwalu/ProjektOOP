using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemParkingowy
{


    public abstract class Vehicle
    {
        public string RegistrationNumber { get; }

        protected Vehicle(string registrationNumber)
        {
            RegistrationNumber = registrationNumber;
        }
    }
}