﻿using Entities.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("/ObtenerPrecio")]
        public async Task<IActionResult> ObtenerPrecio(int salida, int destino)
        {

            var precioViaje = _viajeServices.ObtenerPrecio(salida, destino);

            if (precioViaje == -1)
            {
                return BadRequest(new { message = "La salida y destino no pueden ser el mismo" });
            }

            if(precioViaje == 0)
            {
                return BadRequest(new { message = "Las rutas seleccionadas no estan disponibles o no existen" });
            }
           

            return Ok(new { precio = precioViaje });
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
                   var viaje =  await _viajeServices.PostViajes(viajeRequest);
                        if (viaje == null)
                        {
                            return BadRequest(new { message = "Ya no quedan campos libres" });
                        }
                    return Ok(new { message = "Viaje añadido"});
                }


         }


        }
}

