using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bancoex.core.DTOs;

namespace bancoex.core.Services
{
	public interface IClienteService
	{
		Task<ClienteDTO> CreateAsync(ClienteDTO dto);
		Task<ClienteDTO> GetAsync(int id);
		Task<ClienteDTO> UpdateAsync(int id, ClienteDTO dto);
		Task<bool> Delete(int id);
		Task<IEnumerable<ClienteDTO>> GetActivoAsync();
	}
}

