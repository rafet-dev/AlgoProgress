using System.ComponentModel.DataAnnotations.Schema;

namespace Guildes
{
    public class Inventaire
    {
        private List<ObjetJeu> _listeObjets = new List<ObjetJeu>();
        public List<ObjetJeu> ListeObjets { get => _listeObjets; set => _listeObjets = value; }

        public void AjouterObjet()
        {
            // on crée un objet à ajouter dans la liste d'objet ListeObjets
            ObjetJeu nouvelObjet = new ObjetJeu();
            string nouvelleValeurStr;
            string nouveauPoidsStr;
            double nouvelleValeur;
            double nouveauPoids;

            Console.Clear();
            Console.WriteLine("===== Ajouter un nouvel objet =====");
            Console.WriteLine("\n");
            Console.WriteLine("Nouveau nom de l'objet : ");
            nouvelObjet.NomObjet = Console.ReadLine();
            
            Console.WriteLine("Valeur du nouvel objet : ");
            nouvelleValeurStr = Console.ReadLine();

            while (!double.TryParse(nouvelleValeurStr, out nouvelleValeur))
            {
                Console.WriteLine("Votre saisie est invalide !");
                Console.WriteLine("Valeur du nouvel objet : ");
                nouvelleValeurStr = Console.ReadLine();
            }

            Console.WriteLine("Poids du nouvel Objet : ");
            nouveauPoidsStr = Console.ReadLine();

            while (!double.TryParse(nouveauPoidsStr, out nouveauPoids))
            {
                Console.WriteLine("Votre saisie est invalide !");
                Console.WriteLine("Poids du nouvel objet : ");
                nouveauPoidsStr = Console.ReadLine();
            }

            nouvelObjet.Valeur = nouvelleValeur;
            nouvelObjet.Poids = nouveauPoids;
            ListeObjets.Add(nouvelObjet);

            Console.WriteLine("L'objet " + nouvelObjet.NomObjet + "a été crée.");
            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
            Console.ReadKey();
        }

        public void AfficherInventaire()
        {
            Joueur joueurAInventorier;
            Guilde guilde;
            // on affiche l'inventaire d'un seul joueur
            Console.Clear();
            Console.WriteLine("===== Affichage de l'inventaire Joueur =====");
            Console.WriteLine("\n");
            Console.WriteLine("Saisissez le nom du joueur :");
            string Nom = Console.ReadLine();

            joueurAInventorier = guilde.RechercherJoueur(Nom);

            if (joueurAInventorier != null)
            {
                Console.WriteLine("Inventaire du joueur " + joueurAInventorier.Nom);  
                Console.WriteLine("\n");
                for (int i = 0; i < ListeObjets.Count; i++)
                {
                    Console.WriteLine("Objet " + (i + 1) + " :");
                    Console.WriteLine("Nom de l'objet : " + ListeObjets[i].NomObjet);
                    Console.WriteLine("Valeur de l'objet : " + ListeObjets[i].Valeur);
                    Console.WriteLine("Poids de l'objet : " + ListeObjets[i].Poids);
                    Console.WriteLine("\n"); 
                }
            }
            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
            Console.ReadKey();
        }

        public void CalculerValeurTotale()
        {
            double valeurTotale = 0;
            Guilde guilde;
            Joueur ValeurTotale;

            // on calcule la valeur totale de l'inventaire d'un seul joueur

            Console.Clear();
            Console.WriteLine("===== Valeur totale d'un inventaire joueur =====");
            Console.WriteLine("\n");

            Console.WriteLine("Saisissez le nom du joueur :");
            string NomValeur = Console.ReadLine();

            ValeurTotale = guilde.RechercherJoueur(NomValeur);

            if (ValeurTotale != null)
            {
                Console.WriteLine("Inventaire du joueur " + NomValeur);

                    for (int j = 0; j < ListeObjets.Count; j++)
                    {
                        valeurTotale = valeurTotale + ListeObjets[j].Valeur;
                    }
            }

            Console.WriteLine("Valeur totale de l'inventaire du joueur : " + valeurTotale);
            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
            Console.ReadKey();
        }
    }
}