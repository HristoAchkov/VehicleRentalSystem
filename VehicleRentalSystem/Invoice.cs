using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalSystem;
using VehicleRentalSystem.Vehicles;

namespace VehicleRentalSystem
{
    public class Invoice
    {
        private string vehicleType;
        private decimal rentalCostPerDay;
        private decimal totalInsurance;

        public Invoice(Vehicle vehicle)
        {
            CustomerName = vehicle.CustomerName;
            ReservationStartDate = vehicle.RentalStart;
            ReservationEndDate = vehicle.RentalEnd;
            RentedVehicleName = string.Format("{0} {1}", vehicle.Brand, vehicle.Model);
            vehicleType = vehicle.Type;
            InitialInsurance = vehicle.InitialInsurance;
            ActualInsurance = vehicle.InsuranceCostPerDay;
        }

        public DateTime Date 
        { get => DateTime.Today; }
        public string CustomerName { get; set; } = string.Empty;
        public string RentedVehicleName { get; set; } = string.Empty;
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public TimeSpan RentalPeriod 
        { get => RentalPeriodCalculation(); }
        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }
        public DateTime ActualReturnDate
        { get => DateTime.Now; }
        public TimeSpan ActualRentalDays 
        { get => ActualRentalDaysCalculation(); }
        public decimal EarlyRent
        {
            get => EarlyRentCalculation();
        }
        public decimal RentalCostPerDay 
        {
            get => RentalCostPerDayCalculation();
            set { rentalCostPerDay = value; }
        }
        public decimal TotalRent 
        { 
            get => TotalRentCalculation(); 
        }

        public decimal InitialInsurance { get; set; }

        public decimal ActualInsurance { get; set; }


        public decimal TotalInsurance
        {
            get => TotalInsuranceCalculation();
            set { totalInsurance = value; }
        }

        public decimal Total
        {
            get => TotalAmountCalculation();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("XXXXXXXXX");
            sb.AppendLine($"Date: {Date.ToShortDateString()}");
            sb.AppendLine($"Customer name: {CustomerName}");
            sb.AppendLine($"Rented vehicle: {RentedVehicleName}");
            sb.AppendLine();
            sb.AppendLine($"Reservation Start Date: {ReservationStartDate.ToShortDateString()}");
            sb.AppendLine($"Reservation End Date: {ReservationEndDate.ToShortDateString()}");
            sb.AppendLine($"Reserved Rental Days: {RentalPeriod.Days} days");
            sb.AppendLine();
            sb.AppendLine($"Actual Return Date: {ActualReturnDate.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Actual Rental Days: {ActualRentalDays.Days} days");
            sb.AppendLine();
            sb.AppendLine($"Rental Cost Per Day: ${RentalCostPerDay:f2}");
            if (ActualInsurance != InitialInsurance)
            {
                sb.AppendLine($"Initial Insurance Per Day: ${InitialInsurance:f2}");
            }
            if (ActualInsurance > InitialInsurance)
            {
                sb.AppendLine($"Insurance Addition Per Day: ${ActualInsurance - InitialInsurance:f2}");
            }
            else if (InitialInsurance > ActualInsurance)
            {
                sb.AppendLine($"Insurance Discount Per Day: ${InitialInsurance - ActualInsurance:f2}");
            }
            sb.AppendLine($"Insurance Per Day: ${TotalInsurance / ActualRentalDays.Days:f2}");
            sb.AppendLine();
            if (ActualRentalDays.Days < RentalPeriod.Days)
            {
                sb.AppendLine($"Early Discount For Rent: ${EarlyRent - TotalRent}");
            }
            if (ActualRentalDays.Days < RentalPeriod.Days)
            {
                sb.AppendLine($"Early Discount for Insurance: ${ActualInsurance * RentalPeriod.Days - ActualInsurance * ActualRentalDays.Days:f2}");
            }
            sb.AppendLine();
            if (ActualRentalDays.Days < RentalPeriod.Days)
            {
                sb.AppendLine($"Total rent: ${EarlyRent:f2}");
            }
            else
            {
                sb.AppendLine($"Total rent: ${TotalRent:f2}");
            }
            sb.AppendLine($"Total insurance: ${ActualInsurance * ActualRentalDays.Days:f2}");
            sb.AppendLine($"Total: ${Total:f2}");
            sb.AppendLine("XXXXXXXXX");
            
            return sb.ToString();
        }

        public decimal EarlyRentCalculation()
        {
            int remainingDays = RentalPeriod.Days - ActualRentalDays.Days;

            decimal fullPriceCost = RentalCostPerDay * ActualRentalDays.Days;
            decimal halfPriceCost = (RentalCostPerDay * 0.5m) * remainingDays;

            return fullPriceCost + halfPriceCost;
        }
        public TimeSpan RentalPeriodCalculation()
        {
            return ReservationEndDate - ReservationStartDate;
        }
        public TimeSpan ActualRentalDaysCalculation()
        {
            return ActualReturnDate - ReservationStartDate;
        }
        public decimal TotalInsuranceCalculation()
        {
            return ActualInsurance * ActualRentalDays.Days;
        }
        public decimal RentalCostPerDayCalculation()
        {
            switch (VehicleType.ToLower())
            {
                case "car":
                    if (RentalPeriod.Days <= 7)
                    {
                        return RentalCostPerDay = 20;
                    }
                    else
                    {
                        return RentalCostPerDay = 15;
                    }
                case "motorcycle":
                    if (RentalPeriod.Days <= 7)
                    {
                        return RentalCostPerDay = 15;
                    }
                    else
                    {
                        return RentalCostPerDay = 10;
                    }
                case "cargovan":
                    if (RentalPeriod.Days <= 7)
                    {
                        return RentalCostPerDay = 50;
                    }
                    else
                    {
                        return RentalCostPerDay = 40;
                    }
                default:
                    return 0;
            }
        }
        public decimal TotalRentCalculation()
        {
            return RentalCostPerDay * ActualRentalDays.Days;
        }
        public decimal TotalAmountCalculation()
        {
            if (ActualRentalDays.Days < RentalPeriod.Days)
            {
                return EarlyRent + TotalInsurance;
            }
            else
            {
                return TotalRent + TotalInsurance;
            }
        }
    }
}
