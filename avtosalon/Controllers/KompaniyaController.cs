using avtosalon.Repositories;
using avtosalon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.data.DTO;

namespace avtosalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompaniyaController : ControllerBase
    {
        IKompaniyaService kompServ;
        public KompaniyaController(IKompaniyaService kompServ)
        {
            this.kompServ= kompServ;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await kompServ.Get());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AddKompaniyaDTO dTO)
        {
            return Ok(kompServ.Add(dTO));
        }
    }
}
