
namespace Comptabilite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Compte compte1 = new Compte
            {
                NumeroCompte = 1578,
                TitulaireCompte = "John Doe",
                Solde = 1475
            };

            Compte compte2 = new Compte
            {
                NumeroCompte = 2417,
                TitulaireCompte = "Jack Bauer",
                Solde = 2541
            };

            Transaction transaction1 = new Transaction
            {
                DateTransaction = DateTime.Now,
                Type = TypeTransaction.Debit,
                Compte = compte1,
                MontantTransaction = 350
            };

            compte1.AjouterLigneTransaction(transaction1);

            for (int i = 0; i < compte1.ListeTransaction.Count; i++)
            {
                Console.WriteLine(compte1.ListeTransaction[i]);
            }
        }
    }
}