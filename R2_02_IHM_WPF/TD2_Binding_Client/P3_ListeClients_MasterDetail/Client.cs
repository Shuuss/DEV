using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace P3_ListeClients_MasterDetail
{
    public enum GenreClient {Neutre, Homme,Femme};
    public class Client    {

        private GenreClient genre;
        private string nom;
        private string prenom;
        private string email;
        private DateTime dateNaissance;
        private string telephone;
        public Client()
        {
            this.dateNaissance = DateTime.Today;
        }

        public Client(string nom, string prenom, string email)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }

        public Client(string nom, string prenom, string email, DateTime dateNaissance, string telephone) : this(nom, prenom, email)
        {
            this.DateNaissance = dateNaissance;
            this.Telephone = telephone;
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
               this.nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {               
                this.prenom = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                
                    this.email = value;
               
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return this.dateNaissance;
            }

            set
            {
                           
                this.dateNaissance = value;
            }
        }

        public string Telephone
        {
            get
            {
                return this.telephone;
            }

            set
            {
              
                this.telephone = value;
            }
        }

        public GenreClient Genre
        {
            get
            {
                return this.genre;
            }

            set
            {
                this.genre = value;
            }
        }

        public override string? ToString()
        {
            return Nom + " " + Prenom + " "+ Email;    
        }
    }
}
