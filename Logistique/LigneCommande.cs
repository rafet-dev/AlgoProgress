namespace Logistique
{
    public class LigneCommande
    {
        private Produit _produit;
        private int _quantiteCommandee;

        public Produit Produit { get => _produit; set => _produit = value; }
        public int QuantiteCommandee { get => _quantiteCommandee; set => _quantiteCommandee = value; }

        public double prixLigneCommande()
        {
            double prixLigne = Produit.Prix * QuantiteCommandee;
            return prixLigne;   
        }
    }
}