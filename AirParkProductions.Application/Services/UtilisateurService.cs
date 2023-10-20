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
    public class UtilisateurService : BaseService<UtilisateurRepository, Utilisateur>
    {
        private readonly IMapper _mapper;
        public UtilisateurService(UtilisateurRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public Task<object?> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UtilisateurDTO>> PageAllAsync(PageRequest pageRequest)
        {
            List<Utilisateur> utilisateurs = await PageAllAsync(pageRequest, new UtilisateurSpecifications()
            {
                Includes =
                {
                    item => item.Include(item => item.Role),
                    item => item.Include(item => item.Entreprise),
                }
            });
            return _mapper.Map<List<UtilisateurDTO>>(utilisateurs);

        }

        public async Task Update(UtilisateurDTO utilisateurDTO)
        {
            await Update(_mapper.Map<Utilisateur>(utilisateurDTO));
        }

        public async Task<UtilisateurDTO> Create(UtilisateurDTO utilisateurDTO)
        {
            Utilisateur utilisateur = _mapper.Map<Utilisateur>(utilisateurDTO);
            await AddAsync(utilisateur);
            return _mapper.Map<UtilisateurDTO>(utilisateur);
        }
    }
}

