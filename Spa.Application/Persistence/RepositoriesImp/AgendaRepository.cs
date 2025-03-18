using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.Repository;

namespace Spa.Application.Persistence.RepositoriesImp
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(DbContext context) : base(context)
        {
        }
    }
}
