using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL.Interfaces;
public interface IJoueurDAL
{
    IEnumerable<Joueur> All();
    Joueur GetById(int id);
}
