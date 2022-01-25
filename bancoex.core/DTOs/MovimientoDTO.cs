using System;
using bancoex.core.Enums;

namespace bancoex.core.DTOs
{
	public class MovimientoDTO
	{
		public MovimientoDTO()
		{
		}
		public int Id { get; set; }
		public float Saldo { get; set; }
		public float Importe { get; set; }
		public TipoMov Tipo { get; set; }
		public DateTime Fecha { get; set; }
		public int IdCuenta { get; set; }
	}
}

