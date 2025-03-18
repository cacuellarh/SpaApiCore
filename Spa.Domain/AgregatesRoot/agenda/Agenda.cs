using Spa.Domain.AgregatesRoot.plan;

namespace Spa.Domain.AgregatesRoot.agenda
{
    public class Agenda
    {
        public Agenda() { }
        public Agenda(string clientName,
            int planId,
            bool hasDinner,
            int bonoNumber,
            string message,
            DateOnly date,
            TimeOnly time,
            decimal balance,
            string clientPhone
            )
        {
            ClientName = clientName;
            PlanId = planId;
            HasDinner = hasDinner;
            BonoNumber = bonoNumber;
            Message = message;
            Date = date;
            Time = time;
            Balance = balance;
            ClientPhone = clientPhone;
        }
        public int Id { get; private set; }
        public string ClientName { get; private set; }
        public string ClientPhone { get; private set; }
        public Plan Plan { get; private set; }
        public int PlanId { get; private set; }
        public bool HasDinner { get; private set; }
        public int BonoNumber { get; private set; }
        public string Message { get; private set; }
        public DateOnly Date { get; private set; }
        public TimeOnly Time { get; private set; }
        public decimal Balance { get; private set; }
    }
}
