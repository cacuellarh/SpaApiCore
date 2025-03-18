using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.Criteria.agenda
{
    public class GetAgendasByDateTime : Criteria<Agenda>
    {
        public GetAgendasByDateTime(DateOnly date,TimeOnly time) 
        {
            AddCriteria(a => a.Time == time);
            And(a => a.Date == date);
            AddInclude(q => q.Include(a => a.Plan));
            
        }
    }
}
