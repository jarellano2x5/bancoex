using System;
using System.Collections.Generic;
using bancoex.core.Interfaces;

namespace bancoex.core.Entities
{
	public class Cliente : IEntity
	{
		public Cliente()
		{
            Cuentas = new HashSet<Cuenta>();
		}
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}

