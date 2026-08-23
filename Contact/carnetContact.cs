using System.Reflection.Metadata;
// déclaration des variables
List<string> contacts = new List<string>();
int choix;
string choixStr;


// menu de départ
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

// choix 1
void AjouterContact(List<string> contacts)
{
        Console.Clear();
        Console.WriteLine(" === Ajouter un contact === ");
        Console.WriteLine("Nom du contact : ");
        string ajout = Console.ReadLine();

        while (contacts.Contains(ajout))
        {
            Console.WriteLine("Ce contact existe déjà.");
            Console.WriteLine("Nom du contact : ");
            ajout = Console.ReadLine();
        }
        
        contacts.Add(ajout); 
        Console.WriteLine("Contact : " + ajout + " ajouté.");
        Console.ReadKey();  
}

// choix 2
void AfficherContact(List<string> contacts)
{
    Console.Clear();
    Console.WriteLine(" === Affichage des contacts === ");
    contacts.Sort();
    for (int l = 0; l < contacts.Count ; l++)
    {
        Console.WriteLine((l + 1) + " - " + contacts[l]);
    }

    Console.WriteLine("Nombre de contacts : " + contacts.Count);
    Console.ReadKey();
}
 
// choix 3
void RechercherContact(List<string> contacts)
{
    Console.Clear();
    Console.WriteLine(" === Rechercher un contact === ");
    Console.WriteLine("Nom recherché : ");
    string recherche = Console.ReadLine();

        if (!contacts.Contains(recherche))
        {
            Console.WriteLine("Contact inexistant.");
        }
        else
        {
            Console.WriteLine("Contact Trouvé.");
        }
    
    Console.ReadKey();
}
    
// choix 4 
void SupprimerContact(List<string> contacts)
{
    Console.Clear();
    Console.WriteLine(" === Supprimer un contact === ");
    Console.WriteLine("Nom à supprimer : ");
    string nomsuppr = Console.ReadLine();
        if (contacts.Contains(nomsuppr))
        {
            contacts.Remove(nomsuppr);
            Console.WriteLine("Contact " + nomsuppr + " supprimé.");
        }
        else
        {
            Console.WriteLine("Contact introuvable");
        }
    
    Console.ReadKey();
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
            AjouterContact(contacts);
            break;

            case 2:
            AfficherContact(contacts);
            break;

            case 3:
            RechercherContact(contacts);
            break;

            case 4:
            SupprimerContact(contacts);
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

LancementProgramme();
