using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bancoex.core.DTOs;
using bancoex.core.Services;

namespace bancoex.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<ClienteDTO>> Get()
        {
            return await _service.GetActivoAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ClienteDTO> Get(int id)
        {
            return await _service.GetAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Post([FromBody] ClienteDTO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return await _service.CreateAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ClienteDTO> Put(int id, [FromBody] ClienteDTO value)
        {
            return await _service.UpdateAsync(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}

