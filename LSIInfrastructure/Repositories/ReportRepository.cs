using ClosedXML.Excel;
using LSIDomain.Repositories;
using LSIEntities.Entities;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using static System.Net.Mime.MediaTypeNames;

namespace LSIInfrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly LSIDbContext _dbContext;

        public ReportRepository(LSIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DatabaseEnsureCreated(CancellationToken cancellationToken)
        {
            return await _dbContext.Database.EnsureCreatedAsync(cancellationToken);
        }

        public async Task<IEnumerable<Report>> GetReports(DateTime? dateOfReport, string? premiseName, CancellationToken cancellationToken)
        {
            if(dateOfReport is null || string.IsNullOrEmpty(premiseName))
            {
                return await _dbContext.Set<Report>().AsNoTracking().AsSplitQuery().Include(a => a.User).Include(a => a.Premise).ToListAsync(cancellationToken);
            }
            else
            {
                return await _dbContext.Set<Report>()
                                       .AsNoTracking()
                                       .AsSplitQuery()
                                       .Include(a => a.User)
                                       .Include(a => a.Premise)
                                       .Where(a => a.DateOfExport == dateOfReport || a.Premise.Name == premiseName)
                                       .ToListAsync(cancellationToken);
            }
        }

       
    }
}
