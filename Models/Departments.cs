using System.ComponentModel.DataAnnotations;
namespace SHSOS.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        public int HospitalID { get; set; }
        public required string DepartmentName { get; set; }
        public int FloorNumber { get; set; }
        public int IsActive { get; set; }
    }
}
