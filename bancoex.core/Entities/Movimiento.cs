using System;
using bancoex.core.Enums;

namespace bancoex.core.Entities
{
	public class Movimiento : IEntity
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

