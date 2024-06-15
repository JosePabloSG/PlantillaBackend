using Entities.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IViaje _viajeServices;

        public ViajeController(IViaje viaje)
        {
            _viajeServices = viaje;
        }


        [HttpGet]
        public async Task<IActionResult> GetViajes()
        {
            var viajes_request = await _viajeServices.GetViajes();

            if (viajes_request == null)
            {
                return NoContent();
            }

            return Ok(viajes_request);
        }



        [HttpPost]
        public async Task<IActionResult> PostViaje(ViajeRequest viajeRequest)
        {

                if (viajeRequest == null)
                {
                    return BadRequest();
                }
                else
                {
                    await _viajeServices.PostViajes(viajeRequest);
                    return Ok(viajeRequest);
                }


            }
        }

    }

