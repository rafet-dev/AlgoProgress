namespace Guildes
{
    public class Program
    {

        Guilde guilde = new Guilde();
        string nom;
        public void MenuGuilde()
        {
            Console.Clear();
            Console.WriteLine("===== Menu du Jeu de Guilde =====");
            Console.WriteLine("\n");
            Console.WriteLine("1 - Créer un joueur ");
            Console.WriteLine("2 - Ajouter un objet à un joueur ");
            Console.WriteLine("3 - Afficher tous les joueurs");
            Console.WriteLine("4 - Afficher la fiche d'un joueur");
            Console.WriteLine("5 - Afficher l'inventaire d'un joueur ");
            Console.WriteLine("6 - Rechercher un Joueur");
            Console.WriteLine("7 - Quitter");
            Console.WriteLine("\n");
        }

        public void LancementProgram()
        {
            bool quitter = false;
            string choixStr;
            int choix;

            while (!quitter)
            {
                MenuGuilde();
                Console.WriteLine("Votre choix : ");
                choixStr = Console.ReadLine();
                
                while(!int.TryParse(choixStr, out choix) || choix <= 0 || choix > 7)
                {
                    Console.WriteLine("Choix invalide !");
                    Console.WriteLine("Veuillez resaisir votre choix : ");
                    choixStr = Console.ReadLine();
                }

                switch(choix)
                {
                    case 1:
                        guilde.CreerJoueur();
                        break;

                    case 2: 
                        
                        Console.Clear();
                        Console.WriteLine("====== Ajout d'un objet à un joueur =====");
                        Console.WriteLine("A quel joueur voulez-vous ajouter un objet ?");
                        nom = Console.ReadLine();

                        Joueur joueurTrouve = guilde.RechercherJoueur(nom);

                        while (guilde.RechercherJoueur(nom) == null)
                        {
                            Console.WriteLine("Ce joueur n'existe pas !!!");
                            Console.WriteLine("A quel joueur voulez-vous ajouter un objet ?");
                            nom = Console.ReadLine();

                            joueurTrouve = guilde.RechercherJoueur(nom);
                        }

                        joueurTrouve.InventaireJoueur.AjouterObjet();
                        break;

                    case 3: 
                        guilde.AfficherTousLesJoueurs();
                        
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("====== Afficher la fiche d'un joueur =====");
                        Console.WriteLine("Quel joueur voulez-vous afficher ?");
                        nom = Console.ReadLine();

                        joueurTrouve = guilde.RechercherJoueur(nom);

                        while (guilde.RechercherJoueur(nom) == null)
                        {
                            Console.WriteLine("Ce joueur n'existe pas !!!");
                            Console.WriteLine("A quel joueur voulez-vous ajouter un objet ?");
                            nom = Console.ReadLine();

                            joueurTrouve = guilde.RechercherJoueur(nom);
                        }

                        joueurTrouve.AfficherJoueur();
                        break;

                    case 5:
                    Console.Clear();
                        Console.WriteLine("====== Afficher l'inventaire d'un joueur =====");
                        Console.WriteLine("Quel joueur voulez-vous afficher son inventaire ?");
                        nom = Console.ReadLine();

                        joueurTrouve = guilde.RechercherJoueur(nom);

                        while (guilde.RechercherJoueur(nom) == null)
                        {
                            Console.WriteLine("Ce joueur n'existe pas !!!");
                            Console.WriteLine("Quel joueur voulez-vous afficher son inventaire ?");
                            nom = Console.ReadLine();

                            joueurTrouve = guilde.RechercherJoueur(nom);
                        }

                        joueurTrouve.InventaireJoueur.AfficherInventaire();
                        break;

                    case 6:
                        
                        Console.Clear();
                        Console.WriteLine("===== Rechercher un joueur =====");
                        Console.WriteLine("\n");
                        Console.WriteLine("Saisissez le nom que vous recherchez : ");
                        nom = Console.ReadLine();

                        joueurTrouve = guilde.RechercherJoueur(nom);

                        if (joueurTrouve != null)
                        {
                            joueurTrouve.AfficherJoueur();
                        }
                        else
                        {
                            Console.WriteLine("Ce joueur n'existe pas !");
                        }
                        break;

                    case 7: 
                        quitter = true;
                        Console.WriteLine("A bientôt ! ");
                        break;

                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.LancementProgram();
        }
        
    }
}