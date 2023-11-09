using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PersonWEBAPI.Application.Abstraction;
using PersonWEBAPI.Application.Mappings;
using PersonWEBAPI.Application.Services;
using PersonWEBAPI.Domain.Entities;
using System.Reflection;

namespace PersonWEBAPI.Application;

public static class RegisterService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapProfiles));// Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<ITokenService<Person>, TokenService>();

        return services;
    }
}
