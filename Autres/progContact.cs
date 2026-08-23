using ExoContact;

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