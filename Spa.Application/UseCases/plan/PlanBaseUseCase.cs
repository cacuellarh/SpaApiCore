using Nanis.Shared;
using Spa.Domain.AgregatesRoot.plan;
using Spa.Domain.Repository;

namespace Spa.Application.UseCases.plan
{
    public class PlanBaseUseCase
    {
        protected readonly IPlanRepository planRepository;
        protected readonly IUnitOfWork unitOfWork;
        public PlanBaseUseCase(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            planRepository = unitOfWork.Repository<Plan, IPlanRepository>();
        }
    }
}
