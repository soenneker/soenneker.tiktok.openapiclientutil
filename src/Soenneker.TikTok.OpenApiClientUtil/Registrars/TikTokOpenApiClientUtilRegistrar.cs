using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.TikTok.HttpClients.Registrars;
using Soenneker.TikTok.OpenApiClientUtil.Abstract;

namespace Soenneker.TikTok.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class TikTokOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="TikTokOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTikTokOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddTikTokOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ITikTokOpenApiClientUtil, TikTokOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TikTokOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTikTokOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddTikTokOpenApiHttpClientAsSingleton()
                .TryAddScoped<ITikTokOpenApiClientUtil, TikTokOpenApiClientUtil>();

        return services;
    }
}
