﻿using RepartitionTournoi.DAL.Entities;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL.Interfaces;
public interface IJeuDAL : IRepository<Jeu>
{
    JeuDTO Convert(Jeu joueur);
}
