namespace Guildes
{
    public class Guilde
    {
        private List<Joueur> _listeJoueurs = new List<Joueur>();
        public List<Joueur> ListeJoueurs { get => _listeJoueurs; set => _listeJoueurs = value; }

        public void CreerJoueur()
        {
            // on crée un joueur à ajouter dans la liste ListeJoueur
            Joueur nouveauJoueur = new Joueur();
        
            Console.Clear();
            Console.WriteLine("===== Créer un joueur =====");
            Console.WriteLine("\n");
            Console.WriteLine("Nom du nouveau joueur : ");
            string nomNouveauJoueur = Console.ReadLine();

            nouveauJoueur.Nom = nomNouveauJoueur;
            nouveauJoueur.Niveau = 0;
                        
            ListeJoueurs.Add(nouveauJoueur);

            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
            Console.ReadKey();
        }

        public void AfficherTousLesJoueurs()
        {
            // on recherche tous les joueurs de la liste ListeJoueur
            Console.Clear();
            Console.WriteLine("===== Affichage de la liste des joueurs =====");
            Console.WriteLine("\n");

            for (int i = 0; i < ListeJoueurs.Count; i++)
            {
                ListeJoueurs[i].AfficherJoueur();
                Console.WriteLine("\n");
            }

            Console.WriteLine("Nombre total de joueur : " + ListeJoueurs.Count);

            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
            Console.ReadKey();
        }

        public Joueur RechercherJoueur(string nom)
        {
            // on recherche un joueur dans la liste suivant son nom
            for (int i = 0; i < ListeJoueurs.Count; i++)
            {
                if(ListeJoueurs[i].Nom == nom)
                {
                    return ListeJoueurs[i];
                }
            }
            return null;
        }
    }
}