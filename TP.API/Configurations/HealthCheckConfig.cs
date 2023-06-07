using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TP.API.Configurations
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration config)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder
                .AddCheck("self", () => HealthCheckResult.Healthy());
            hcBuilder.AddMongoDb(config["MongoSettings:ConnectionString"], name: "Mongo");

            return services;
        }
    }
}
