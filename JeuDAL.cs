using Microsoft.EntityFrameworkCore;
using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class JeuDAL : IJeuDAL
    {
        private readonly RepartitionTournoiContext _dbContext;
        public JeuDAL(RepartitionTournoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Jeu> Create(Jeu entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Jeu>> GetAll()
        {
            return await _dbContext.Jeus.ToListAsync();
        }

        public async Task<Jeu> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Jeu> Update(Jeu entity)
        {
            throw new NotImplementedException();
        }
        public JeuDTO Convert(Jeu jeu)
        {
            return new JeuDTO(jeu.Id, jeu.Nom, jeu.NbJoueursMin, jeu.NbJoueursMax);
        }
    }
}