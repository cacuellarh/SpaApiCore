using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.Criteria.agenda
{
    public class GetAgendasByDateCriteria : Criteria<Agenda>
    {
        public GetAgendasByDateCriteria(DateOnly currentDate, int page)
        {
            int take = 7;
            int skip = (page - 1) * take;
            AddCriteria(a => a.Date == currentDate);
            AddInclude(q => q.Include(a => a.Plan));
            AddPagination(skip, take);
            AddOrderBy(a => a.Time, Nanis.Shared.Types.OrderByType.Ascending);
        }
    }
}
