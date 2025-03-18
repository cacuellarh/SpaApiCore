using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.Criteria.agenda
{
    public class GetAgendaByIdCriteria : Criteria<Agenda>
    {
        public GetAgendaByIdCriteria(int id)
        {
            AddCriteria(a => a.Id == id);
            AddInclude(q => q.Include(a => a.Plan));
        }
    }
}
