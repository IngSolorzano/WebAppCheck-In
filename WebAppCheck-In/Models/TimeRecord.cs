using System.ComponentModel.DataAnnotations;

namespace WebAppCheck_In.Models
{
    public class TimeRecord
    {
        public int Id { get; set; }
        [Display(Name = "Hora de Entrada")]
        public DateTime? CheckInTime { get; set; }

        [Display(Name = "Hora de Salida")]
        public DateTime? CheckOutTime { get; set; }
        [Display(Name = "Numero de empleado")]
        public int? EmployeeId { get; set; }

        [Display(Name ="Numero de Empleado")]
        public Employee? Employees { get; set; }

    }
}
