using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalSystem.Vehicles
{
    public class Car : Vehicle
    {
        private int safetyRating;

        public int SafetyRating
        {
            get { return safetyRating; }
            set 
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(SafetyRating), "Safety Rating must be between 1 and 5.");
                }
                safetyRating = value;
            }
        }
        public override decimal InsuranceCostPerDay
        {
            get
            {
                decimal baseCost = base.InsuranceCostPerDay;
                if (SafetyRating >= 4)
                {
                    baseCost *= 0.9m;
                }
                return baseCost;
            }
        }
    }
}
