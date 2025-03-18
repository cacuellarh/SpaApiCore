using Nanis.Shared;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.Repository;

namespace Spa.Application.UseCases.agenda
{
    public abstract class AgendaBaseUseCase
    {
        protected readonly IAgendaRepository agendaRepository;
        protected readonly IUnitOfWork unitOfWork;
        public AgendaBaseUseCase(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            agendaRepository = unitOfWork.Repository<Agenda, IAgendaRepository>();
        }
    }
}
