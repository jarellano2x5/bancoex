using System;
using System.ComponentModel.DataAnnotations;
using bancoex.core.Enums;

namespace bancoex.core.DTOs
{
	public class CuentaDTO
	{
		public CuentaDTO()
		{
		}
		public int Id { get; set; }
		[Required]
		[StringLength(18)]
		public string NumeroCuenta { get; set; }
		[Required]
		public float Saldo { get; set; }
		[Required]
		public TipoCta Tipo { get; set; }
		public bool Activa { get; set; }
		[Required]
		public int IdCliente { get; set; }
	}
}

