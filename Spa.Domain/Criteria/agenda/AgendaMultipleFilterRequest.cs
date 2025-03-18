namespace Spa.Domain.Criteria.agenda
{
    public class AgendaMultipleFilterRequest
    {
        public string? ClientName { get; set; }
        public string? ClientPhone { get; set; }
        public int? PlanId { get; set; }
        public bool? HasDinner { get; set; }
        public int? BonoNumber { get; set; }
        public decimal? BalanceMin { get; set; }
        public decimal? BalanceMax { get; set; }
        public DateOnly Date { get; set; }
    }
}
