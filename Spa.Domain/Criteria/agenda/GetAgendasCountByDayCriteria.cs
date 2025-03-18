using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.Criteria.agenda
{
    public class GetAgendasCountByDayCriteria : Criteria<Agenda>
    {
        public GetAgendasCountByDayCriteria(DateOnly date) 
        {
            AddCriteria(a => a.Date == date);
        }
    }
}
