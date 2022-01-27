using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using bancoex.core.Enums;

namespace bancoex.web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoController : ControllerBase
    {
        [HttpGet("[action]")]
        public ActionResult GetCuenta()
        {
            var ls = Enum.GetValues(typeof(TipoCta))
                .Cast<TipoCta>()
                .Select(v => new { id = v, nm = v.ToString() })
                .ToList();

            return Ok(ls);
        }

        [HttpGet("[action]")]
        public ActionResult GetMovimiento()
        {
            var ls = Enum.GetValues(typeof(TipoMov))
            .Cast<TipoMov>().Select(v => new {
                id = v, nm = v.ToString()
            }).ToList();

            return Ok(ls);
        }
    }
}