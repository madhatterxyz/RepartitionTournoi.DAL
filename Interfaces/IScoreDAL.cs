using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL.Interfaces;
public interface IScoreDAL
{
    Task<Score> Create(Score entity);
    Task<List<Score>> GetAll();
    ScoreDTO Convert(Score joueur);
}
