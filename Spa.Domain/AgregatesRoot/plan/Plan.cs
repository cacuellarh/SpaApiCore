using Spa.Domain.AgregatesRoot.agenda;

namespace Spa.Domain.AgregatesRoot.plan
{
    public class Plan
    {
        public Plan()
        {

        }
        public Plan(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; set; }

        public List<Agenda> Agendas { get; }
    }
}
