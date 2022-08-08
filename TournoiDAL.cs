using Microsoft.EntityFrameworkCore;
using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class TournoiDAL : ITournoiDAL
    {
        private readonly RepartitionTournoiContext _dbContext;
        public TournoiDAL(RepartitionTournoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Tournoi> Create(Tournoi entity)
        {
            _dbContext.Tournois.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tournoi>> GetAll()
        {
            return await _dbContext.Tournois.ToListAsync();
        }

        public async Task<Tournoi> GetById(long id)
        {
            return await _dbContext.Tournois
                .Include(x => x.Compositions)
                    .ThenInclude(x => x.Match).ThenInclude(x => x.Scores).ThenInclude(x => x.Joueur)
                .Include(x=>x.Compositions)
                    .ThenInclude(x=>x.Jeu).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tournoi> Update(Tournoi entity)
        {
            throw new NotImplementedException();
        }
        public TournoiDTO Convert(Tournoi tournoi)
        {
            TournoiDTO dto = new TournoiDTO(tournoi.Id, tournoi.Nom);
            dto.Compositions = new List<CompositionDTO>();
            foreach (var compo in tournoi.Compositions)
            {
                var compoDTO = new CompositionDTO() { JeuId = compo.JeuId, MatchId = compo.MatchId, TournoiId = compo.TournoiId };
                compoDTO.Jeu = new JeuDTO(compo.Jeu.Id, compo.Jeu.Nom, compo.Jeu.NbJoueursMin, compo.Jeu.NbJoueursMax);
                compoDTO.Match = new MatchDTO() { Id = compo.MatchId, Nom = compo.Match.Nom };
                foreach (var score in compo.Match.Scores)
                {
                    var scoreDTO = new ScoreDTO() { Joueur = new JoueurDTO(score.Joueur.Id, score.Joueur.Nom, score.Joueur.Prénom, score.Joueur.Telephone), Points = score.Points };
                    compoDTO.Match.Scores.Add(scoreDTO);
                }
                dto.Compositions.Add(compoDTO);
            }
            return dto;
        }
    }
}