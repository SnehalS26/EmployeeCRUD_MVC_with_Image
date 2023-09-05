using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD_MVC.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }
        [Required]
        public string DName { get; set; }
    }
}
