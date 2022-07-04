using System.ComponentModel.DataAnnotations;


namespace WebAppCheck_In.Models
{
    public class EmployeeType
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de empleado")]
        public string? Name { get; set; }
        [Display(Name = "Area de empleado")]
        public string? EmployeeArea { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
