using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    public enum SexeAnimal
    {
        Feminin = 'F',
        Masculin = 'M',
        Hermaphrodite = 'H'
    }
    
    public abstract class Animal
    {
        public const String UM_TAILLE = "m";
        public const String UM_POIDS = "kg";
        public const String UM_AGE = "an(s)";

        private SexeAnimal sexe;
        private string nom;
        private int anneeNaissance;
        private double poids;
        private double taille;

        protected Animal(SexeAnimal sexe, string nom, int anneeNaissance, double poids, double taille)
        {
            this.Sexe = sexe;
            this.Nom = nom;
            this.AnneeNaissance = anneeNaissance;
            this.Poids = poids;
            this.Taille = taille;
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - anneeNaissance;
            }
        }
        
        public SexeAnimal Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                sexe = value;
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
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le nom ne doit pas être nul et ne doit pas être vide");
                }
                nom = value.ToUpper();
            }
        }

        public int AnneeNaissance
        {
            get
            {
                return anneeNaissance;
            }

            set
            {
                if (value > DateTime.Now.Year)
                {
                    throw new ArgumentException("L’année de naissance ne doit pas être supérieure à l’année actuelle.");
                }
                anneeNaissance = value;
            }
        }

        public double Poids
        {
            get
            {
                return poids;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Le poids de doit pas être négatif");
                }
                poids = value;
            }
        }

        public double Taille
        {
            get
            {
                return this.taille;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La taille de doit pas être négative");
                }
                this.taille = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Animal animal &&
                   this.Nom == animal.Nom;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Nom);
        }

        public abstract string Cri();
        public abstract bool EstAdulte();

        public override string? ToString()
        {
            return $"Nom : {Nom}" +
                $"\nSexe : {Sexe}" +
                $"\nAnnee de Naissance : {AnneeNaissance}" +
                $"\nAge ; {Age} {UM_AGE}" +
                $"\nAdulte : {EstAdulte()}" +
                $"\nPoids : {Poids} {UM_POIDS}" +
                $"\nTaille : {Taille} {UM_TAILLE}" +
                $"\nCri : {Cri()}";
        }

    }
}
