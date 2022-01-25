using System;
using AutoMapper;
using bancoex.core.DTOs;
using bancoex.core.Entities;

namespace bancoex.core.Mapper
{
	public class AutoMapper : Profile
	{
		public AutoMapper()
		{
			CreateMap<Cliente, ClienteDTO>();
			CreateMap<ClienteDTO, Cliente>();
			CreateMap<Cuenta, CuentaDTO>();
			CreateMap<CuentaDTO, Cuenta>();
			CreateMap<Movimiento, MovimientoDTO>();
			CreateMap<MovimientoDTO, Movimiento>();
		}
	}
}

