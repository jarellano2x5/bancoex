using System.Collections.Generic;
using System.Threading.Tasks;
using bancoex.core.DTOs;

namespace bancoex.core.Services
{
    public interface IMovimientoService
    {
        Task<MovimientoDTO> CreateAsync(MovimientoDTO dto);
		Task<MovimientoDTO> GetAsync(int id);
		Task<IEnumerable<MovimientoDTO>> GetMovAsync(int idCuenta);
    }
}