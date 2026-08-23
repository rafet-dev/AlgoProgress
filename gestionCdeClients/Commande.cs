namespace GestionCdeClient
{
    public class Commande
    {
        private Client _clients = new Client();
        private List<Produit> listeProduits = new List<Produit>();

        public Client Client { get => _clients; set => _clients = value; }
        public List<Produit> ListeProduits { get => listeProduits; set => listeProduits = value; }

        public void AjouterProduit()
        {
            Console.Clear();
            Console.WriteLine("===== Ajouter un produit =====");
            Console.WriteLine("\n");
            Produit nouveauProduit = new Produit();
            double prixArticle;
            double quantiteArticle;

            Console.WriteLine("Nom de l'article : ");
            string nomArticle = Console.ReadLine();
            Console.WriteLine("Prix du produit : ");
            string prixstr = Console.ReadLine();

            while (!double.TryParse(prixstr , out prixArticle))
            {
                Console.WriteLine("Saisie du prix invalide !");
                Console.WriteLine("Prix du produit : ");
                prixstr = Console.ReadLine();
            }

            nouveauProduit.Prix = prixArticle;

            Console.WriteLine("Quantité souhaitée : ");
            string quantitestr = Console.ReadLine();

            while (!double.TryParse(quantitestr, out quantiteArticle))
            {
                Console.WriteLine("Saisie de la quantité invalide !");
                Console.WriteLine("Quantité souhaitée : ");
                quantitestr = Console.ReadLine();
            }

            nouveauProduit.Quantite = quantiteArticle;

            for (int i = 0; i < listeProduits.Count; i++)
            {
                if (listeProduits[i].NomProduit == nomArticle)
                {
                    Console.WriteLine("Ce produit est déjà présent dans votre panier.");
                    Console.WriteLine("Nom de l'article : ");
                    nomArticle = Console.ReadLine();

                    for (int l = 0; l < listeProduits.Count; l++)
                    {
                        if(listeProduits[i].NomProduit == nomArticle)
                        {
                            Console.WriteLine("Ce produit est déjà présent dans votre panier.");
                            Console.WriteLine("Nom de l'article : ");
                            nomArticle = Console.ReadLine();
                        }
                    } 

                    Console.WriteLine("Prix du produit : ");
                    prixstr = Console.ReadLine();

                while (!double.TryParse(prixstr , out prixArticle))
                {
                    Console.WriteLine("Saisie du prix invalide !");
                    Console.WriteLine("Prix du produit : ");
                    prixstr = Console.ReadLine();
                }

                Console.WriteLine("Quantité souhaitée : ");
                quantitestr = Console.ReadLine();

                while (!double.TryParse(quantitestr, out quantiteArticle))
                {
                    Console.WriteLine("Saisie de la quantité invalide !");
                    Console.WriteLine("Quantité souhaitée : ");
                    quantitestr = Console.ReadLine();
                }

                
                }
            }

            nouveauProduit.NomProduit = nomArticle;
            nouveauProduit.Prix = prixArticle;
            nouveauProduit.Quantite = quantiteArticle;
            ListeProduits.Add(nouveauProduit);
            Console.ReadKey();
        }

        public void AfficherCommande()
        {
            Console.Clear();
            Console.WriteLine("===== Affichage de la commande =====");
            Console.WriteLine("\n");
            Console.WriteLine("Client : " + Client.NomClient + " " + Client.Prenom);
            Console.WriteLine("\n");

            for (int j = 0; j < listeProduits.Count; j++)
            {
                Console.WriteLine("Produit " + (j + 1) + ":");
                Console.WriteLine("Nom : " + listeProduits[j].NomProduit);
                Console.WriteLine("Prix : " + listeProduits[j].Prix);
                Console.WriteLine("Quantité : " + listeProduits[j].Quantite);
                Console.WriteLine("\n");
            }

            Console.WriteLine("Nombre de références choisies : " + listeProduits.Count);
            Console.ReadKey();       
        }

        public void CalculerTotal()
        {
            double total = 0;
            Console.Clear();
            Console.WriteLine("===== Afficher le total du panier =====");
            Console.WriteLine("\n");
            Console.WriteLine("Client : " + Client.NomClient + " " + Client.Prenom);

            for (int k = 0; k < ListeProduits.Count; k++)
            {
                total = total + (ListeProduits[k].Quantite * ListeProduits[k].Prix);
            }
            Console.WriteLine("Total du panier : " + total);
            Console.ReadKey();
        }

    }
}

        
