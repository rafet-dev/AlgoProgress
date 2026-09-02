namespace Logistique
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Produit produit1 = new Produit
            {
                Nom = "stylo",
                Prix = 1.50,
                QuantiteEnStock = 100
            };

            LigneCommande ligne1 = new LigneCommande
            {
                Produit = produit1,
                QuantiteCommandee = 5
            };

            Commande commande1 = new Commande();
            commande1.AjouterLigne(ligne1);
        }
    }
}