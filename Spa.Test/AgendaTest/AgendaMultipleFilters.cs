using Spa.Application.Converter;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.Criteria.agenda;
using Spa.Domain.Repository;

namespace Spa.Test.AgendaTest
{
    [TestClass]
    public class AgendaMultipleFilters : StartUpTest
    {
        [TestMethod]
        public async Task ByPlanId_ValidInput_ShouldAgendasByFilters()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();

            var filterRequest = new AgendaMultipleFilterRequest
            {
                PlanId = 7,
                Date = ConvertStringToDateOnly.Convert("2024-11-19"),

            };

            var criteria = new GetAgendaByMultipleFiltersCriteria(filterRequest, 1);
            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Count > 0);
        }

        [TestMethod]
        public async Task ByPlanIdAndClientName_ValidInput_ShouldAgendasByFilters()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();

            var filterRequest = new AgendaMultipleFilterRequest
            {
                PlanId = 7,
                Date = ConvertStringToDateOnly.Convert("2024-11-19"),
                ClientName = "Sánchez José"

            };

            var criteria = new GetAgendaByMultipleFiltersCriteria(filterRequest, 1);
            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Count > 0);
        }

        [TestMethod]
        public async Task ByPlanIdAndClientNameAndBonoNumber_ValidInput_ShouldAgendasByFilters()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();

            var filterRequest = new AgendaMultipleFilterRequest
            {
                PlanId = 2,
                Date = ConvertStringToDateOnly.Convert("2024-11-19"),
                ClientName = "Álvarez Carlos",
                BonoNumber = 165

            };

            var criteria = new GetAgendaByMultipleFiltersCriteria(filterRequest, 1);
            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Count > 0);
        }

        [TestMethod]
        public async Task ByClientPhoneAndHasDinner_ValidInput_ShouldAgendasByFilters()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();

            var filterRequest = new AgendaMultipleFilterRequest
            {
                Date = ConvertStringToDateOnly.Convert("2024-11-17"),
                HasDinner = true,
                ClientPhone = "3356787890"
            };

            var criteria = new GetAgendaByMultipleFiltersCriteria(filterRequest, 1);
            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Count > 0);
        }

        [TestMethod]
        public async Task ByAllFilters_ValidInput_ShouldAgendasByFilters()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();

            var filterRequest = new AgendaMultipleFilterRequest
            {
                Date = ConvertStringToDateOnly.Convert("2024-11-17"),
                HasDinner = false,
                ClientPhone = "3356787890",
                PlanId = 9
            };

            var criteria = new GetAgendaByMultipleFiltersCriteria(filterRequest, 1);
            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Count > 0);
        }

        [TestMethod]
        public async Task ByBalanaceRange_ValidInput_ShouldAgendasByFilters()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();

            var filterRequest = new AgendaMultipleFilterRequest
            {
                Date = ConvertStringToDateOnly.Convert("2024-11-17"),
                BalanceMin = 200m,
                BalanceMax = 250m,
            };

            var criteria = new GetAgendaByMultipleFiltersCriteria(filterRequest, 1);
            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Count > 0);
        }
    }
}
