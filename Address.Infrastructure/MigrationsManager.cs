using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Address.Infrastructure
{
	public static class MigrationsManager
	{
		#region Public methods

		/// <summary>
		/// Migrates the database to the latest version
		/// </summary>
		/// <param name="host">The host</param>
		/// <returns>IHost</returns>
		public static async Task<IHost> MigrateDatabase(this IHost host)
		{
			if (host == null)
				throw new ArgumentNullException(nameof(host));

			using (IServiceScope scope = host.Services.CreateScope())
			{
				AddressContext dbContext = scope.ServiceProvider.GetRequiredService<AddressContext>();

				dbContext.Database.Migrate();

				IHostEnvironment env = scope.ServiceProvider.GetService<IHostEnvironment>();

				if (env.IsDevelopment())
					await Seed(dbContext);
			}

			return host;
		}

		#endregion

		#region Private Methods

#pragma warning disable
		private static Task Seed(AddressContext dbContext)
		{
			if(!dbContext.Address.Any())
			{
				dbContext.SaveChanges();
			}

			return Task.CompletedTask;
		}
#pragma warning restore
		#endregion
	}
}
