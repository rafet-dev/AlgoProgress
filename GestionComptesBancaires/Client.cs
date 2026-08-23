namespace GestionComptesBancaires
{
    public class Client
    {
        private string _nomClient;
        private string _prenomClient;

        public string NomClient { get => _nomClient; set => _nomClient = value; }
        public string PrenomClient { get => _prenomClient; set => _prenomClient = value; }
    }
}