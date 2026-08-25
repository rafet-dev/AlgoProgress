namespace GestionComptesBancaires
{
    public class Banque
    {
        private List<CompteBancaire> _listeComptes = new List<CompteBancaire>();
        public List<CompteBancaire> ListeComptes { get => _listeComptes; set => _listeComptes = value; }

        public void CreerCompte()
        {
            string soldeStr;
            string nbcompteStr;
            double nouveauSolde;
            int nouveauNumeroCompte;
            
            Client nouveau = new Client();
            CompteBancaire nouveauCompte = new CompteBancaire();

            Console.WriteLine("===== Créer un compte Bancaire =====");
            Console.WriteLine("\n");
            Console.WriteLine("Identité : ");
            Console.WriteLine("Nom du nouveau Client : ");
            nouveau.NomClient = Console.ReadLine();
            Console.WriteLine("Prénom du nouveau Client : ");
            nouveau.PrenomClient = Console.ReadLine();

            nouveauCompte.Client = nouveau;

            Console.WriteLine("\n");
            Console.WriteLine("Caractéristique du nouveau compte crée : ");
            Console.WriteLine("Dépôt de départ pour le compte : ");
            soldeStr = Console.ReadLine();

            while(!double.TryParse(soldeStr, out nouveauSolde))
            {
                Console.WriteLine("Saisie invalide !");
                Console.WriteLine("Dépôt de départ pour le compte : ");
                soldeStr = Console.ReadLine();
            }
            
            nouveauSolde = double.Parse(soldeStr);
            nouveauCompte.Solde = nouveauSolde;

            Console.WriteLine("Numero du compte : ");
            nbcompteStr = Console.ReadLine();

            while(!int.TryParse(nbcompteStr, out nouveauNumeroCompte))
            {
                Console.WriteLine("Saisie invalide !");
                Console.WriteLine("Numero du compte : ");
                nbcompteStr = Console.ReadLine();
            }

            nouveauNumeroCompte = int.Parse(nbcompteStr);

            for (int i = 0; i < ListeComptes.Count; i++)
            {
                if (ListeComptes[i].NumeroCompte == nouveauNumeroCompte)
                {
                    Console.WriteLine("Le numéro de compte existe déjà !");
                    Console.WriteLine("Veuillez saisir un autre numéro de compte : ");
                    nbcompteStr = Console.ReadLine();

                    while(!int.TryParse(nbcompteStr, out nouveauNumeroCompte))
                    {
                        Console.WriteLine("Saisie invalide !");
                        Console.WriteLine("Veuillez saisir un autre numéro de compte : ");
                        nbcompteStr = Console.ReadLine();
                    }
                    nouveauNumeroCompte = int.Parse(nbcompteStr);
                }
            }

            nouveauCompte.NumeroCompte = nouveauNumeroCompte;
            ListeComptes.Add(nouveauCompte);
        }

        public void AfficherCompte()
        {
            Console.Clear();
            Console.WriteLine("===== Afficher l'ensemble des comptes clients =====");
            Console.WriteLine("\n");

            for (int i = 0; i < ListeComptes.Count; i++)
            {
               ListeComptes[i].AfficherCompte();
               Console.WriteLine("\n");   
            }
            Console.WriteLine("Nombre total de comptes : " + ListeComptes.Count);
            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadKey();
        }

        public void AfficherCapitalTotal()
        {
            double capitalTotal = 0;
            for (int j = 0; j < ListeComptes.Count; j++)
            {
                capitalTotal = capitalTotal + ListeComptes[j].Solde;
            }
            Console.WriteLine("Capital total des comptes : " + capitalTotal);
            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadKey();
        }
    }
}

