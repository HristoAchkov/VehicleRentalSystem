using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem.Vehicles;

namespace VehicleRentalSystem
{
    public class Vehicle
    {
        private decimal insuranceCostPerDay;
        public Vehicle()
        {
            Type = this.GetType().Name;
        }
        public string CustomerName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public decimal InitialInsurance 
        {
            get => InitialInsuranceCalculation();
            set { insuranceCostPerDay = value; }
        }
        public virtual decimal InsuranceCostPerDay 
        {
            get => InsuranceCostPerDayCalculation();
            set { insuranceCostPerDay = value; }
        }
        public decimal InsuranceCostPerDayCalculation()
        {
            switch (Type.ToLower())
            {
                case "car":
                    return insuranceCostPerDay = Value * 0.0001m;
                case "motorcycle":
                    return insuranceCostPerDay = Value * 0.0002m;
                case "cargovan":
                    return insuranceCostPerDay = Value * 0.0003m;
                default:
                    return 0;
            }
        }
        public decimal InitialInsuranceCalculation()
        {
            switch (Type.ToLower())
            {
                case "car":
                    return insuranceCostPerDay = Value * 0.0001m;
                case "motorcycle":
                    return insuranceCostPerDay = Value * 0.0002m;
                case "cargovan":
                    return insuranceCostPerDay = Value * 0.0003m;
                default:
                    return 0;
            }
        }
    }
}
