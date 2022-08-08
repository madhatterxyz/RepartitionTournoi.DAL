using System;
using System.Collections.Generic;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class Mecanique
    {
        public Mecanique()
        {
            Jeus = new HashSet<Jeu>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;

        public virtual ICollection<Jeu> Jeus { get; set; }
    }
}
