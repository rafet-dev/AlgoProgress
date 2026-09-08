using Npgsql;
using System.Collections.Generic;

namespace Logistique
{
    public class ProduitRepository
    {
        private string _connectionString;

        public ProduitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserer(Produit produit)
        {
            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open();

                string insertSql = "INSERT INTO produit (nom, prix, quantiteenstock) VALUES (@nom, @prix, @quantite) RETURNING IDProduit";

                using (var cmdSql = new NpgsqlCommand(insertSql, connexion))
                {
                    cmdSql.Parameters.AddWithValue("nom", produit.Nom);
                    cmdSql.Parameters.AddWithValue("prix", produit.Prix);
                    cmdSql.Parameters.AddWithValue("quantite", produit.QuantiteEnStock);

                    return Convert.ToInt32(cmdSql.ExecuteScalar());
                }
            }
        }

        public List<Produit> Lister()
        {
            var produits = new List<Produit>();

            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open();
                string selectSql = "SELECT idproduit, nom, prix, quantiteenstock FROM produit ORDER BY idproduit";

                using (var cmdSql = new NpgsqlCommand(selectSql, connexion))
                using (var lecteur = cmdSql.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        var produit = new Produit
                        {
                            Nom = lecteur.GetString(1),
                            Prix = lecteur.GetDouble(2),
                            QuantiteEnStock = lecteur.GetInt32(3)
                        };
                        produits.Add(produit);
                        Console.WriteLine($"{lecteur.GetInt32(0)} - {produit.Nom} - {produit.Prix}€ - Stock: {produit.QuantiteEnStock}");
                    }
                }
            }

        return produits;
        }
    }
}