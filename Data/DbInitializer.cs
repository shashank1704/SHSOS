using SHSOS.Models;

namespace SHSOS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SHSOSDb context)
        {
            context.Database.EnsureCreated();

            // Look for any hospitals.
            if (context.Hospital.Any())
            {
                return;   // DB has been seeded
            }

            var hospitals = new Hospitals[]
            {
                new Hospitals { HospitalName = "City General Hospital", Location = "Downtown Metro" }
            };
            context.Hospital.AddRange(hospitals);
            context.SaveChanges();

            var departments = new Departments[]
            {
                new Departments { DepartmentName = "Cardiology", HospitalID = hospitals[0].HospitalID, FloorNumber = 1 }, // Removed Wing
                new Departments { DepartmentName = "Neurology", HospitalID = hospitals[0].HospitalID, FloorNumber = 2 }, // Removed Wing
                new Departments { DepartmentName = "Emergency", HospitalID = hospitals[0].HospitalID, FloorNumber = 0 }  // Removed Wing
            };
            context.Department.AddRange(departments);
            context.SaveChanges();

            // Seed Water Consumption
            var waterConsumption = new WaterConsumption[]
            {
                // Removed WaterSource, mapping available: UsageCategory, ReadingStart, ReadingEnd, UnitsConsumedLiters
                new WaterConsumption { DepartmentID = departments[0].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-4), ReadingStart = 1000, ReadingEnd = 1500, UnitsConsumedLiters = 500, UsageCategory = "Sanitation", PeakHourFlag = false },
                new WaterConsumption { DepartmentID = departments[1].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-3), ReadingStart = 1500, ReadingEnd = 1800, UnitsConsumedLiters = 300, UsageCategory = "Drinking", PeakHourFlag = true },
                new WaterConsumption { DepartmentID = departments[2].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-2), ReadingStart = 1800, ReadingEnd = 2400, UnitsConsumedLiters = 600, UsageCategory = "HVAC", PeakHourFlag = false },
                new WaterConsumption { DepartmentID = departments[0].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-1), ReadingStart = 2400, ReadingEnd = 3000, UnitsConsumedLiters = 600, UsageCategory = "Sanitation", PeakHourFlag = true },
                new WaterConsumption { DepartmentID = departments[1].DepartmentID, ConsumptionDate = DateTime.Now.Date, ReadingStart = 3000, ReadingEnd = 3400, UnitsConsumedLiters = 400, UsageCategory = "Drinking", PeakHourFlag = false }
            };
            context.WaterConsumption.AddRange(waterConsumption);

            // Seed Energy Consumption
            var energyConsumption = new EnergyConsumption[]
            {
                // Cost -> TotalCost, EnergyUsed -> UnitsConsumedkWh (redundant assignment removed, kept consistent)
                new EnergyConsumption { DepartmentID = departments[0].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-4), MeterReadingStart = 5000, MeterReadingEnd = 5200, UnitsConsumedkWh = 200, UsageCategory = "Lighting", TotalCost = 30.00m },
                new EnergyConsumption { DepartmentID = departments[1].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-3), MeterReadingStart = 5200, MeterReadingEnd = 5350, UnitsConsumedkWh = 150, UsageCategory = "Equipment", TotalCost = 22.50m },
                new EnergyConsumption { DepartmentID = departments[2].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-2), MeterReadingStart = 5350, MeterReadingEnd = 5600, UnitsConsumedkWh = 250, UsageCategory = "HVAC", TotalCost = 37.50m },
                new EnergyConsumption { DepartmentID = departments[0].DepartmentID, ConsumptionDate = DateTime.Now.Date.AddDays(-1), MeterReadingStart = 5600, MeterReadingEnd = 5800, UnitsConsumedkWh = 200, UsageCategory = "Lighting", TotalCost = 30.00m },
                new EnergyConsumption { DepartmentID = departments[1].DepartmentID, ConsumptionDate = DateTime.Now.Date, MeterReadingStart = 5800, MeterReadingEnd = 5900, UnitsConsumedkWh = 100, UsageCategory = "Equipment", TotalCost = 15.00m }
            };
            context.EnergyConsumption.AddRange(energyConsumption);

            // Seed Waste Management
            var wasteManagement = new WasteManagement[]
            {
                // QuantityAmount -> WasteWeightKg (already set), just removed QuantityAmount
                new WasteManagement { DepartmentID = departments[0].DepartmentID, CollectionDate = DateTime.Now.Date.AddDays(-4), WasteType = "Bio-medical", WasteWeightKg = 10 },
                new WasteManagement { DepartmentID = departments[1].DepartmentID, CollectionDate = DateTime.Now.Date.AddDays(-3), WasteType = "General", WasteWeightKg = 50 },
                new WasteManagement { DepartmentID = departments[2].DepartmentID, CollectionDate = DateTime.Now.Date.AddDays(-2), WasteType = "Recyclable", WasteWeightKg = 30 },
                new WasteManagement { DepartmentID = departments[0].DepartmentID, CollectionDate = DateTime.Now.Date.AddDays(-1), WasteType = "Bio-medical", WasteWeightKg = 15 },
                new WasteManagement { DepartmentID = departments[1].DepartmentID, CollectionDate = DateTime.Now.Date, WasteType = "General", WasteWeightKg = 40 }
            };
            context.WasteManagement.AddRange(wasteManagement);

            context.SaveChanges();
        }
    }
}
