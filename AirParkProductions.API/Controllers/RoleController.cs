using Microsoft.AspNetCore.Mvc;
using AirParkProductions.API.Base;
using AirParkProductions.Application.Services;
using AirParkProductions.Domain.Request;

namespace AirParkProductions.API.Controllers
{
    public class RoleController : BaseController
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            return Ok(await _roleService.PageAllAsync(pageRequest));
        }
    }
}
