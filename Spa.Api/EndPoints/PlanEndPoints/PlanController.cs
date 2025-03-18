using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nanis.Shared;
using Spa.Application.UseCases.plan;
using Spa.Domain.AgregatesRoot.plan;
using System.Net;

namespace Spa.Api.EndPoints.PlanEndPoints
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly CreatePlanUseCase createPlanUseCase;
        private readonly GetPlansUseCase getPlansUseCase;
        private readonly IMapper mapper;

        public PlanController(IUnitOfWork unitOfWork, IMapper _mapper)
        {
            this.createPlanUseCase = new CreatePlanUseCase(unitOfWork);
            getPlansUseCase = new GetPlansUseCase(unitOfWork);
            mapper = _mapper;
        }

        [HttpPost(Name = "Plan")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<PlanResponse>> Create([FromBody] PlanDto plan)
        {
            var planMaped = mapper.Map<Plan>(plan); 
            var planCreateReponse = await createPlanUseCase.Execute(planMaped);

            if (planCreateReponse <= 0)
            {
                return Ok(new PlanResponse { IsSuccess = false, Message = "Ocurrio un error al crear el plan." }); 
            }

            return  Ok(new PlanResponse { IsSuccess = true, Message = "Plan creado correctamente."});
        }

        [HttpGet(Name = "Plans")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<PlanResponse>> GetPlans()
        { 
            var plans = await getPlansUseCase.Execute();

            if (!plans.Any())
            { 
                return Ok(new PlanResponse 
                {
                    IsSuccess = false,
                    Message = "No se obtuvieron planes."
                });
            }

            var plansDto = mapper.Map<List<PlanDto>>(plans);

            return Ok(new PlanResponse
            {
                IsSuccess = true,
                Message = "Planes obtenidos con exito.",
                Plans = plansDto
            });

        }
    
    }
}
