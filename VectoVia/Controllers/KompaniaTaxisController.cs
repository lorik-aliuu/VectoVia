using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaTaxi.Services;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompaniaTaxisController : ControllerBase
    {
        public KompaniaTaxiServices _KompaniaTaxiServices;

        public KompaniaTaxisController(KompaniaTaxiServices KompaniaTaxiServices)
        {
            _KompaniaTaxiServices = KompaniaTaxiServices;
        }

        [HttpGet("get-kompaniteTaxi")]
        public IActionResult GetUsers()
        {
            var users = _KompaniaTaxiServices.GetKompaniteTaxi();
            return Ok(users);
        }

        [HttpGet("get-kompaniteTaxi-id/{id}")]
        public IActionResult GetUsersByID(int id)
        {
            var user = _KompaniaTaxiServices.GetKompaniteTaxiByID(id);
            return Ok(user);
        }

        [HttpPost("add-KompaniaTaxi")]

        public IActionResult AddKompaniaTaxi([FromBody] KompaniaTaxiVM kompaniaTaxi)
        {
            _KompaniaTaxiServices.AddKompaniaTaxi(kompaniaTaxi);
            return Ok();
        }
    }
}