using System.IO.Compression;

namespace GestionCdeClient2
{
    public class GestionnaireCommandes
    {
        private List<Commande> _listeCommandes = new List<Commande>();
        public List<Commande> ListeCommandes { get => _listeCommandes; set => _listeCommandes = value; }

        public void CreerCommande()
        {
            Commande nouvelleCommande = new Commande();
            Client client = new Client();

            Console.Clear();
            Console.WriteLine("===== Créer une commande =====");
            Console.WriteLine("\n");
            Console.WriteLine("Nom de la commande : ");
            nouvelleCommande.NomCommande = Console.ReadLine();

            Console.WriteLine("Attribution de la commande à un client : ");
            client.CreerClient();
            nouvelleCommande.Client = client;

            Console.WriteLine("Création de la commande : ");
            nouvelleCommande.AjouterProduit();
            Console.WriteLine("Voulez-vous ajouter un nouveau produit ? (O/N)");
            string choixAjout = Console.ReadLine();
            choixAjout = choixAjout.ToUpper();

            while (choixAjout == "O")
            {
                nouvelleCommande.AjouterProduit();
                Console.WriteLine("Voulez-vous ajouter un nouveau produit ? (O/N)");
                choixAjout = Console.ReadLine();
                choixAjout = choixAjout.ToUpper();

            }
          
            ListeCommandes.Add(nouvelleCommande);
            Console.WriteLine("Commande " + nouvelleCommande.NomCommande + " terminée.");
            Console.WriteLine("Appuyez sur une touche pour revenir au menu ...");
            Console.ReadKey();

        }
        

        public void AfficherToutesLesCommandes()
        {
            Console.WriteLine("===== Afficher toute les commandes =====");
            Console.WriteLine("\n");
            for (int i = 0; i < ListeCommandes.Count; i++)
            {
                Console.WriteLine("Commande " + (i + 1));
                Console.WriteLine("Nom de la commande : " + ListeCommandes[i].NomCommande);
                ListeCommandes[i].AfficherCommande();
            }

            Console.ReadKey();
        }

        public void CalculerCA()
        {
            Console.Clear();
            Console.WriteLine("===== Calcul du Chiffre d'affaire =====");
            Console.WriteLine("\n");

            double CA = 0;
            for (int k = 0; k < ListeCommandes.Count; k++)
            {
                Console.WriteLine("Total Commande" + (k+1) + " = " + ListeCommandes[k].CalculerTotal());
                CA = CA + ListeCommandes[k].CalculerTotal();
            }

            Console.WriteLine("Chiffre d'Affaire total : " + CA);
            Console.ReadKey();
        }
    }
}