using System.ComponentModel.DataAnnotations;
namespace SHSOS.Models
{
    public class Hospitals
    {
        [Key]
        public int HospitalID { get; set; }
        public required string HospitalName { get; set; }
        public required string Location { get; set; }
    }
}
