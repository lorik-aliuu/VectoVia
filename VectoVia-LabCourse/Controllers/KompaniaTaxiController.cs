using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia_LabCourse.Models.Users.Services;
using VectoVia_LabCourse.Views;

namespace VectoVia_LabCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompaniaTaxiController : ControllerBase
    {
        public KompaniaTaxiServices _KompaniaTaxiServices;

        public KompaniaTaxiController(KompaniaTaxiServices KompaniaTaxiServices)
        {
            _KompaniaTaxiServices = KompaniaTaxiServices;
        }

        [HttpPost("add-KompaniaTaxi")]

        public IActionResult AddKompaniaTaxi([FromBody] KompaniaTaxiVM kompaniaTaxi)
        {
            _KompaniaTaxiServices.AddKompaniaTaxi(kompaniaTaxi);
            return Ok();
        }
    }
}