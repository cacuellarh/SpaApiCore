using Nanis.Shared;
using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Application.UseCases.agenda
{
    public class GetAgendasByCriteriaUseCase : AgendaBaseUseCase
    {
        public GetAgendasByCriteriaUseCase(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {

        }

        public async Task<List<Agenda>> Execute(ICriteria<Agenda> criteria)
        { 
            var agendas = await agendaRepository.GetAllAsync(criteria);
            return agendas.ToList();
        }
    }
}
