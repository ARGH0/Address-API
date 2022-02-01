using Address.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Address.Api.Configurations
{
	internal static class ConfigurationServiceCollectionExtensions
	{
		public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
		{
			DatabaseOptions databaseOptions = config.GetSection(nameof(DatabaseOptions)).Get<DatabaseOptions>();

			services.AddDbContext<AddressContext>(
				options => options.UseNpgsql(
					databaseOptions.ConnectionString, sqlOptions =>
					{
						sqlOptions.MigrationsAssembly(typeof(IAddressContext).Assembly.FullName);
						sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
					}));


			return services;
		}

	}
}
