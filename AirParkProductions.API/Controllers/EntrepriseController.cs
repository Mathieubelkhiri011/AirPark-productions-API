using Microsoft.AspNetCore.Mvc;
using AirParkProductions.API.Base;
using AirParkProductions.Application.Services;

namespace AirParkProductions.API.Controllers
{
    public class EntrepriseController : BaseController
    {
        private readonly EntrepriseService _entrepriseService;

        public EntrepriseController(EntrepriseService entrepriseService)
        {
            _entrepriseService = entrepriseService;
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _entrepriseService.GetById(id));
        }
    }
}
