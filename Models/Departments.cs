namespace SHSOS.Models
{
    public class Departments
    {
        int DepartmentID { get; set; }
        int HospitalID { get; set; }
        string DepartmentName { get; set; }
        int FloorNumber { get; set; }
        int IsActive { get; set; }
    }
}
