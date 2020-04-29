using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;

namespace Smartpark.Api.Controllers
{
    [Route("api/vehiculos")]
    [ApiController]
    public class VehiculoController:ControllerBase
    {
        private IVehiculoService vehiculoService;
        public VehiculoController(IVehiculoService vehiculoService)
        {
            this.vehiculoService = vehiculoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                vehiculoService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            return Ok(
                vehiculoService.Save(vehiculo)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Vehiculo vehiculo)
        {
            return Ok(
                vehiculoService.Update(vehiculo)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                vehiculoService.Delete(id)
            );
        }
        
    }
}