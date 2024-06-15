using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly IRutum _rutum;

        public RutasController(IRutum rutum)
        {
            _rutum = rutum;
        }

        [HttpGet]
        public async Task<IActionResult> GetCitas()
        {
            var rutas_request = await _rutum.GetRutas();

            if (rutas_request == null)
            {
                return NoContent();
            }

            return Ok(rutas_request);
        }
    }
}
