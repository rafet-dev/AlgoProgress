using System.Collections.Generic;
namespace Logistique
{
    public class Commande
    {
        private List<LigneCommande> _ligneCommande = new List<LigneCommande>();
        public List<LigneCommande> LigneCommande { get => _ligneCommande;}

        public void AjouterLigne(LigneCommande ligne)
        {
            _ligneCommande.Add(ligne);
        }
    }
}