using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD_MVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string Imageurl { get; set; }
        [Required]
        [Display(Name = "Dept name")]
        public int Did { get; set; }

        [Display(Name="Dept name")]
        public string DName { get; set; }
    }
}
