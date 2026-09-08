using System.Collections.Generic;
using Npgsql;

namespace Logistique
{   
    public class Program
    {
        public static void Main(string[] args)
        {
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string connectionString = $"Host=localhost;Port=5432;Database=Logistique;Username=postgres;Password={password}";

            ProduitRepository produitRepo = new ProduitRepository(connectionString);
            CommandeRepository commandeRepo = new CommandeRepository(connectionString);
            LigneCommandeRepository ligneRepo = new LigneCommandeRepository(connectionString);

            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n--- MENU LOGISTIQUE ---");
                Console.WriteLine("1. Ajouter un produit");
                Console.WriteLine("2. Créer une commande");
                Console.WriteLine("3. Ajouter une ligne à une commande");
                Console.WriteLine("4. Afficher tous les produits");
                Console.WriteLine("5. Quitter");
                Console.Write("Votre choix : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.Write("Nom du produit : ");
                        string nom = Console.ReadLine();

                        Console.Write("Prix du produit : ");
                        double prix = double.Parse(Console.ReadLine());

                        Console.Write("Quantité en stock : ");
                        int quantite = int.Parse(Console.ReadLine());

                        Produit nouveauProduit = new Produit
                        {
                            Nom = nom,
                            Prix = prix,
                            QuantiteEnStock = quantite
                        };

                        int idNouveauProduit = produitRepo.Inserer(nouveauProduit);
                        Console.WriteLine($"Produit ajouté avec succès ! ID : {idNouveauProduit}");
                        break;

                    case "2":
                        Commande nouvelleCommande = new Commande();
                        int idNouvelleCommande = commandeRepo.Inserer(nouvelleCommande);
                        Console.WriteLine($"Commande créée avec succès ! ID : {idNouvelleCommande}");
                        break;

                    case "3":
                        Console.WriteLine("Produits disponibles :");
                        produitRepo.Lister();

                        Console.Write("ID du produit choisi : ");
                        int idProduitChoisi = int.Parse(Console.ReadLine());

                        Console.WriteLine("Commandes disponibles :");
                        commandeRepo.Lister();

                        Console.Write("ID de la commande choisie : ");
                        int idCommandeChoisie = int.Parse(Console.ReadLine());

                        Console.Write("Quantité commandée : ");
                        int quantiteCommandee = int.Parse(Console.ReadLine());

                        LigneCommande nouvelleLigne = new LigneCommande
                        {
                            QuantiteCommandee = quantiteCommandee
                        };

                        int idNouvelleLigne = ligneRepo.Inserer(nouvelleLigne, idProduitChoisi, idCommandeChoisie);
                        Console.WriteLine($"Ligne de commande ajoutée avec succès ! ID : {idNouvelleLigne}");
                        break;

                    case "4":
                        Console.WriteLine("Liste des produits : ");
                        produitRepo.Lister();
                        break;
                    case "5":
                        continuer = false;
                        Console.WriteLine("Merci, à bientôt !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide, réessaie.");
                        break;
                }
            }
        }
    }
}
