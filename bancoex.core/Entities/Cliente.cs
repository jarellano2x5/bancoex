using System;
using System.Collections.Generic;

namespace bancoex.core.Entities
{
	public class Cliente
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

