namespace Spa.Domain.Criteria.agenda
{
    public class GetAgendaByMultipleFiltersCriteria : AgendaCriteriaBase
    {
        public GetAgendaByMultipleFiltersCriteria(AgendaMultipleFilterRequest request, int page)
        {
            if (request.Date == null)
            {
                throw new ArgumentNullException(nameof(request.Date), $"La fecha no puede ser null cuando se quiere aplicar multiples filtros.");
            }

            AddCriteria(a => a.Date == request.Date);

            if (!string.IsNullOrEmpty(request.ClientName))
            {
                And(a => a.ClientName == request.ClientName);
            }

            if (!string.IsNullOrEmpty(request.ClientPhone))
            {
                And(a => a.ClientPhone == request.ClientPhone);
            }

            if (request.PlanId != null && request.PlanId != 0)
            { 
                And(a => a.PlanId == request.PlanId);
            }

            if (request.HasDinner != null)
            {
                And(a => a.HasDinner == request.HasDinner);
            }

            if (request.BonoNumber != null)
            {
                And(a => a.BonoNumber == request.BonoNumber);
            }

            if (request.BalanceMin != null && request.BalanceMax != null)
            {
                And(a => a.Balance >= request.BalanceMin && a.Balance <= request.BalanceMax);
            }

            AddPaginationWithIncludesByDate(page);
        }
    }
}
