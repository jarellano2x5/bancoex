using System;
using System.ComponentModel.DataAnnotations;

namespace bancoex.core.DTOs
{
	public class ClienteDTO
	{
		public ClienteDTO()
		{
		}

		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(60)]
		public string Identificacion { get; set; }
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }
		public bool Activo { get; set; }
	}
}

