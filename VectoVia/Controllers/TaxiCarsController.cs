using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.TaxiCars.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiCarController : ControllerBase
    {
        public TaxiCarServices _taxiServices;
       

        public TaxiCarController(TaxiCarServices tcs)
        {
            _taxiServices = tcs;
        }

        [HttpGet("get-taxi-cars")]
        public IActionResult GetAllTaxiCars()
        {
            var taxiCars = _taxiServices.GetAllTaxiCars() ;
            return Ok(taxiCars);
        }

        [HttpGet("get-taxiCars-ByTargat/{targat}")]
        public IActionResult GetTaxiCarsByTargat(string i)
        {
            var taxiCars = _taxiServices.GetTaxiCarsByTargat(i);
            return Ok(taxiCars);
        }


        [HttpPost("add-taxiCar")]

        public IActionResult AddTaxiCar([FromBody] TaxiCarVM tc)
        {
            _taxiServices.addTaxiCar(tc);
            return Ok();
        }

        [HttpPut("update-taxiCar-by-Targat/{targat}")]
        public IActionResult UpdateTaxiCarByTargat(string  i, [FromBody] TaxiCarVM tc)
        {
            var updatedTaxiCar = _taxiServices.UpdateTaxiCarByTargat(i, tc);
            return Ok(updatedTaxiCar);
        }

        [HttpDelete("delete-taxiCar-by-Targat/{targat}")]
        public IActionResult DeleteTaxiCarByTargat(string i)
        {
            _taxiServices.DeleteTaxiCarsByTargat(i);
            return Ok();
        }
    }
}
