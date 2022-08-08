using Newtonsoft.Json;
using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class JoueurDAL : IJoueurDAL
    {
        private readonly RepartitionTournoiContext _dbContext;
        public JoueurDAL(RepartitionTournoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Joueur> Create(Joueur entity)
        {
            _dbContext.Joueurs.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteById(long id)
        {
            var joueurToDelete = _dbContext.Joueurs.Find(id);
            if (joueurToDelete == null)
            {
                throw new Exception($"Joueur {id} not found.");
            }
            _dbContext.Joueurs.Remove(joueurToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Joueur>> GetAll()
        {
            return _dbContext.Joueurs.ToList();
        }

        public async Task<Joueur?> GetById(long id)
        {
            return _dbContext.Joueurs.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Joueur> Update(Joueur entity)
        {
            var joueurToUpdate = _dbContext.Joueurs.Find(entity.Id);
            if (joueurToUpdate == null)
            {
                throw new Exception($"Joueur {entity.Id} not found.");
            }
            joueurToUpdate.Telephone = entity.Telephone;
            joueurToUpdate.Prénom = entity.Prénom;
            joueurToUpdate.Nom = entity.Nom;
            await _dbContext.SaveChangesAsync();
            return joueurToUpdate;
        }
        public JoueurDTO Convert(Joueur joueur)
        {
            return new JoueurDTO(joueur.Id, joueur.Nom, joueur.Prénom, joueur.Telephone);
        }
    }
}