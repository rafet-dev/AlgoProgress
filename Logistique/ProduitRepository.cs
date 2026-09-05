using Npgsql;

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
    }
}