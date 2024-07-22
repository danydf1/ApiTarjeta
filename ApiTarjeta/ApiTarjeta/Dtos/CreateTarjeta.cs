using System.ComponentModel.DataAnnotations;

namespace ApiTarjeta.Dtos
{
    public class CreateTarjeta
    {
        [Required(ErrorMessage = "Nombre de titular oblgatorio")]
        public string Titular { get; set; }
        [Required(ErrorMessage = "Numero de tarjeta oblgatorio")]
        public string NumeroTarjeta { get; set; }
        [Required(ErrorMessage = "Fecha expiracion oblgatorio")]
        public string FechaExpiracion { get; set; }
        [Required(ErrorMessage = "cvv oblgatorio")]
        public string cvv { get; set; }
    }
}
