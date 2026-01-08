using System;

namespace SHSOS.Models
{
    public class EnergyConsumption
    {
        public int EnergyConsumptionID { get; set; }

        public int DepartmentID { get; set; }

        public DateTime ConsumptionDate { get; set; }

        public decimal MeterReadingStart { get; set; }

        public decimal MeterReadingEnd { get; set; }

        public decimal UnitsConsumedkWh { get; set; }

        public bool? PeakHourFlag { get; set; }

        public string? UsageCategory { get; set; }

        public string? LoadType { get; set; }

        public decimal? PowerFactor { get; set; }

        public decimal? UnitCost { get; set; }

        public decimal? TotalCost { get; set; }

        public bool? OverloadDetected { get; set; }

        public decimal? CarbonEmissionKg { get; set; }

        public DateTime? RecordedAt { get; set; }
    }
}
