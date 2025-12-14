using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheNerdCollective.Services.Azure;

namespace TheNerdCollective.Services.Extensions;

/// <summary>
/// Dependency injection extensions for TheNerdCollective.Services
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Azure Blob Storage service to the dependency injection container.
    /// </summary>
    /// <remarks>
    /// Requires configuration section in appsettings.json:
    /// <code>
    /// {
    ///   "AzureBlob": {
    ///     "ConnectionString": "DefaultEndpointsProtocol=...",
    ///     "ContainerName": "my-container"
    ///   }
    /// }
    /// </code>
    /// Usage:
    /// <code>
    /// services.AddAzureBlobServices(configuration);
    /// </code>
    /// </remarks>
    public static IServiceCollection AddAzureBlobServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureBlobOptions>(options =>
        {
            var section = configuration.GetSection(AzureBlobOptions.AppSettingKey);
            options.ConnectionString = section["ConnectionString"] ?? throw new InvalidOperationException("ConnectionString is required");
            options.ContainerName = section["ContainerName"] ?? throw new InvalidOperationException("ContainerName is required");
        });

        services.AddSingleton<AzureBlobService>();

        return services;
    }
}

