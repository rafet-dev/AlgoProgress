namespace GestionCdeClient
{
    public class Program
    {
        Commande nouvelleCommande = new Commande();
        Client client = new Client();
        public void MenuCommandeClient()
        {
            Console.Clear();
            Console.WriteLine("===== Gestionnaire de commandes Clients =====");
            Console.WriteLine("\n");
            Console.WriteLine("1 - Créer un client");
            Console.WriteLine("2 - Ajouter un produit à une commande Client");
            Console.WriteLine("3 - Affichage des commandes clients");
            Console.WriteLine("4 - Afficher le total d'une commande");
            Console.WriteLine("5 - Quitter");
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
                        client.CreerClient();
                        nouvelleCommande.Client = client;
                        break;

                    case 2:
                        nouvelleCommande.AjouterProduit();
                        break;

                    case 3:
                        nouvelleCommande.AfficherCommande();
                        break;

                    case 4:
                        nouvelleCommande.CalculerTotal();
                        break;

                    case 5:
                        quitter = true;
                        Console.WriteLine("A bientôt !");
                        break;

                    default:
                        Console.WriteLine("Choix invalide :");
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
