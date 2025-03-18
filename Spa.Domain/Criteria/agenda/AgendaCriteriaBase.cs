using Microsoft.EntityFrameworkCore;
using Nanis.Shared.Criteria;
using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.Criteria.agenda
{
    public abstract class AgendaCriteriaBase : Criteria<Agenda>
    {
        protected void AddPaginationWithIncludesByDate(int page)
        {
            int take = 7;
            int skip = (page - 1) * take;
            AddInclude(q => q.Include(a => a.Plan));
            AddPagination(skip, take);
            AddOrderBy(a => a.Time, Nanis.Shared.Types.OrderByType.Ascending);
        }
    }
}
