using Npgsql;
using System.Collections.Generic;

namespace Logistique
{
    public class LigneCommandeRepository
    {
        private string _connectionString;

        public LigneCommandeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserer(LigneCommande ligne, int idProduit, int idCommande)
        {
            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open();

                string insertSql = "INSERT INTO lignecommande (quantitecommandee, idproduit, idcommande) VALUES (@quantite, @idProduit, @idCommande) RETURNING IDLigneCommande";

                using (var cmdSql = new NpgsqlCommand(insertSql, connexion))
                {
                    cmdSql.Parameters.AddWithValue("quantite", ligne.QuantiteCommandee);
                    cmdSql.Parameters.AddWithValue("idProduit", idProduit);
                    cmdSql.Parameters.AddWithValue("idCommande", idCommande);

                    return Convert.ToInt32(cmdSql.ExecuteScalar());
                }
            }
        }
    }
}