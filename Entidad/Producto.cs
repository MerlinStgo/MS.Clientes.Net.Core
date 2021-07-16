using System;
using System.ComponentModel.DataAnnotations;

namespace MS.Commerce.Entidad
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required(ErrorMessage ="Nombre es obligatorio")]
        [MaxLength(150)]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        [Required(ErrorMessage ="Precio Unitario inválido")]
        public decimal? PrecioUnitario { get; set; }
        [Required(ErrorMessage ="Estado inválido")]
        public bool Estado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVencimiento { get; set; }
    }
}
