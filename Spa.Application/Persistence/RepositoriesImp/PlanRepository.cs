using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Spa.Domain.AgregatesRoot.plan;
using Spa.Domain.Repository;

namespace Spa.Application.Persistence.RepositoriesImp
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        public PlanRepository(DbContext context) : base(context)
        {
        }
    }
}
