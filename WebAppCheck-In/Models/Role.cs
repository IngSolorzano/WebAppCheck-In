using System.ComponentModel.DataAnnotations;

namespace WebAppCheck_In.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Display(Name ="Tipo de Rol")]
        public string? RolType { get; set; }

        public User? User { get; set; }

       

    }
}
