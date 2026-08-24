namespace Guildes
{
    public class Joueur
    {
        private string _nom;
        private int _niveau;
        Inventaire inventaireJoueur = new Inventaire();

        public string Nom { get => _nom; set => _nom = value; }
        public int Niveau { get => _niveau; set => _niveau = value; }
        public Inventaire InventaireJoueur { get => inventaireJoueur; set => inventaireJoueur = value; }

        public void AfficherJoueur()
        {
            
        }
    }
}