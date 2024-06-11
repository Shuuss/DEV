using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace P1_BD_Locale
{
    public enum GenreClient {Neutre='N',Homme='H',Femme='F'};
    public class Client : ICloneable
    {

        private int id;
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

        public Client(int id, string nom, string prenom, string email)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
        }

        public Client(int id, string nom, string prenom, string email, DateTime dateNaissance, string telephone) : this(id, nom, prenom, email)
        {
            this.DateNaissance = dateNaissance;
            this.Telephone = telephone;
        }

        public Client(int id, string nom, string prenom, string email, DateTime dateNaissance, string telephone, GenreClient genre) : this(id, nom, prenom, email, dateNaissance, telephone)
        {
            this.Genre = genre;
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                   throw new ArgumentException("Le nom doit être renseigné");
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
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Le prénom doit être renseigné");
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
                try
                {
                    MailAddress mail = new MailAddress(value);
                    this.email = value;
                }catch(Exception e) { throw new ArgumentException("L'email est invalide."); }
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
                    throw new ArgumentException("La date ne peut être aujourd'hui.");
            
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
               if (! Regex.IsMatch(value,"^[0-9]{10}$"))
                    throw new ArgumentException("Le format du tel n'est pas correct. 10 chiffres attendus.");

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

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public object Clone()
        {
            return new Client(this.id, this.nom, this.prenom, this.email, this.DateNaissance,this.telephone,this.genre);
        }

        public override string? ToString()
        {
            return Nom + " " + Prenom + " "+ Email;    
        }
    }
}
