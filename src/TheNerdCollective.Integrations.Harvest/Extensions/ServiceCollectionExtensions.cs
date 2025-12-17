// Licensed under the Apache License, Version 2.0.
// See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TheNerdCollective.Integrations.Harvest.Extensions;

/// <summary>
/// Extension methods for registering Harvest integration services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Harvest integration services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configuration">The configuration containing Harvest options.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <remarks>
    /// Configure in appsettings.json:
    /// <code>
    /// {
    ///   "Harvest": {
    ///     "ApiToken": "your_api_token",
    ///     "AccountId": "your_account_id",
    ///     "ProjectIds": [123, 456]
    ///   }
    /// }
    /// </code>
    /// </remarks>
    public static IServiceCollection AddHarvestIntegration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<HarvestOptions>(
            configuration.GetSection("Harvest"));

        services.AddHttpClient<HarvestService>();

        return services;
    }
}
