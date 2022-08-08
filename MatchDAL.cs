using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;

namespace RepartitionTournoi.DAL
{
    public class MatchDAL : IMatchDAL
    {
        private readonly RepartitionTournoiContext _dbContext;
        public MatchDAL(RepartitionTournoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Match> Create(Match entity)
        {
            _dbContext.Matches.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Match>> GetAll()
        {
            return _dbContext.Matches.ToList();
        }

        public async Task<Match?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Match> Update(Match entity)
        {
            throw new NotImplementedException();
        }
    }
}