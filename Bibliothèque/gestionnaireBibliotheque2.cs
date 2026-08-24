public class Livre
{
    // attributs
    private string _titre;
    private string _auteur;
    private bool _EstDisponible;

    // accesseurs
    public string Titre { get => _titre; set => _titre = value; }
    public string Auteur { get => _auteur; set => _auteur = value; }
    public bool EstDisponible { get => _EstDisponible; set => _EstDisponible = value; }

    public Livre(string titre, string auteur, bool estDisponible)
    {
        this.Titre = titre;
        this.Auteur = auteur;
        this.EstDisponible = estDisponible;
    }
    public Livre()
    {
        // constructeur vide
    }
}

public class Bibliotheque
{
    private List<Livre> _livres = new List<Livre>();
    public List<Livre> Livres { get => _livres; set => _livres = value; }

    public Bibliotheque()
    {
        // constructeur vide
    }
    public void AjouterLivre()
    {
        Console.Clear();
        Console.WriteLine("===== Ajouter un livre =====");
        Livre nouveau = new Livre();
        Console.WriteLine("Entrez le titre du livre :");
        nouveau.Titre = Console.ReadLine();
        Console.WriteLine("Entrez l'auteur du livre :");
        nouveau.Auteur = Console.ReadLine();

        for (int i = 0; i < Livres.Count; i++)
        {
            if (nouveau.Titre == Livres[i].Titre && nouveau.Auteur == Livres[i].Auteur)
            {
                Console.WriteLine("Ce livre existe déjà dans la bibliothèque.");
                Console.WriteLine("Entrez le titre du livre :");
                nouveau.Titre = Console.ReadLine();
                Console.WriteLine("Entrez l'auteur du livre :");
                nouveau.Auteur = Console.ReadLine();
            }
        }  

        Livres.Add(nouveau);
        nouveau.EstDisponible = true;
        Console.WriteLine("Le livre suivant : " + nouveau.Titre + " a été ajouté.");          
        Console.ReadKey();  
    }
    public void AfficherLivres()
    {
        Console.Clear();
        Console.WriteLine("===== Liste des livres =====");

        for (int j = 0; j < Livres.Count; j++)
        {
            Console.WriteLine("Titre : " +  Livres[j].Titre);
            Console.WriteLine("Auteur : " + Livres[j].Auteur);
            Console.WriteLine("Disponibilité : " + Livres[j].EstDisponible);
        }

        Console.WriteLine("Nombre total de livre : " + Livres.Count);
        Console.ReadKey();
    }
    public void RechercherLivre()
    {
        int choix2;
        Console.Clear();
        Console.WriteLine("===== Rechercher un livre =====");
        Console.WriteLine("1. Recherche Par Titre ");
        Console.WriteLine("2. Recherche par Auteur");
        Console.WriteLine("\n");
        Console.WriteLine("Votre choix : ");
        string choixstr2 = Console.ReadLine();

        while (!int.TryParse(choixstr2, out choix2))
        {
            Console.WriteLine("Votre choix est invalide.");
            Console.WriteLine("Veuillez saisir votre nouveau choix : ");
            choixstr2 = Console.ReadLine();
        }

        switch(choix2)
        {
            case 1:
            int compteur = 0;
            bool rechercheT = false;
            Console.WriteLine("Saisissez le titre que vous recherchez :");
            string rechercheTitre = Console.ReadLine();

            for (int k = 0; k < Livres.Count; k++)
            {
                if(rechercheTitre == Livres[k].Titre)
                {
                    Console.WriteLine("Titre : " + Livres[k].Titre);
                    Console.WriteLine("Auteur : " + Livres[k].Auteur);
                    Console.WriteLine("\n");
                    compteur++;
                    rechercheT = true;
                }
            }

            if(rechercheT == true)
            {
                 Console.WriteLine("Nombre de résultats trouvés : " + compteur);   
            }
            else
            {
                Console.WriteLine("Pas de résultat");  
            }
            
            
            Console.ReadKey();
            break;

            case 2:
            bool rechercheA= false;
            int compteur2 = 0;
            Console.WriteLine("Saisissez l'auteur que vous recherchez :");
            string rechercheAuteur = Console.ReadLine();

            for (int k = 0; k < Livres.Count; k++)
            {
                if(rechercheAuteur == Livres[k].Auteur)
                {
                    Console.WriteLine("Titre : " + Livres[k].Titre);
                    Console.WriteLine("Auteur : " + Livres[k].Auteur);
                    Console.WriteLine("\n");
                    compteur2++;
                    rechercheA = true;
                }
            }

            if(rechercheA == true)
            {
                Console.WriteLine("Nombre de résultats trouvés : " + compteur2);   
            }
            else
            {
                Console.WriteLine("Pas de résultat");  
            }

            Console.ReadKey();
            break;

            default:
            Console.WriteLine("Choix Invalide !");
            break;
        }
    }
    public void EmprunterLivre()
    {
        Console.Clear();
        bool trouve = false;
        Console.WriteLine("===== Emprunter un livre =====");    
        Console.WriteLine("Saisissez le titre du livre à emprunter :");
        string titreAEmprunter = Console.ReadLine();

        for (int l = 0; l < Livres.Count; l++)
        {
            if (titreAEmprunter == Livres[l].Titre)
            {
                Console.WriteLine("Titre : " + Livres[l].Titre);
                Console.WriteLine("Auteur : " + Livres[l].Auteur);
                Livres[l].EstDisponible = false;
                trouve = true;
                break;
            }        
        }

        if (trouve == true)
        {
            Console.WriteLine("Le livre " + titreAEmprunter + "est emprunté.");
        }
        else
        {
            Console.WriteLine("Livre inexistant.");
        }
        Console.ReadKey();
}
    public void RetournerLivre()
    {
        Console.Clear();
        bool retour = false;
        Console.WriteLine("===== Retourner un livre =====");
        Console.WriteLine("Saisissez le titre du livre à restituer :");
        string titreEmprunte = Console.ReadLine();

        for (int l = 0; l < Livres.Count; l++)
        {
            if (titreEmprunte == Livres[l].Titre)
            {
                Console.WriteLine("Titre : " + Livres[l].Titre);
                Console.WriteLine("Auteur : " + Livres[l].Auteur);
                Livres[l].EstDisponible = true;  
                retour = true;
                break;
            }
        }
        if (retour == true)
        {
            Console.WriteLine("Le livre " + titreEmprunte + "est restitué.");
        }
        else
        {
            Console.WriteLine("Livre inexistant.");
        }
        Console.ReadKey();
    }
}
public class Program
{
    string choixstr;
    int choix;
    Bibliotheque bibliotheque = new Bibliotheque();
    void MenuBibliotheque()
    {
        Console.Clear();
        Console.WriteLine("===== Gestionnaire de livres =====");
        Console.WriteLine("\n");
        Console.WriteLine("1. Ajouter un livre");
        Console.WriteLine("2. Afficher les livres");
        Console.WriteLine("3. Rechercher un livre");
        Console.WriteLine("4. Emprunter un livre");
        Console.WriteLine("5. Retourner un livre");
        Console.WriteLine("6. Quitter");
        Console.WriteLine("\n");
        
    }    
    void LancementProgramme()
    {
        bool quitter = false;
        while(!quitter)
        {
            MenuBibliotheque();
            Console.WriteLine("Votre choix : ");
            choixstr = Console.ReadLine();

            while(!int.TryParse(choixstr, out choix))
            {
                Console.WriteLine("Votre choix est invalide.");
                Console.WriteLine("Veuillez saisir votre nouveau choix : ");
                choixstr = Console.ReadLine();
            }

            switch(choix)
            {
                case 1:
                bibliotheque.AjouterLivre();
                break;

                case 2:
                bibliotheque.AfficherLivres();
                break;

                case 3:
                bibliotheque.RechercherLivre();
                break;

                case 4:
                bibliotheque.EmprunterLivre();
                break;

                case 5: 
                bibliotheque.RetournerLivre();
                break;

                case 6:
                quitter = true;
                Console.WriteLine("A très vite !");
                Console.ReadKey();
                break;

                default: 
                Console.WriteLine("Choix Invalide !");
                break;
            }
        }   
    }

     public static void Main(string[] args)
    {
        Program program = new Program();
        program.LancementProgramme();
    }
}