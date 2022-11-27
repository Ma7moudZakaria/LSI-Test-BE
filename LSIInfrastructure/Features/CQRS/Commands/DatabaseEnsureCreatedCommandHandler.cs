using LSIDomain.Features.CQRS.Commands;
using LSIDomain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LSIInfrastructure.Features.CQRS.Commands;

public class DatabaseEnsureCreatedCommandHandler : IRequestHandler<DatabaseEnsureCreatedCommand, bool>
{
    private readonly ILogger _logger;
    private readonly IReportRepository _reportRepository;

    public DatabaseEnsureCreatedCommandHandler(ILogger<DatabaseEnsureCreatedCommandHandler> logger,
                                  IReportRepository reportRepository)
    {
        _logger = logger;
        _reportRepository = reportRepository;
    }

    public async Task<bool> Handle(DatabaseEnsureCreatedCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Start to create the database");

        bool databaseEnsureCreated = await _reportRepository.DatabaseEnsureCreated(cancellationToken);

        _logger.LogInformation($"Finished to create the database");

        return databaseEnsureCreated;
    }
}