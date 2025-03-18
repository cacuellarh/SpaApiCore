using AutoMapper;
using Spa.Application.Converter;
using Spa.Domain.AgregatesRoot.agenda;
using Spa.Domain.AgregatesRoot.plan;

namespace Spa.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Agenda, AgendaDto>()
                .ForMember(dest => dest.Plan, opt => opt.MapFrom(src => src.Plan.Name));


            CreateMap<AgendaDto, Agenda>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.Parse(src.Date)))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => TimeOnly.Parse(src.Time)))
                .ConstructUsing(src => new Agenda(
                    src.ClientName,
                    int.Parse(src.PlanId),
                    src.HasDinner,
                    src.BonoNumber,
                    src.Message,
                    ConvertStringToDateOnly.Convert(src.Date),
                    TimeOnly.Parse(src.Time),
                    src.Balance,
                    src.ClientPhone
                ));

            CreateMap<Plan, PlanDto>();
            CreateMap<PlanDto, Plan>();
        }
    }
}
