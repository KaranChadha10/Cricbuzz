using CribBuzz.Application.Services.Interfaces;
using CribBuzz.Domain.Repositories.Interfaces;
using CribBuzz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CribBuzz.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
            // Register DbContext
            services.AddDbContext<CribBuzzDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>(); // Register Service


        return services;
    }
}