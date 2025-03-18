using Nanis.Shared;
using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;


namespace Spa.Application.UseCases.agenda
{
    public class CountAgendasByCriteriaUseCase : AgendaBaseUseCase
    {
        public CountAgendasByCriteriaUseCase(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task<int> Execute(ICriteria<Agenda> criteria) 
        {
            return await agendaRepository.CountAsync(criteria);
        }
    }
}
