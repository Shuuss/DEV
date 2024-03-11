using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Association
{
    public enum Qualification
    {
        Junior,
        Confirme,
        Senior
    }
    internal class Salarie
    {
        public static readonly double[] COUT_HORAIRES = new double[] {25,45,65};
        public static readonly int SEUIL_CONFIRME = 5;
        public static readonly int SEUIL_SENIOR = 10;
        private int nbAnnees;
        private string nom;
        private string prenom;

        public Salarie(string nom, string prenom, int nbAnnees)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.NbAnnees = nbAnnees;
        }

        public int NbAnnees
        {
            get
            {
                return nbAnnees;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("le nombre d'années doit être positif ou nul");
                }
                nbAnnees = value;
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
            return obj is Salarie salarie &&
                   this.Nom == salarie.Nom &&
                   this.Prenom == salarie.Prenom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Nom, this.Prenom);
        }

        public Qualification DonneQualification()
        {
            if (this.NbAnnees < SEUIL_CONFIRME)
            {
                return Qualification.Junior;
            }
            if (this.NbAnnees <= SEUIL_SENIOR)
            {
                return Qualification.Confirme;
            }
            return Qualification.Senior;
        }
        
        public double DonneCoutHoraire()
        {
            return COUT_HORAIRES[(int)this.DonneQualification()];
        }

        public override string? ToString()
        {
            return $"Nom : {Nom}" +
                $"\nPrénom : {Prenom}" +
                $"\nExperience : {NbAnnees} an(s)" +
                $"\nQualification : {this.DonneQualification()}" +
                $"\nCout horaire : {this.DonneCoutHoraire()} euros";
        }
    }
}
