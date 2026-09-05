using Npgsql;

namespace Logistique
{
    public class CommandeRepository
    {
        private string _connectionString;

        public CommandeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Inserer(Commande commande)
        {
            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open();

                string insertSql = "INSERT INTO commande DEFAULT VALUES RETURNING IDCommande";

                using (var cmdSql = new NpgsqlCommand(insertSql, connexion))
                {
                    return Convert.ToInt32(cmdSql.ExecuteScalar());
                }
            }
        }
    }
}