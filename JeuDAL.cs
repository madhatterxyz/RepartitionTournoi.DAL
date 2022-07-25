using Newtonsoft.Json;
using RepartitionTournoi.DAL.Interfaces;
using RepartitionTournoi.Models;

namespace RepartitionTournoi.DAL
{
    public class JeuDAL : IJeuDAL
    {
        private readonly List<Jeu> _jeux;
        public JeuDAL()
        {

            string fileJoueurs = File.ReadAllText("jeux.json");
            _jeux = JsonConvert.DeserializeObject<List<Jeu>>(fileJoueurs);
        }
        public List<Jeu> All()
        {
            return _jeux;


        }
    }
}