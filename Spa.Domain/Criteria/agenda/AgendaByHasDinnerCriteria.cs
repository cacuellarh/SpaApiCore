using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.Criteria.agenda
{
    public class AgendaByHasDinnerCriteria : Criteria<Agenda>
    {
        public AgendaByHasDinnerCriteria(bool hasDinner) 
        {
            AddCriteria(a => a.HasDinner == hasDinner);
        }
    }
}
