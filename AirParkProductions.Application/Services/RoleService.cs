using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AirParkProductions.Application.Base;
using AirParkProductions.Domain.DTO;
using AirParkProductions.Domain.Models;
using AirParkProductions.Domain.Request;
using AirParkProductions.Infrastructure.Repository;
using AirParkProductions.Infrastructure.Specifications;

namespace AirParkProductions.Application.Services
{
    public class RoleService : BaseService<RoleRepository, Role>
    {
        private readonly IMapper _mapper;
        public RoleService(RoleRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public async Task<List<RoleDTO>> PageAllAsync(PageRequest pageRequest)
        {
            return _mapper.Map<List<RoleDTO>>(await PageAllAsync(pageRequest, new RoleSpecifications()
            {
                Includes =
                {
                    item => item.Include(item => item.Utilisateurs),
                }
            }));
        }
    }
}
