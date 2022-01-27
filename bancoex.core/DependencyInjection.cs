using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using bancoex.core.Services;

namespace bancoex.core
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
        {
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddTransient<IClienteService, ClienteService>();
			services.AddTransient<ICuentaService, CuentaService>();
			services.AddTransient<IMovimientoService, MovimientoService>();

			return services;
        }
	}
}

