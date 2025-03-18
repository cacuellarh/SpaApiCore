using Nanis.Shared;
using Spa.Domain.AgregatesRoot.plan;

namespace Spa.Application.UseCases.plan
{
    public class CreatePlanUseCase : PlanBaseUseCase
    {
        public CreatePlanUseCase(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task<int> Execute(Plan plan)
        { 
            await planRepository.CreateAsync(plan);
            return await unitOfWork.Commit();
        }
    }
}
