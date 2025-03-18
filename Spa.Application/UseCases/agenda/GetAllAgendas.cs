using Nanis.Shared;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Application.UseCases.agenda
{
    public class GetAllAgendas : AgendaBaseUseCase
    {
        public GetAllAgendas(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<IList<Agenda>> Execute()
        {
            var agendas = await agendaRepository.GetAllAsync();
            return agendas.ToList();
        }
    }
}
