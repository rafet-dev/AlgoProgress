using Npgsql;
using System.Collections.Generic;

namespace Comptabilite
{
    public class CompteRepository
    {
        private string _connectionString;

        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        // constructeur
        public CompteRepository(string connectionString) => this.ConnectionString = connectionString;

        // méthode Inserer : ajouter une nouvelle ligne en base et récupérer l'iD généré pour NumeroCompte
        public int Inserer(Compte compte)
        {
            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open(); 
                string insertSql = "INSERT INTO Compte (titulaireCompte, solde) values (@titulaireCompte, @solde) RETURNING NumeroCompte";
               
                using (var cmdSql = new NpgsqlCommand(insertSql, connexion))
                {
                    cmdSql.Parameters.AddWithValue("titulaireCompte", compte.TitulaireCompte);
                    cmdSql.Parameters.AddWithValue("solde", compte.Solde);

                    return Convert.ToInt32(cmdSql.ExecuteScalar());
                }
            }  
        }
        public List<Compte> Lister()
        {
            var NbCompte = new List<Compte>();

            using (var connexion = new NpgsqlConnection(_connectionString))
            {
                connexion.Open();
                string selectSql = "SELECT NumeroCompte, titulaireCompte, solde FROM Compte ORDER BY NumeroCompte";

                using (var cmdSql = new NpgsqlCommand(selectSql, connexion))
                using (var lecteur = cmdSql.ExecuteReader())
                {
                    while (lecteur.Read())
                    {
                        Compte id = lecteur.GetInt32(0);
                        NbCompte.Add(id);
                        Console.WriteLine($"Compte n°{id}");

                    }
                }
            }
            return NbCompte;
        }
    }
}


