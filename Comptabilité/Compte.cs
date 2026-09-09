using System.Collections.Generic;

namespace Comptabilite
{
    public class Compte
    {
        private int _numeroCompte;
        private string _titulaireCompte;
        private double _solde;
        private List<Transaction> _listeTransaction = new List<Transaction>();

        public int NumeroCompte { get => _numeroCompte; set => _numeroCompte = value; }
        public string TitulaireCompte { get => _titulaireCompte; set => _titulaireCompte = value; }
        public double Solde { get => _solde; set => _solde = value; }
        public List<Transaction> ListeTransaction { get => _listeTransaction;}

        public void AjouterLigneTransaction(Transaction ligneTransaction)
        {
            _listeTransaction.Add(ligneTransaction);
        }
    }
}