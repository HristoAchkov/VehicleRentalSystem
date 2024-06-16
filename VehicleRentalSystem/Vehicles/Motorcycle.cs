using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int DriverAge { get; set; }
        public override decimal InsuranceCostPerDay
        {
            get
            {
                decimal baseCost = base.InsuranceCostPerDay;
                if (DriverAge < 25)
                {
                    baseCost *= 1.2m;
                }
                return baseCost;
            }
        }
    }
}
