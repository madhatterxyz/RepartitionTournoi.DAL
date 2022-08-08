using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL.Interfaces;
public interface ITournoiDAL : IRepository<Tournoi>
{
    TournoiDTO Convert(Tournoi joueur);
}
