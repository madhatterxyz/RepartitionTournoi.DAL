using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL.Interfaces;
public interface IJoueurDAL : IRepository<Joueur>
{
    JoueurDTO Convert(Joueur joueur);
}
