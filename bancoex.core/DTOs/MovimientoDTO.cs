using System;
using System.ComponentModel.DataAnnotations;
using bancoex.core.Enums;

namespace bancoex.core.DTOs
{
	public class MovimientoDTO
	{
		public MovimientoDTO()
		{
		}
		[Required]
		public int Id { get; set; }
		public float Saldo { get; set; }
		[Required]
		public float Importe { get; set; }
		[Required]
		public TipoMov Tipo { get; set; }
		public DateTime? Fecha { get; set; }
		[Required]
		public int IdCuenta { get; set; }
	}
}

