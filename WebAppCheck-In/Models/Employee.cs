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
        [Display(Name = "Número de Empleado")]
        public int EmployeeNumber { get; set; }
        [Display(Name = "Dirección")]
        public string? Address { get; set; }
        [Display(Name ="Número de telefono")]
        public string? PhoneNumber { get; set; }
        [Display(Name ="Correo Electronico")]
        [EmailAddress]
        public string? Email { get; set; }


    }
}
