using Npgsql;
using System.Collections.Generic;

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

        public List<int> Lister()
        {
            var idsCommandes = new List<int>();

            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open();
                string selectSql = "SELECT idcommande FROM commande ORDER BY idcommande";

                using (var cmdSql = new NpgsqlCommand(selectSql, connexion))
                using (var lecteur = cmdSql.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        int id = lecteur.GetInt32(0);
                        idsCommandes.Add(id);
                        Console.WriteLine($"Commande n°{id}");
                    }
                }
            }
            return idsCommandes;
        }
    }
}