using Microsoft.AspNetCore.Mvc;
using AirParkProductions.API.Base;
using AirParkProductions.Application.Services;

namespace AirParkProductions.API.Controllers
{
    public class DossierController : BaseController
    {
        private readonly DossierService _dossierService;

        public DossierController(DossierService dossierService)
        {
            _dossierService = dossierService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _dossierService.GetById(id));
        }
    }
}
