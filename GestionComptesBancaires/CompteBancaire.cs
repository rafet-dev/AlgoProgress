namespace GestionComptesBancaires
{
    public class ComptesBancaires
    {
        private int _numeroCompte;
        private double _solde;
        private Client _client;

        public int NumeroCompte { get => _numeroCompte; set => _numeroCompte = value; }
        public double Solde { get => _solde; set => _solde = value; }
        public Client Client { get => _client; set => _client = value; }

        public void Deposer(double montant)
        {
            
        }

        public void Retirer(double montant)
        {
            
        }

        public void AfficherCompte()
        {
            
        }

        public void ObtenirSolde()
        {
            
        }
    }
}