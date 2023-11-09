using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonWEBAPI.Application.Abstraction;
using PersonWEBAPI.Application.Repositories;
using PersonWEBAPI.Infrastructure.DataAccess;
using PersonWEBAPI.Infrastructure.Services;

namespace PersonWEBAPI.Infrastructure;

public static class RegisterService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddDbContext<IDataDbContext, DataDBContext>(x => x.UseNpgsql(configuration.GetConnectionString("DbContext")));
        
        return services;
    }
}
