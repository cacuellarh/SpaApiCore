using Spa.Domain.AgregatesRoot.agenda;
using Spa.Kernel;

namespace Spa.Api.EndPoints.AgendaEndPoints
{
    public class AgendaResponse : BaseResponse
    {
        public List<AgendaDto> Agendas { get; set; } = new List<AgendaDto>();
        public int TotalCount { get; set; }


    }
}
