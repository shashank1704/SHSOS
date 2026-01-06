namespace SHSOS.Models
{
    public class WaterConsumption
    {
        public int ConsumptionID { get; set; }

        public int DepartmentID { get; set; }

        public DateTime ConsumptionDate { get; set; }

        public decimal ReadingStart { get; set; }

        public decimal ReadingEnd { get; set; }

        public decimal UnitsConsumedLiters { get; set; }

        public bool PeakHourFlag { get; set; }

        public bool LeakageDetected { get; set; }

        public string UsageCategory { get; set; }

        public string WeatherCondition { get; set; }

        public string Remarks { get; set; }

        public DateTime RecordedAt { get; set; }

    }
}
