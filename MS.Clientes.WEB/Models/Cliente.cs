using System.ComponentModel.DataAnnotations;


namespace MS.Clientes.WEB.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [MaxLength(80)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Apellidos es Obligatorio")]
        [MaxLength(80)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Dirección es Obligatorio")]
        [MaxLength(150)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Teléfono es Obligatorio")]
        [MaxLength(30)]
        public string Telefono { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
