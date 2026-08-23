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

public class Program
{
    string choixstr;
    int choix;
    List<Livre> biblio = new List<Livre>();
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

            if (!int.TryParse(choixstr, out choix))
            {
                Console.WriteLine("Votre choix est invalide.");
                Console.WriteLine("Veuillez saisir votre nouveau choix : ");
                choixstr = Console.ReadLine();
            }

            switch(choix)
            {
                case 1:
                AjouterLivre();
                break;

                case 2:
                AfficherLivres();
                break;

                case 3:
                RechercherLivre();
                break;

                case 4:
                EmprunterLivre();
                break;

                case 5: 
                RetournerLivre();
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

    void AjouterLivre()
    {
        Console.Clear();
        Console.WriteLine("===== Ajouter un livre =====");
        Livre nouveau = new Livre();
        Console.WriteLine("Entrez le titre du livre :");
        nouveau.Titre = Console.ReadLine();
        Console.WriteLine("Entrez l'auteur du livre :");
        nouveau.Auteur = Console.ReadLine();

        for (int i = 0; i < biblio.Count; i++)
        {
            if (nouveau.Titre == biblio[i].Titre && nouveau.Auteur == biblio[i].Auteur)
            {
                Console.WriteLine("Ce livre existe déjà dans la bibliothèque.");
                Console.WriteLine("Entrez le titre du livre :");
                nouveau.Titre = Console.ReadLine();
                Console.WriteLine("Entrez l'auteur du livre :");
                nouveau.Auteur = Console.ReadLine();
            }
        }  

        biblio.Add(nouveau);
        nouveau.EstDisponible = true;
        Console.WriteLine("Le livre suivant : " + nouveau.Titre + " a été ajouté.");          
        Console.ReadKey();  
    }

    void AfficherLivres()
    {
        Console.Clear();
        Console.WriteLine("===== Liste des livres =====");

        for (int j = 0; j < biblio.Count; j++)
        {
            Console.WriteLine("Titre : " +  biblio[j].Titre);
            Console.WriteLine("Auteur : " + biblio[j].Auteur);
            Console.WriteLine("Disponibilité : " + biblio[j].EstDisponible);
        }

        Console.WriteLine("Nombre total de livre : " + biblio.Count);
        Console.ReadKey();
    }

    void RechercherLivre()
    {
        Console.Clear();
        Console.WriteLine("===== Rechercher un livre =====");
        Console.WriteLine("1. Recherche Par Titre ");
        Console.WriteLine("2. Recherche par Auteur");
        Console.WriteLine("\n");
        Console.WriteLine("Votre choix : ");
        choixstr = Console.ReadLine();

        if (!int.TryParse(choixstr, out choix))
        {
            Console.WriteLine("Votre choix est invalide.");
            Console.WriteLine("Veuillez saisir votre nouveau choix : ");
            choixstr = Console.ReadLine();
        }

        switch(choix)
        {
            case 1:
            int compteur = 0;
            bool rechercheT = false;
            Console.WriteLine("Saisissez le titre que vous recherchez :");
            string rechercheTitre = Console.ReadLine();

            for (int k = 0; k < biblio.Count; k++)
            {
                if(rechercheTitre == biblio[k].Titre)
                {
                    Console.WriteLine("Titre : " + biblio[k].Titre);
                    Console.WriteLine("Auteur : " + biblio[k].Auteur);
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

            for (int k = 0; k < biblio.Count; k++)
            {
                if(rechercheAuteur == biblio[k].Auteur)
                {
                    Console.WriteLine("Titre : " + biblio[k].Titre);
                    Console.WriteLine("Auteur : " + biblio[k].Auteur);
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

    void EmprunterLivre()
    {
        Console.Clear();
        bool trouve = true;
        Console.WriteLine("===== Emprunter un livre =====");    
        Console.WriteLine("Saisissez le titre du livre à emprunter :");
        string titreAEmprunter = Console.ReadLine();

        for (int l = 0; l < biblio.Count; l++)
        {
            if (titreAEmprunter == biblio[l].Titre)
            {
                Console.WriteLine("Titre : " + biblio[l].Titre);
                Console.WriteLine("Auteur : " + biblio[l].Auteur);
                biblio[l].EstDisponible = false;
                trouve = false;
                break;
            }        
        }

        if (trouve == false)
        {
            Console.WriteLine("Le livre " + titreAEmprunter + "est emprunté.");
        }
        else
        {
            Console.WriteLine("Livre inexistant.");
        }
        Console.ReadKey();
    }

    void RetournerLivre()
    {
        Console.Clear();
        bool retour = false;
        Console.WriteLine("===== Retourner un livre =====");
        Console.WriteLine("Saisissez le titre du livre à restituer :");
        string titreEmprunte = Console.ReadLine();

        for (int l = 0; l < biblio.Count; l++)
        {
            if (titreEmprunte == biblio[l].Titre)
            {
                Console.WriteLine("Titre : " + biblio[l].Titre);
                Console.WriteLine("Auteur : " + biblio[l].Auteur);
                biblio[l].EstDisponible = true;  
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

    public static void Main(string[] args)
    {
        Program program = new Program();
        program.LancementProgramme();
    }
}