using System.ComponentModel.DataAnnotations;

namespace WebAppCheck_In.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Direccion")]
        public string? Address { get; set; }
        [Display(Name = "Número de teléfono")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Display(Name = "Nombre de Usuario")]
        [Required]
        public string? UserName { get; set; }
        [Display(Name = "Contrasenia")]
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoleId { get; set; }

        public Employee? Employees { get; set; }
        public Role? Roles { get; set; }


    }
}
