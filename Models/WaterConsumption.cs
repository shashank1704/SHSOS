using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHSOS.Models
{
    public class WaterConsumption 
    {
        [Key]
        public int ConsumptionID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public Departments? Department { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime ConsumptionDate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "ReadingStart must be non-negative.")]
        public decimal ReadingStart { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "ReadingEnd must be non-negative.")]
        public decimal ReadingEnd { get; set; }

        // persisted value in DB — validation ensures consistency with readings
        [Column(TypeName = "decimal(10, 2)")]
        public decimal UnitsConsumedLiters { get; set; }

        public bool? PeakHourFlag { get; set; }

        public bool? LeakageDetected { get; set; }

        public string? UsageCategory { get; set; }

        public string? WeatherCondition { get; set; }

        public string? Remarks { get; set; }

        public DateTime? RecordedAt { get; set; }

        
    }
}
