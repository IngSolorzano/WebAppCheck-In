using System.ComponentModel.DataAnnotations;


namespace WebAppCheck_In.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre del Producto")]
        public string? Name { get; set; }
        [Display(Name = "Número de Comprobante")]
        public Decimal? NumeroComprobante { get; set; }
        [Display(Name = "Fecha de Compra")]
        public DateTime? Date { get; set; }
        [Display(Name = "Total")]
        public decimal? Total { get; set; }

        public int? EmployeeId { get; set; }
        public int? UserId { get; set; }
    }
}
