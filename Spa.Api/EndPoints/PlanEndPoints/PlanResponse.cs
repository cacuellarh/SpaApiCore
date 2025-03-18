using Spa.Domain.AgregatesRoot.plan;
using Spa.Kernel;

namespace Spa.Api.EndPoints.PlanEndPoints
{
    public class PlanResponse : BaseResponse
    {
        public List<PlanDto> Plans { get; set; } = new List<PlanDto>();
    }
}
