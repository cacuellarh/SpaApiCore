using System.ComponentModel.DataAnnotations;

namespace Spa.Domain.AgregatesRoot.agenda
{
    public class AgendaDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "El nombre de cliente es obligatorio.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "El plan es obligatorio.")]
        public string PlanId { get; set; }
        public string? Plan { get;  set; }

        [Required(ErrorMessage = "El contacto del cliente es obligatorio.")]
        public string ClientPhone { get; set; }
        public bool HasDinner { get; set; }

        [Required(ErrorMessage = "El numero de bono es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo BonoNumber debe contener solo números.")]
        public int BonoNumber { get; set; }

        [StringLength(200, ErrorMessage = "El mensaje debe no puede exceder las 200 palabras.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "La fecha de servicio es obligatoria.")]
        public string Date { get; set; }

        [Required(ErrorMessage = "La hora de servicio es obligatoria.")]
        public string Time { get; set; }

        [Required(ErrorMessage = "El saldo de servicio es obligatorio.")]
        [DataType(DataType.Currency, ErrorMessage = "Formato de moneda no válido.")]
        public decimal Balance { get; set; }
    }

}
