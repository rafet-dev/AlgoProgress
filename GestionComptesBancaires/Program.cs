namespace GestionComptesBancaires
{
    public class Program
    {
        Banque GestionComptes = new Banque();
        double montant;
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("===== Gestion des comptes Bancaires =====");
            Console.WriteLine("\n");
            Console.WriteLine("1. Ajouter un compte Bancaire");
            Console.WriteLine("2. Afficher les comptes Bancaires");
            Console.WriteLine("3. Déposer de l'argent sur un compte Bancaire");
            Console.WriteLine("4. Retirer de l'argent d'un compte Bancaire");
            Console.WriteLine("5. Afficher le capital total des comptes Bancaires");
            Console.WriteLine("6. Quitter");
            Console.WriteLine("\n");

        }

        public void LancementProgram()
        {
            bool quitter = false;
            while (!quitter)
            {
                Menu();
                Console.Write("Veuillez choisir une option : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        GestionComptes.CreerCompte();
                        break;

                    case "2":
                        GestionComptes.AfficherCompte();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("===== Déposer de l'argent du compte Bancaire =====");
                        Console.WriteLine("\n");
                
                        Console.WriteLine("Veuillez saisir le numéro du compte : ");
                        string numeroCompteStr = Console.ReadLine();
                        int numeroCompte = int.Parse(numeroCompteStr);
                        bool compteTrouve = false;

                        for (int i = 0; i < GestionComptes.ListeComptes.Count; i++)
                        {
                            if (GestionComptes.ListeComptes[i].NumeroCompte == numeroCompte)
                            {
                                compteTrouve = true;
                                Console.WriteLine("Saisissez le montant à déposer: ");
                                string montantStr = Console.ReadLine();

                                while(!double.TryParse(montantStr, out montant) || montant <= 0)
                                {
                                    Console.WriteLine("Saisie invalide !");
                                    Console.WriteLine("Saisissez le montant à déposer: ");
                                    montantStr = Console.ReadLine();
                                }
                                GestionComptes.ListeComptes[i].Deposer(montant);
                                break;
                            }
                            
                        }   
                        if (compteTrouve == false)
                        {
                            Console.WriteLine("Le compte n'existe pas !");
                            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
                            Console.ReadKey();
                        }

                        else
                        {
                            break;
                        }

                    case "4":
                       Console.Clear();
                        Console.WriteLine("===== Retirer de l'argent du compte Bancaire =====");
                        Console.WriteLine("\n");
                
                        Console.WriteLine("Veuillez saisir le numéro du compte : ");
                        numeroCompteStr = Console.ReadLine();
                        numeroCompte = int.Parse(numeroCompteStr);

                        bool trouve = false;
                        for (int i = 0; i < GestionComptes.ListeComptes.Count; i++)
                        {
                            if (GestionComptes.ListeComptes[i].NumeroCompte == numeroCompte)
                            {
                                trouve = true;
                                Console.WriteLine("Saisissez le montant à retirer: ");
                                string montantStr = Console.ReadLine();

                                while(!double.TryParse(montantStr, out montant) || montant <= 0)
                                {
                                    Console.WriteLine("Saisie invalide !");
                                    Console.WriteLine("Saisissez le montant à retirer: ");
                                    montantStr = Console.ReadLine();
                                }   
                                GestionComptes.ListeComptes[i].Retirer(montant); 
                                break;
                            }
                            
                        }   

                        if (trouve == false)
                        {
                            Console.WriteLine("Le compte n'existe pas !");
                            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
                            Console.ReadKey();
                        }

                        else
                        {
                            break;
                        }

                    case "5":
                        Console.Clear();
                        Console.WriteLine("===== Obtenir le solde du compte Bancaire =====");
                        Console.WriteLine("\n");
                        GestionComptes.AfficherCapitalTotal();
                        break;

                    case "6":
                        quitter = true;
                        Console.WriteLine("Merci d'avoir utilisé le programme. Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        break;
                }

                if (!quitter)
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadKey();
                }
            }
        }

        public static void Main(string []args)
        {
            Program program = new Program();
            program.LancementProgram();
        }
    }
}