using Nanis.Shared;
using Spa.Domain.AgregatesRoot.plan;

namespace Spa.Application.UseCases.plan
{
    public class GetPlansUseCase : PlanBaseUseCase
    {
        public GetPlansUseCase(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task<ICollection<Plan>> Execute()
        {
            return await planRepository.GetAllAsync();
        }
    }
}
