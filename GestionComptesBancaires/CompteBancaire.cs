namespace GestionComptesBancaires
{
    public class CompteBancaire
    {
        private int _numeroCompte;
        private double _solde;
        private Client _client;

        public int NumeroCompte { get => _numeroCompte; set => _numeroCompte = value; }
        public double Solde { get => _solde; set => _solde = value; }
        public Client Client { get => _client; set => _client = value; }

        public void Deposer(double montant)
        {

            Solde = Solde + montant;
            Console.WriteLine("Le nouveau solde du compte est : " + Solde);
            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadKey();
        }
        public void Retirer(double montant)
        {
            if (montant > Solde)
            {
                Console.WriteLine("Le montant à retirer est supérieur au solde du compte !");
                Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
                Console.ReadKey();
                return;
            }

            Solde = Solde - montant;
            Console.WriteLine("Le nouveau solde du compte est : " + Solde);
            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadKey();
        }

        public void AfficherCompte()
        {
            Console.WriteLine("===== Informations de votre compte Bancaire =====");
            Console.WriteLine("\n");

            Console.WriteLine("Nom du client : " + Client.NomClient);
            Console.WriteLine("Prénom du client : " + Client.PrenomClient); 
            Console.WriteLine("Numéro du compte : " + NumeroCompte);
            Console.WriteLine("Solde du compte : " + Solde);
            Console.WriteLine("\n");

            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadKey();
        }

        public double ObtenirSolde()
        {
            Console.WriteLine("Appuyer sur une touche pour revenir au menu principal");
            Console.ReadKey();  
            return Solde;   
        }
    }
}