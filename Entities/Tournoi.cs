using System;
using System.Collections.Generic;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class Tournoi
    {
        public Tournoi()
        {
            Compositions = new HashSet<Composition>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;

        public virtual ICollection<Composition> Compositions { get; set; }
    }
}
