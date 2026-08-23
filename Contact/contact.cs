using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoContact
{
    internal class Contact
    {
        //attributs
        private string _nom;
        private string _telephone;
        private string _email;

        private List<Contact> contacts = new List <Contact>();


        // accesseurs
        public string Nom { get => Nom; set => Nom = value; }
        public string Telephone { get => Telephone; set => Telephone = value; }
        public string Email { get => Email; set => Email = value; }

        // constructeur
        public Contact(string nom, string telephone, string email)
        {
            this.Nom = nom;
            this.Telephone = telephone;
            this.Email = email;
        }

        // méthodes associés à la classe Contact

        public void AjouterContact(Contact contacts)
        {
        Console.Clear();
        Console.WriteLine(" === Ajouter un contact === ");
        Console.WriteLine("Nom du contact : ");
        string ajoutNom = Console.ReadLine();

        Console.WriteLine("Numéro de téléphone : ");
        string ajoutTelephone = Console.ReadLine();

        Console.WriteLine("Adresse email : ");
        string ajoutEmail = Console.ReadLine;

        while (contacts.Contains(ajoutNom, ajoutTelephone, ajoutEmail))
        {
            Console.WriteLine("Ce contact existe déjà.");
            Console.WriteLine("Nom du contact : ");
            string ajoutNom = Console.ReadLine();

            Console.WriteLine("Numéro de téléphone : ");
            string ajoutTelephone = Console.ReadLine();

            Console.WriteLine("Adresse email : ");
            string ajoutEmail = Console.ReadLine;
        }
        
        contacts.Add(ajoutNom, ajoutTelephone, ajoutEmail); 
        Console.WriteLine("Contact : " + ajoutNom + " ajouté.");
        Console.ReadKey();
        }

        public void AfficherContacts()
        {
            Console.WriteLine("=== Liste des contacts === ");
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("Nom : " + Contact.nom);
                Console.WriteLine("Telephone : " + Contact.telephone);
                Console.WriteLine("Email : " + Contact.email);
                Console.WriteLine("\n");
            }

           
        }

        public void RechercherContact()
        {
            
        }

        public void SupprimerContact()
        {
            
        }
    }
}
