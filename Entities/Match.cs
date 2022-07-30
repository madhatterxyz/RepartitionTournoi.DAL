using System;
using System.Collections.Generic;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class Match
    {
        public Match()
        {
            Scores = new HashSet<Score>();
        }

        public long Id { get; set; }
        public long JeuId { get; set; }

        public virtual Jeu Jeu { get; set; } = null!;
        public virtual ICollection<Score> Scores { get; set; }
    }
}
