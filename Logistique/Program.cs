using System.Collections.Generic;
using Npgsql;
// "je vais utiliser des outils qui viennent de la bibliothèque Npgsql" (celle qu'on a installée avec dotnet add package Npgsql)
namespace Logistique
{   
    public class Program
    {
        
        public static void Main(string[] args)
        {
            // connexion à la base de données 
            // simple variable texte (string) qui contient toutes les informations nécessaires pour trouver et ouvrir la porte 
            // de ta base de données :

            // Host=localhost → "la base est sur cet ordinateur" (ton PC)
            // Port=5432 → "elle écoute sur cette porte-là précisément" (le port que tu avais vu dans docker ps)
            // Database=Logistique → "je veux accéder à la base qui s'appelle Logistique"
            // Username=postgres et Password=... → "voici mes identifiants pour prouver que j'ai le droit d'entrer"
            string connectionString = "Host=localhost;Port=5432;Database=Logistique;UserName=postgres;Password=password";

            /* new NpgsqlConnection(connectionString) crée un objet connexion en lui donnant l'adresse/les identifiants qu'on 
            vient de préparer.
            À ce stade, la connexion n'est pas encore ouverte, juste préparée.
            Le mot-clé using (...) { ... } est un mécanisme spécial de C# qui dit : "utilise cette connexion seulement 
            à l'intérieur de ces accolades,
            et ferme-la automatiquement dès que tu sors de ce bloc — même si une erreur se produit en cours de route." 
            C'est une sécurité très importante : une connexion à une base de données est une ressource "coûteuse" 
            (comme laisser un robinet ouvert), donc on veut être sûr qu'elle se referme toujours proprement. */ 
            using (var connexion = new NpgsqlConnection(connectionString))
            {
                connexion.Open();
                //C'est la ligne qui ouvre réellement la connexion — elle contacte PostgreSQL, vérifie que l'adresse 
                // et les identifiants sont bons, et établit le lien. Si quelque chose est faux 
                // (mauvais mot de passe, port fermé, base inexistante), c'est cette ligne qui provoquerait une erreur.
                Console.WriteLine("Connexion à la base réussie ! ");
                // Simplement : si on arrive jusqu'ici sans erreur, ça veut dire que Open() a réussi. On affiche donc 
                // un message pour le confirmer visuellement — c'est exactement ce que tu as vu dans ton terminal.
            }

            // test pour l'éxécution du programme
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

            Console.WriteLine($"Nombre de lignes dans la commande : {commande1.LigneCommande.Count}");
            Console.WriteLine($"Prix de la ligne 1 : {ligne1.prixLigneCommande()}");  
        }
                  
    }
}
