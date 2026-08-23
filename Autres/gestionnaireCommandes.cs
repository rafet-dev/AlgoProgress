public class Produit
{
    private string _nom;
    private double _prix;
    private double _quantite;

    public string Nom { get => _nom; set => _nom = value; }
    public double Prix { get => _prix; set => _prix = value; }
    public double Quantite { get => _quantite; set => _quantite = value; }

    public Produit()
    {
        // constructeur vide
    }
}
public class Panier
{
    private List<Produit> _produits = new List<Produit>();
    public List<Produit> Produits { get => _produits; set => _produits = value; }

    public void AjouterProduit()
    {
        double prixArticle;
        double quantiteArticle;

        Console.Clear();
        Console.WriteLine("===== 1 - Ajouter un produit =====");
        Produit nouveauProduit = new Produit();
     
        Console.WriteLine("Nom du produit :");
        nouveauProduit.Nom = Console.ReadLine();

        Console.WriteLine("Prix du produit :");
        string prixstr = Console.ReadLine();

        while (!double.TryParse(prixstr, out prixArticle))
        {
            Console.WriteLine("Saisie invalide !");
            Console.WriteLine("Prix du produit :");
            prixstr = Console.ReadLine();
        }
        
        nouveauProduit.Prix = prixArticle;

        Console.WriteLine("Quantité souhaitée :");
        string quantitestr = Console.ReadLine();

        while (!double.TryParse(quantitestr, out quantiteArticle))
        {
            Console.WriteLine("Saisie invalide !");
            Console.WriteLine("Quantité souhaitée :");
            quantitestr = Console.ReadLine();
        }

        nouveauProduit.Quantite = quantiteArticle;

        for (int i = 0; i < Produits.Count; i++)
        {
            if (Produits[i].Nom == nouveauProduit.Nom)
            {
                Console.WriteLine("Ce produit est déjà dans votre panier.");
                Console.WriteLine("Vous allez resaisir les informations du produit souhaité.");
                Console.WriteLine("Nom du produit :");
                nouveauProduit.Nom = Console.ReadLine();

                Console.WriteLine("Prix du produit :");
                prixstr = Console.ReadLine();

                while (!double.TryParse(prixstr, out prixArticle))
                {
                    Console.WriteLine("Saisie invalide !");
                    Console.WriteLine("Prix du produit :");
                    prixstr = Console.ReadLine();
                }
                nouveauProduit.Prix = prixArticle;

                Console.WriteLine("Quantité souhaitée :");
                quantitestr = Console.ReadLine();

                while (!double.TryParse(quantitestr, out quantiteArticle))
                {
                    Console.WriteLine("Saisie invalide !");
                    Console.WriteLine("Quantité souhaitée :");
                    quantitestr = Console.ReadLine();
                }
                nouveauProduit.Quantite = quantiteArticle;

            }
        }

        Produits.Add(nouveauProduit);
        Console.WriteLine("Le produit " + nouveauProduit.Nom + " a été ajouté.");
        Console.ReadKey();
    }

    public void AfficherPanier()
    {
        Console.Clear();
        Console.WriteLine("===== 2 - Afficher le panier =====");
        
        for (int j = 0; j < Produits.Count; j++)
        {
            Console.WriteLine("Produit " + (j+1) + " : ");
            Console.WriteLine("Nom du produit : " + Produits[j].Nom);
            Console.WriteLine("Prix : " + Produits[j].Prix);
            Console.WriteLine("Quantité choisie : " + Produits[j].Quantite);
            Console.WriteLine("\n");
        }

        Console.WriteLine("Nombre de références choisi : " + Produits.Count);
        Console.ReadKey();
    }

    public void AfficherTotal()
    {
        Console.Clear();
        Console.WriteLine("===== 3 - Afficher le total du panier =====");
        double total = 0;

        for (int k = 0; k < Produits.Count; k++)
        {
            total = total + (Produits[k].Quantite * Produits[k].Prix);
        }

        Console.WriteLine("Total du panier : " + total + " EUR");
        Console.ReadKey();
    }
    
}

public class Program
{
    Panier panierCourses = new Panier();
    string choixStr;
    int choix;
    public void MenuCommande()
    {
        Console.Clear();
        Console.WriteLine("===== Gestionnaire de commandes =====");
        Console.WriteLine("\n");
        Console.WriteLine("1 - Ajouter un produit");
        Console.WriteLine("2 - Afficher le Panier");
        Console.WriteLine("3 - Afficher le montant total");
        Console.WriteLine("4 - Quitter");
        Console.WriteLine("\n");
    }

    public void LancementProgram()
    {
        
        bool quitter = false;
        
        while (!quitter)
        {
            MenuCommande();
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
                    panierCourses.AjouterProduit();
                    break;

                case 2:
                    panierCourses.AfficherPanier();
                    break;

                case 3:
                    panierCourses.AfficherTotal();
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

    public static void Main (string[] args)
    {
        Program program = new Program();
        program.LancementProgram();
    }
}