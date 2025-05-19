using Application.Abstractions.Behaviors;
using Application.Abstractions.Messaging;
using Application.Todos.Complete;
using Application.Todos.Delete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddScoped<ICommandHandler<CompleteTodoCommand>, CompleteTodoCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteTodoCommand>, DeleteTodoCommandHandler>();

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        return services;
    }
}
