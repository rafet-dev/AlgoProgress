using System.Collections.Generic;
namespace Logistique
{
    public class Produit
    {
        private string _nom;
        private double _prix;
        private int _quantiteEnStock;

        public string Nom { get => _nom; set => _nom = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public int QuantiteEnStock { get => _quantiteEnStock; set => _quantiteEnStock = value; }

        public int RetirerDuStock(int quantite)
        {
            if (QuantiteEnStock >= quantite)
            {
                return QuantiteEnStock = QuantiteEnStock - quantite;
            }

            else
            {
                return QuantiteEnStock;
            }
        }
    }
}