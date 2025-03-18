using Spa.Application.Converter;
using Spa.Application.UseCases.agenda;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.Criteria.agenda;
using Spa.Domain.Repository;

namespace Spa.Test.AgendaTest
{
    [TestClass]
    public class AgendaCrudTest : StartUpTest
    {
        [TestMethod]
        public async Task GetAll_ValidInput_ShouldPage1Agendas()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();
            var dateParsed = ConvertStringToDateOnly.Convert("2024-11-17");
            var criteria = new GetAgendasByDateCriteria(dateParsed, 1);

            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Any());

        }

        [TestMethod]
        public async Task GetAll_ValidInput_ShouldAgendaByDinner()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();
            var criteria = new AgendaByHasDinnerCriteria(true);

            var agendas = await repository.GetAllAsync(criteria);

            Assert.IsNotNull(agendas);
            Assert.IsTrue(agendas.Any());
        }

        [TestMethod]
        public async Task Count_ValidInput_ShouldTotalAgendas()
        {
            var useCase = new CountAgendasByCriteriaUseCase(unitOfWork);
            var DateParsed = ConvertStringToDateOnly.Convert("2024-11-17");
            var criteria = new GetAgendasCountByDayCriteria(DateParsed);
            var count = await useCase.Execute(criteria);

            Assert.IsNotNull(count);
            Assert.IsTrue(count > 0);
        }
        [TestMethod]
        public async Task Create_ValidInput_ShouldTask1()
        { 
            var repository = unitOfWork.Repository<Agenda,IAgendaRepository>();

            var newAgenda = new Agenda(
                "Camilo Cuellar",
                1,
                false,
                456,
                "sin mensaje",
                new DateOnly(),
                new TimeOnly(),
                34,
                "3134475458"
            );

            await repository.CreateAsync(newAgenda);
            var result = await unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }
        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public async Task Create_InvalidInput_ShouldThrowException()
        {
            var repository = unitOfWork.Repository<Agenda, IAgendaRepository>();
            var newAgenda = new Agenda(
                "Camilo Cuellar",
                1,
                false,
                456,
                "sin mensaje",
                new DateOnly(),
                new TimeOnly(),
                0,
                "3134475458"
                );
            var useCase = new CreateAgendaUseCase(unitOfWork);
            var result = await useCase.Execute(newAgenda);
            Assert.IsNotNull(result);
        }
    }
}
