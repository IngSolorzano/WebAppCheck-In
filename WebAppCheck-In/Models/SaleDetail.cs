using System.ComponentModel.DataAnnotations;


namespace WebAppCheck_In.Models
{
    public class SaleDetail
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Precio")]
        public Decimal? Price { get; set; }
        [Display(Name = "Cantidad de Piezas")]
        public int? Amout { get; set; }


        public int? SaleId { get; set; }

    }
}
