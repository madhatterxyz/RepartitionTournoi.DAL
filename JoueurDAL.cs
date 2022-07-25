using Newtonsoft.Json;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class JoueurDAL : IJoueurDAL
    {
        private readonly List<Joueur> _joueurs;
        public JoueurDAL()
        {
            string fileJoueurs = File.ReadAllText("joueurs.json");
            _joueurs = JsonConvert.DeserializeObject<List<Joueur>>(fileJoueurs);
        }
        public IEnumerable<Joueur> All()
        {
            return _joueurs;
        }
        public Joueur GetById(int id)
        {
            return _joueurs.FirstOrDefault(x => x.Id == id);
        }

    }
}