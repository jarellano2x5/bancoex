using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bancoex.core.DTOs;
using bancoex.core.Services;

namespace bancoex.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _service;

        public CuentaController(ICuentaService service)
        {
            _service = service;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<CuentaDTO>> GetByCliente(int id)
        {
            return await _service.GetAllCuentasAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<CuentaDTO> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<CuentaDTO>> Post([FromBody] CuentaDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _service.CreateAsync(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CuentaDTO>> Put(int id, [FromBody] CuentaDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _service.UpdateAsync(id, value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}