namespace GestionCdeClient
{
    public class Client
    {
        private string _nomClient;
        private string _prenom;

        public string NomClient { get => _nomClient; set => _nomClient = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
    
        public void CreerClient()
        {
            Console.Clear();
            Console.WriteLine("===== Créer un client =====");
            Console.WriteLine("\n");

            Console.WriteLine("Nom du client : ");
            NomClient = Console.ReadLine();

            Console.WriteLine("Prénom du client : ");
            Prenom = Console.ReadLine();

            Console.WriteLine("Le client " + NomClient + " " + Prenom + " est crée.");
            Console.ReadKey();
        }
    }   
}
