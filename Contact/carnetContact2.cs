using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

public class Contact
{
    //attributs
    private string _nom;
    private string _telephone;
    private string _email;

    // accesseurs
    public string Nom { get => _nom; set => _nom = value; }
    public string Telephone { get => _telephone; set => _telephone = value; }
    public string Email { get => _email; set => _email = value; }

    // constructeur
    public Contact(string nom, string telephone, string email)
        {
            this.Nom = nom;
            this.Telephone = telephone;
            this.Email = email;
        }   

    public Contact()
    {
        // constructeur vide
    } 
}

public class Program

{
    int choix;
    string choixStr;
    string Nom;
    List <Contact> ListeContacts  = new List<Contact>();
    
    // menu principal
    void MenuContact()
    {
        Console.WriteLine ("===== Carnet de Contact =====");
        Console.WriteLine("\n");
        Console.WriteLine("1 - Ajouter un Contact");
        Console.WriteLine("2 - Afficher les contacts");
        Console.WriteLine("3 - Rechercher un contact");
        Console.WriteLine("4 - Supprimer un contact");
        Console.WriteLine("5 - Quitter");
        Console.WriteLine("\n");
    }

    // lancement du programme 
    void LancementProgramme()
    {
        bool quitter = false;
        while (!quitter)
        {
            Console.Clear();
            MenuContact();

            Console.WriteLine("Votre choix : ");
            choixStr = Console.ReadLine();
            while (!int.TryParse(choixStr, out choix))
            {
                Console.WriteLine("Choix invalide.");
                Console.WriteLine("Votre choix : ");
                choixStr = Console.ReadLine();
            }
        
            switch (choix)
            {
                case 1:
                AjouterContact();
                break;

                case 2:
                AfficherContacts();
                break;

                case 3:
                RechercherContact();
                break;

                case 4:
                SupprimerContact();
                break;

                case 5:
                quitter = true;
                Console.WriteLine("Au revoir !");
                break;

                default :
                Console.WriteLine("Choix Invalide !");
                break;
            }
        }
    }

    // méthode : ajouter un contact dans la liste (choix 1)
    public void AjouterContact()
    {
        Console.Clear();
        Console.WriteLine(" === Ajouter un contact === ");

        Contact nouveau = new Contact();
        Console.WriteLine("Entrez le nouveau nom du contact :");
        nouveau.Nom = Console.ReadLine();
        Console.WriteLine("Entrez le téléphone du nouveau contact :");
        nouveau.Telephone = Console.ReadLine();
        Console.WriteLine("Entrez l'email du nouveau contact :");
        nouveau.Email = Console.ReadLine();

        for (int i = 0; i < ListeContacts.Count; i++)
        {
            if (nouveau.Nom == ListeContacts[i].Nom)
            {
                Console.WriteLine("Ce contact existe déjà.");
                Console.WriteLine("Entrez à nouveau le nouveau nom du contact :");
                nouveau.Nom = Console.ReadLine();
            }

            else if (nouveau.Telephone == ListeContacts[i].Telephone)
            {
                Console.WriteLine("Ce contact existe déjà.");
                Console.WriteLine("Entrez à nouveau le téléphone du nouveau contact :");
                nouveau.Telephone = Console.ReadLine();
            }
            else if (nouveau.Email == ListeContacts[i].Email)
            {
                Console.WriteLine("Ce contact existe déjà.");
                Console.WriteLine("Entrez à nouveau l'email du nouveau contact :");
                nouveau.Email = Console.ReadLine();
            }
        }
        
        ListeContacts.Add(nouveau); 
        Console.WriteLine("Contact : " + nouveau.Nom + " ajouté.");
        Console.ReadKey();
    }

    // méthode : afficher tous les contacts de la liste (choix 2)
    public void AfficherContacts()
    {
        Console.Clear();
        Console.WriteLine("=== Liste des contacts === ");
        int compteur = 0;
        //ListeContacts.Sort();
        foreach (Contact c in ListeContacts)
        {
                Console.WriteLine("Nom : " + c.Nom);
                Console.WriteLine("Telephone : " + c.Telephone);
                Console.WriteLine("Email : " + c.Email);
                Console.WriteLine("\n");
                compteur++;
        }
        Console.WriteLine("Nombre de contacts : " + compteur); 
        Console.ReadKey();
    }

    // méthode : rechercher un contact dans la liste (choix 3)
    public void RechercherContact()
    {
        bool recherche = false;
        Console.Clear();
        Console.WriteLine(" === Rechercher un contact === ");
        Console.WriteLine("Nom recherché : ");
        Nom = Console.ReadLine();

        for (int k = 0; k < ListeContacts.Count; k++)
        {
            if (Nom == ListeContacts[k].Nom)
            {
                recherche = true;
                Console.WriteLine("Nom : " + ListeContacts[k].Nom + " - Téléphone : " + ListeContacts[k].Telephone + " - Email : " + ListeContacts[k].Email);
                break; 
            }
        }
        if (recherche == true)
        {
            Console.WriteLine("Contact Trouvé."); 
        }
        else
        {
            Console.WriteLine("Contact inexistant.");
        }
        
        Console.ReadKey();
    }
    
    // méthode : supprimer un contact de la liste (choix 4)
    public void SupprimerContact()
    {
        bool supprimer = false;
        Console.Clear();
        Console.WriteLine(" === Supprimer un contact === ");
        Console.WriteLine("Nom à supprimer : ");
        Nom = Console.ReadLine();

        for (int j = 0; j < ListeContacts.Count; j++)
        {
            if (Nom == ListeContacts[j].Nom)
            {
                supprimer = true;
                ListeContacts.Remove(ListeContacts[j]);
                break;
            }
        }

        if (supprimer == true)
        { 
            Console.WriteLine("Contact " + Nom + " supprimé.");
        }
        else
        {
            Console.WriteLine("Contact introuvable");
        }
        Console.ReadKey();     
    }
    public static void Main(string[] args)
    {
       Program program = new Program();
       program.LancementProgramme();
    }   
}


