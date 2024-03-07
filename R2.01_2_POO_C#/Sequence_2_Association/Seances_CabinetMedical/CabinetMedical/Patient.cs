using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMedical
{
    public class Patient
    {
        private DateTime dateNaissance;
        private string nom;
        private string prenom;

        public Patient()
        {
        }

        public Patient(DateTime dateNaissance, string nom, string prenom)
        {
            this.DateNaissance = dateNaissance;
            this.Nom = nom;
            this.Prenom = prenom;
        }
        public Patient(string dateNaissance, string nom, string prenom)
        {
            this.DateNaissance = DateTime.Parse(dateNaissance);
            this.Nom = nom;
            this.Prenom = prenom;
        }

        public int Age
        {
            get
            {
                if (DateTime.Now.DayOfYear > dateNaissance.DayOfYear)
                {
                    return (DateTime.Now.Year - DateNaissance.Year);
                }

                return (DateTime.Now.Year - DateNaissance.Year)-1;
            }
        }
        
        public DateTime DateNaissance
        {
            get
            {
                return dateNaissance;
            }

            set
            {
                dateNaissance = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
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

        public override bool Equals(object? obj)
        {
            return obj is Patient patient &&
                   this.DateNaissance == patient.DateNaissance &&
                   this.Nom == patient.Nom &&
                   this.Prenom == patient.Prenom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.DateNaissance, this.Nom, this.Prenom);
        }

        public override string? ToString()
        {
            return $"{Nom} {Prenom} a {Age} ans.";
        }
    }
}
