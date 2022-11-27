using LSIDomain.Repositories;
using LSIEntities.Entities;
using LSIInfrastructure.Mapping;
using LSIInfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LSIInfrastructure;

public static class InfrastructureDIContainer
{
    public static IServiceCollection AddInfrastructureDIContainer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IReportRepository, ReportRepository>();

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddMediatR(typeof(IMarkupAssemblyScanning));

        services.AddDbContext<LSIDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("LSITest"));
        });

        return services;
    }
}