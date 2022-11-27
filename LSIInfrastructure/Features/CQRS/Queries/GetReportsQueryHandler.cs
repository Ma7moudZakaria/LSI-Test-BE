using LSIDomain.Features.CQRS.Queries;
using LSIDomain.Features.DTO.Queries;
using LSIDomain.Repositories;
using LSIEntities.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LSIInfrastructure.Features.CQRS.Queries;

public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, IEnumerable<ReportDTO>>
{
    private readonly ILogger _logger;
    private readonly IReportRepository _reportRepository;
 
    public GetReportsQueryHandler(ILogger<GetReportsQueryHandler> logger,
                                  IReportRepository reportRepository)
    {
        _logger = logger;
        _reportRepository = reportRepository;
    }
    public async Task<IEnumerable<ReportDTO>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start to fetch from [dbo].[Report]");

        IEnumerable<Report> reports = await _reportRepository.GetReports(request.DateOfReport, request.PremiseName, cancellationToken);

        _logger.LogInformation($"Finished to fetch from [dbo].[Report]");

        _logger.LogInformation($"Start to Map the data of Report");

        IEnumerable<ReportDTO> Mapper()
        {
            foreach (Report report in reports)
            {
                yield return new ReportDTO
                {
                    Id = report.Id,
                    Name = report.Name,
                    DateOfExport = report.DateOfExport,
                    UserName = $"{report.User.FirstName} {report.User.LastName}",
                    PremiseName = report.Premise.Name
                };
            }
        }

        _logger.LogInformation($"Finished to Map the data of Report");

        return Mapper();
    }
}