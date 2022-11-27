using AutoMapper;
using LSIDomain.Features.DTO.Queries;

namespace LSIInfrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ReportDTO, LSIEntities.Entities.Report>();
    }
}