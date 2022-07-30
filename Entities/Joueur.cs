using System;
using System.Collections.Generic;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class Joueur
    {
        public Joueur()
        {
            Scores = new HashSet<Score>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Prénom { get; set; } = null!;
        public string Telephone { get; set; } = null!;

        public virtual ICollection<Score> Scores { get; set; }
    }
}
