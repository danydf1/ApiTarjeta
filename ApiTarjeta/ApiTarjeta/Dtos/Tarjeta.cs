using System.ComponentModel.DataAnnotations;

namespace ApiTarjeta.Dtos
{
    public class Tarjeta
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string NumeroTarjeta { get; set; }
        [Required]
        public string FechaExpiracion { get; set; }
        [Required]
        public string cvv { get; set; }
    }
}
