using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace P1_FicheClient
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("le nom doit être renseigné");
                }
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("le prénom doit être renseigné");
                }
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

                if (!Regex.IsMatch(value, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                {
                    throw new ArgumentException("le format du mail est invalide");
                }
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
                if (value == DateTime.Today)
                {
                    throw new ArgumentException("vous n'êtes pas né aujourd'hui");
                }          
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
                if (!Regex.IsMatch(value, "(0|\\+33|0033)[1-9][0-9]{8}"))
                {
                    throw new ArgumentException("format de téléphone invalide");
                }
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
            return $"Nom : {Nom}" +
                $"\nPrenom : {Prenom}" +
                $"\nDate de Naissance : {DateNaissance.ToShortDateString()}" +
                $"\nEmail : {Email}" +
                $"\nTelephone : {Telephone}" +
                $"\nGenre : {Genre}";    
        }
    }
}
