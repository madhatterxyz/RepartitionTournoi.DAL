using System;
using System.Collections.Generic;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class Jeu
    {
        public Jeu()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;
        public int NbJoueursMin { get; set; }
        public int NbJoueursMax { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
