using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Vehicles
{
    public class CargoVan : Vehicle
    {
        public int DriverExperience { get; set; }

        public override decimal InsuranceCostPerDay
        {
            get
            {
                decimal baseCost = base.InsuranceCostPerDay;
                if (DriverExperience > 5)
                {
                    baseCost *= 0.85m;
                }
                return baseCost;
            }
        }
    }
}
