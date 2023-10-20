using Microsoft.AspNetCore.Mvc;
using AirParkProductions.API.Base;
using AirParkProductions.Application.Services;
using AirParkProductions.Domain.DTO;
using AirParkProductions.Domain.Enums;
using AirParkProductions.Domain.Models;
using AirParkProductions.Domain.Request;

namespace AirParkProductions.API.Controllers
{
    public class UtilisateurController : BaseController
    {
        private readonly UtilisateurService _utilisateurService;

        public UtilisateurController(UtilisateurService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            return Ok(await _utilisateurService.PageAllAsync(pageRequest));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _utilisateurService.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUtilisateur([FromBody] UtilisateurDTO utilisateur)
        {
            await _utilisateurService.Update(utilisateur);
            return Ok(AirParkProductionsSuccessEnum.AirParkProductions_200_ENTITY_UPDATE.Format(nameof(Utilisateur), utilisateur.Id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUtilisateur([FromBody] UtilisateurDTO utilisateur)
        {
            return Ok(await _utilisateurService.Create(utilisateur));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _utilisateurService.Delete(id);
            return Ok(AirParkProductionsSuccessEnum.AirParkProductions_204_ENTITY_DELETE.Format(nameof(Utilisateur), id));
        }
    }
}
