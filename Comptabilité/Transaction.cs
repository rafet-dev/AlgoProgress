namespace Comptabilite
{
    public class Transaction
    {
        private int _numeroTransaction;
        private DateTime _dateTransaction;
        private TypeTransaction _type;
        private Compte _compte;
        private double _montantTransaction;

        public int NumeroTransaction { get => _numeroTransaction; set => _numeroTransaction = value; }
        public DateTime DateTransaction { get => _dateTransaction; set => _dateTransaction = value; }
        public TypeTransaction Type { get => _type; set => _type = value; }
        public Compte Compte { get => _compte; set => _compte = value; }
        public double MontantTransaction { get => _montantTransaction; set => _montantTransaction = value; }

        public override string ToString()
        {
            return $"Transaction n°{NumeroTransaction} - {DateTransaction} - {Type} - {MontantTransaction}€";
        }
    }
}