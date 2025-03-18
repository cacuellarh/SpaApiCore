using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nanis.Shared;
using Spa.Application.Converter;
using Spa.Application.UseCases.agenda;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.Criteria.agenda;
using System.Net;

namespace Spa.Api.EndPoints.AgendaEndPoints
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly CreateAgendaUseCase createAgendaUseCase;
        private readonly GetAllAgendas getAllAgendas;
        private readonly GetAgendasByCriteriaUseCase getAgendasByCriteriaUseCase;
        private readonly CountAgendasByCriteriaUseCase countTotalAgendasUseCase;
        public AgendaController(IMapper _mapper, IUnitOfWork unitOfWork)
        {
            mapper = _mapper;
            createAgendaUseCase = new CreateAgendaUseCase(unitOfWork);
            getAllAgendas = new GetAllAgendas(unitOfWork);
            getAgendasByCriteriaUseCase = new GetAgendasByCriteriaUseCase(unitOfWork);
            countTotalAgendasUseCase = new CountAgendasByCriteriaUseCase(unitOfWork);
        }

        [HttpPost(Name = "Agenda")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<AgendaResponse>> CreateAgenda([FromBody] AgendaDto agendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendaMap = mapper.Map<Agenda>(agendaDto);
            try
            {
                var agenda = mapper.Map<Agenda>(agendaDto); // Intenta mapear
                var result = await createAgendaUseCase.Execute(agendaMap);
                Console.WriteLine(agendaDto.Date);
                if (result < 0)
                {
                    return Ok(new AgendaResponse
                    {
                        IsSuccess = false,
                        Message = "No hubieron columnas afectadas en la creacion de la agenda",
                        RowsAffected = 0
                    });
                }

                return Ok(new AgendaResponse
                {
                    IsSuccess = true,
                    Message = "Agenda creada con exito.",
                    RowsAffected = result
                });
            }
            catch (AutoMapperMappingException ex)
            {
                Console.WriteLine("Error de mapeo: " + ex.InnerException?.Message);
                throw;
            }
           
            
        }

        [HttpGet(Name = "Agendas")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AgendaResponse>> GetAllAgendas()
        {
            var agendas = await getAllAgendas.Execute();
            var agendasToDto = mapper.Map<List<AgendaDto>>(agendas);

            if (agendasToDto.Any())
            {
                var response = new AgendaResponse
                {
                    IsSuccess = true,
                    Message = "Agendas Obtenidas con exito.",
                    Agendas = agendasToDto
                };

                return new JsonResult(response);
            }
            else
            {
                return new JsonResult(new 
                { 
                    IsSuccess = false,
                    Message = "No se encontraron agendas." 
                });
            }
        }

        [HttpPost("Day", Name = "AgendasByDay")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AgendaResponse>> GetAgendasByDay([FromBody] AgendaFilterRequest request)
        {
            var dateOnly = ConvertStringToDateOnly.Convert(request.Day);
            var criteria = new GetAgendasByDateCriteria(dateOnly, request.Page);
            var agendasCountByDay = new GetAgendasCountByDayCriteria(dateOnly);
            var agendas = await getAgendasByCriteriaUseCase.Execute(criteria);
            var agendasMapped = mapper.Map<List<AgendaDto>>(agendas);
            var totalCount = await countTotalAgendasUseCase.Execute(agendasCountByDay);

            if (!agendasMapped.Any())
            {
                return Ok(new AgendaResponse
                {
                    IsSuccess = false,
                    Message = $"No se obtuvieron agendas por el dia seleccionado {request.Day}.",
                    Agendas = agendasMapped,
                    TotalCount = 0
                });
            }

            return Ok(new AgendaResponse
            {
                IsSuccess = true,
                Message = "Agendas filtradas por dia, correctamente.",
                Agendas = agendasMapped,
                TotalCount = totalCount
            });       

        }

    }
}
