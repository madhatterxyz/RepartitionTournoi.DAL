using Microsoft.EntityFrameworkCore;
using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class CompositionDAL : ICompositionDAL
    {
        private readonly RepartitionTournoiContext _dbContext;
        public CompositionDAL(RepartitionTournoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Composition> Create(Composition entity)
        {
            _dbContext.Compositions.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Composition>> GetAll()
        {
            return await _dbContext.Compositions.ToListAsync();
        }

        public CompositionDTO Convert(Composition Composition)
        {
            return new CompositionDTO { JeuId = Composition.JeuId, MatchId = Composition.MatchId, TournoiId = Composition.TournoiId};
        }
    }
}