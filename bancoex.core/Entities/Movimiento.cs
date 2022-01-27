using System;
using bancoex.core.Enums;
using bancoex.core.Interfaces;

namespace bancoex.core.Entities
{
	public class Movimiento
	{
		public Movimiento()
		{
		}

        public int Id { get; set; }
        public float Saldo { get; set; }
        public float Importe { get; set; }
        public TipoMov Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCuenta { get; set; }

        public virtual Cuenta Cuenta { get; set; }
    }
}

