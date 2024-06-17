using Entities.Models;
using Entities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("filtrar-datos")]
        public ActionResult<FiltradoResponse> FiltrarDatos(int? lugarSalida, int? lugarLlegada, DateTime? fechaInicio, DateTime? fechaFin)
        {
            var resultado = _dashboardService.FiltrarDatos(lugarSalida, lugarLlegada, fechaInicio, fechaFin);
            return Ok(resultado);
        }

        [HttpGet("page-routes")]
        public ActionResult<List<PageRoutesResponse>> ObtenerRutas()
        {
            

            var data = new List<PageRoutesResponse>();
            data.Add(new PageRoutesResponse{id = 1, name = "HomePage", path = "/"});
            data.Add(new PageRoutesResponse { id = 2, name = "DashboardPage", path = "/dashboard"});

            JsonResult Rutas = new JsonResult(data);


            return Ok(data);

        }
    }
}
