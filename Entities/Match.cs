﻿using System;
using System.Collections.Generic;

namespace RepartitionTournoi.DAL.Entities
{
    public partial class Match
    {
        public Match()
        {
            Compositions = new HashSet<Composition>();
            Scores = new HashSet<Score>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;

        public virtual ICollection<Composition> Compositions { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
