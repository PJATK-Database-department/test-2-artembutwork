using Microsoft.AspNetCore.Mvc;
using Test2.Models;
using Test2.Service;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private readonly IDbService _service;

        public InspectionController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetInspections()
        {
            try
            {
                return _service.GetInspections();
            }
            catch (Exception e) 
            { 
                return BadRequest(e); 
            }
        }

        [HttpPut]
        public IActionResult UpdateCar(Car car)
        {

            return Ok(car);
            try
            {
                return _service.UpdateCar(car);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
