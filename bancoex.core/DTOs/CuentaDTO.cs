using System;
using bancoex.core.Enums;

namespace bancoex.core.DTOs
{
	public class CuentaDTO
	{
		public CuentaDTO()
		{
		}
		public int Id { get; set; }
		public string NumeroCuenta { get; set; }
		public float Saldo { get; set; }
		public TipoCta Tipo { get; set; }
		public bool Activa { get; set; }
		public int IdCliente { get; set; }
	}
}

