using Nanis.Shared;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Application.UseCases.agenda
{
    public class UpdateAgendaUseCase : AgendaBaseUseCase
    {
        public UpdateAgendaUseCase(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task<int> Execute(Agenda agenda)
        {
            if (agenda.Id == null)
            { 
                throw new ArgumentNullException(nameof(agenda.Id), "El id de la agenda a actualizar no puede ser null");  
            }

            await agendaRepository.UpdateAsync(agenda);
            return await unitOfWork.Commit();
        }
    }
}
