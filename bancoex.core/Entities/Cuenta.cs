using System;
using System.Collections.Generic;
using bancoex.core.Enums;
using bancoex.core.Interfaces;

namespace bancoex.core.Entities
{
	public class Cuenta : IEntity
	{
		public Cuenta()
		{
            Movimientos = new HashSet<Movimiento>();
		}
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public float Saldo { get; set; }
        public TipoCta Tipo { get; set; }
        public bool Activa { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}

