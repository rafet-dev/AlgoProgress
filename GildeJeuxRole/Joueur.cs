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
            // on affiche la fiche Joueur d'un seul joueur

            Console.Clear();
            Console.WriteLine("===== Affichage d'une fiche joueur =====");
            Console.WriteLine("\n");
            Console.WriteLine("===== Fiche du joueur " + Nom + " =====");
            Console.WriteLine();
            Console.WriteLine("Niveau du joueur : " + Niveau);
            Console.WriteLine("Inventaire du joueur : ");
                
            inventaireJoueur.AfficherInventaire();

            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
           
        }

    }
}
