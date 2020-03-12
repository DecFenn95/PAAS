using Microsoft.AspNetCore.Mvc;
using PAAS.Models;
using PAAS.Services;

namespace PAAS.Controllers
{
    [Route("/")]
    [ApiController]
    public class PunController : ControllerBase
    {
        private readonly IPunService _service;

        public PunController(IPunService punService)
        {
            _service = punService;
        }

        [HttpGet]
        [Route("Random")]
        public ActionResult<PunResponseModel> Random()
        {
            var pun = _service.GetPun();
            return Ok(pun);
        }
    }
}
