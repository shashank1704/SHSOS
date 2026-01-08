using System;

namespace SHSOS.Models
{
    public class WasteManagement
    {
        public int WasteRecordID { get; set; }

        public int DepartmentID { get; set; }

        public string WasteType { get; set; }

        public string? WasteCategory { get; set; }

        public decimal WasteWeightKg { get; set; }

        public string? SegregationStatus { get; set; }

        public bool? RecyclableFlag { get; set; }

        public string? DisposalMethod { get; set; }

        public decimal? CarbonEmissionKg { get; set; }

        public decimal? DisposalCost { get; set; }

        public string? ComplianceStatus { get; set; }

        public DateTime CollectionDate { get; set; }

        public DateTime? RecordedAt { get; set; }
    }
}
