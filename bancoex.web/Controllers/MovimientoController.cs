using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bancoex.core.DTOs;
using bancoex.core.Services;

namespace bancoex.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _service;
        
        public MovimientoController(IMovimientoService service)
        {
            _service = service;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<MovimientoDTO>> GetByCuenta(int id)
        {
            return await _service.GetMovAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoDTO>> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<MovimientoDTO>> Post([FromBody] MovimientoDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _service.CreateAsync(value);
        }
    }
}