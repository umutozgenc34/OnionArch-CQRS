using Core.Application.Pipelines.Validation;
using ECommerce.Application.Features.Categories.Rules;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<CategoryBusinessRules>();
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(con => con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddMediatR(con => {
            con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            con.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        });

        return services;
    }

}
