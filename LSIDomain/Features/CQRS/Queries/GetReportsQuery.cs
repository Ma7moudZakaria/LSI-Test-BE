using LSIDomain.Features.DTO.Queries;
using MediatR;

namespace LSIDomain.Features.CQRS.Queries;

public class GetReportsQuery : IRequest<IEnumerable<ReportDTO>>
{
    public DateTime? DateOfReport { get; set; }
    public string? PremiseName { get; set; }
}