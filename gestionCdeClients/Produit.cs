
namespace GestionCdeClient
{
    public class Produit
    {
        private string _nomProduit;
        private double _prix;
        private double _quantite;

        public string NomProduit { get => _nomProduit; set => _nomProduit = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public double Quantite { get => _quantite; set => _quantite = value; }
    }

}
