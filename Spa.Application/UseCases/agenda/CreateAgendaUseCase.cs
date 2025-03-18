using Nanis.Shared;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.Criteria.agenda;

namespace Spa.Application.UseCases.agenda
{
    public class CreateAgendaUseCase : AgendaBaseUseCase
    {
        public CreateAgendaUseCase(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<int> Execute(Agenda agenda)
        {
            var agendas = await agendaRepository.GetAllAsync(new GetAgendasByDateTime(agenda.Date, agenda.Time));

            if(agendas.Count >= 2)
            {
                throw new InvalidOperationException($"Para la fecha {agenda.Date} se han agendado todos los cupos disponibles");
            }
            await agendaRepository.CreateAsync(agenda);
            return await unitOfWork.Commit();
        }
    }
}
