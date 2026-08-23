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
            Banque nouveau = new Banque();
            ComptesBancaires nouveauCompte = new ComptesBancaires();

            Console.WriteLine("===== Créer un compte Bancaire =====");
            Console.WriteLine("\n");
            Console.WriteLine("Identité : ");
            Console.WriteLine("Nom du nouveau Client : ");
            nouveau.NomClient = Console.ReadLine();
            Console.WriteLine("Prénom du nouveau Client : ");
            nouveau.PrenomClient = Console.ReadLine();

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
            
            nouveauCompte.nouveauSolde = double.Parse(soldeStr);

            Console.WriteLine("Numero du compte : ");
            


        }

        public void AfficherCompte()
        {
            
        }

        public void CapitalTotal()
        {
            
        }
    }
}