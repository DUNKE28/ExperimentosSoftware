using Microsoft.AspNetCore.Mvc;
using Smartpark.Domain;
using Smartpark.Service;
namespace Smartpark.Api.Controllers
{
    [Route("api/ingresos")]
    [ApiController]
    public class IngresoController:ControllerBase
    {
        private IIngresoService ingresoService;
        public IngresoController(IIngresoService ingresoService)
        {
            this.ingresoService = ingresoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                ingresoService.GetAll()
            );
        }
        [HttpGet("getById/{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(
                ingresoService.Get(id)
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Ingreso ingreso)
        {
            return Ok(
                ingresoService.Save(ingreso)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Ingreso ingreso)
        {
            return Ok(
                ingresoService.Update(ingreso)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                ingresoService.Delete(id)
            );
        }

        [HttpGet("park/{idPark}")]
        public ActionResult GetByParking(int idPark)
        {
            return Ok(
                ingresoService.GetByParking(idPark)
            );
        }
        [HttpGet("parkView/{idPark}")]
        public ActionResult Getall(int idPark)
        {
            return Ok(
                ingresoService.Getall(idPark)
            );
        }
    }
}