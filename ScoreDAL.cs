using Microsoft.EntityFrameworkCore;
using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class ScoreDAL : IScoreDAL
    {
        private readonly RepartitionTournoiContext _dbContext;
        public ScoreDAL(RepartitionTournoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Score> Create(Score entity)
        {
            _dbContext.Scores.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Score>> GetAll()
        {
            return await _dbContext.Scores.ToListAsync();
        }

        public ScoreDTO Convert(Score Score)
        {
            return new ScoreDTO { Joueur = new JoueurDTO(Score.Joueur.Id,Score.Joueur.Nom,Score.Joueur.Prénom,Score.Joueur.Telephone), Points = Score.Points };
        }
    }
}