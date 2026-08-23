namespace GestionCdeClient2
{
    public class Program
    {
        Client client = new Client();
        Commande commande = new Commande();
        Produit produit = new Produit();
        GestionnaireCommandes gestionCommandes = new GestionnaireCommandes();
        public void MenuCommandeClient()
        {
            Console.Clear();
            Console.WriteLine("===== Gestionnaire de commandes Clients =====");
            Console.WriteLine("\n");
            Console.WriteLine("1 - Créer une commande ");
            Console.WriteLine("2 - Affichage des commandes clients");
            Console.WriteLine("3 - Afficher le CA");
            Console.WriteLine("4 - Quitter");
            Console.WriteLine("\n");
        }

        public void LancementProgram()
        {
            bool quitter = false;
            string choixStr;
            int choix;
            
            while (!quitter)
            {
                MenuCommandeClient();
                Console.WriteLine("Votre choix : ");
                choixStr = Console.ReadLine();

                while(!int.TryParse(choixStr, out choix))
                {
                    Console.WriteLine("Votre choix est invalide.");
                    Console.WriteLine("Votre choix : ");
                    choixStr = Console.ReadLine();
                }

                switch(choix)
                {
                    case 1:
                        gestionCommandes.CreerCommande();
                        break;

                    case 2:
                        gestionCommandes.AfficherToutesLesCommandes();
                        break;

                    case 3:
                        gestionCommandes.CalculerCA();
                        break;

                    case 4:
                        quitter = true;
                        Console.WriteLine("A bientôt !");
                        break;

                    default:
                        Console.WriteLine("Choix invalide :");
                        break;
                }
            }
        }

        public static void Main(string []args)
        {
            Program program = new Program();
            program.LancementProgram();
        }
    }
   
}