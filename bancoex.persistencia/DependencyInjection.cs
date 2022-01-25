using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bancoex.core.Interfaces;
using bancoex.persistencia.Data;
using bancoex.persistencia.Repositories;

namespace bancoex.persistencia
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddDbContext<BanCtx>(options =>
			{
				options.UseSqlite(configuration.GetConnectionString("condb"));
			});
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			return services;
        }
	}
}

