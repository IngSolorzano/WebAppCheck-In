using System.ComponentModel.DataAnnotations;

namespace WebAppCheck_In.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
        [Display(Name = "Apellido")]
        public string? LastName { get; set; }
        [Display(Name = "Numero de Empleado")]
        public int EmployeeNumber { get; set; }

    }
}
