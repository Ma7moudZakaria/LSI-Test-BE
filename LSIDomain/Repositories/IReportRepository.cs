using LSIEntities.Entities;

namespace LSIDomain.Repositories;

public interface IReportRepository
{
    Task<bool> DatabaseEnsureCreated(CancellationToken cancellationToken);
    Task<IEnumerable<Report>> GetReports(DateTime? dateOfReport, string? premiseName, CancellationToken cancellationToken);
}