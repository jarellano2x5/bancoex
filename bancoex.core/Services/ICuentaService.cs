using System.Collections.Generic;
using System.Threading.Tasks;
using bancoex.core.DTOs;

namespace bancoex.core.Services
{
    public interface ICuentaService
    {
        Task<CuentaDTO> CreateAsync(CuentaDTO dto);
		Task<CuentaDTO> GetAsync(int id);
		Task<CuentaDTO> UpdateAsync(int id, CuentaDTO dto);
		Task<bool> DeleteAsync(int id);
		Task<IEnumerable<CuentaDTO>> GetCuentasAsync(int idCliente);
        Task<IEnumerable<CuentaDTO>> GetAllCuentasAsync(int idCliente);
    }
}