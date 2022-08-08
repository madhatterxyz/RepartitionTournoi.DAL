using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL.Interfaces;
public interface ICompositionDAL
{
    Task<Composition> Create(Composition entity);
    Task<List<Composition>> GetAll();
    CompositionDTO Convert(Composition joueur);
}
