using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMedical
{
    public class Consultation
    {
        private bool aDomicile;
        private bool estDocteurTraitant;
        private Docteur unDocteur;
        private DateTime unJourUnHoraire;
        private Patient unPatient;

        public const double AGE_MAX_TRES_JEUNE_ENFANT = 2;
        public const double AGE_MAX_JEUNE_ENFANT = 5;
        public const double SUPP_TRES_JEUNE_ENFANT = 5;
        public const double SUPP_JEUNE_ENFANT = 3;
        public const double SUPP_DIMANCHE = 20;
        public const double SUPP_DEPLACEMENT = 10;
        public const double TAUX_REMBOURSEMENT_DOC_TRAITANT = 0.7;
        public const double TAUX_REMBOURSEMENT_DOC_NON_TRAITANT = 0.3;
        public const string MONNAIE = "€";

        public Consultation()
        {
        }

        public Consultation(bool aDomicile, bool estDocteurTraitant, Docteur unDocteur, DateTime unJourUnHoraire, Patient unPatient)
        {
            this.ADomicile = aDomicile;
            this.EstDocteurTraitant = estDocteurTraitant;
            this.UnDocteur = unDocteur;
            this.UnJourUnHoraire = unJourUnHoraire;
            this.UnPatient = unPatient;
        }

        public Consultation(bool aDomicile, bool estDocteurTraitant, CategorieDocteur uneCategorie, string nomDocteur, DateTime unJourUnHoraire, DateTime dateNaissance, string nomPatient, string prenomPatient)
        {
            this.ADomicile = aDomicile;
            this.EstDocteurTraitant = estDocteurTraitant;
            this.UnDocteur = new Docteur(uneCategorie, nomDocteur);
            this.UnJourUnHoraire = unJourUnHoraire;
            this.UnPatient = new Patient(dateNaissance,nomPatient,prenomPatient);
        }

        public Consultation(bool aDomicile, bool estDocteurTraitant, Docteur unDocteur, string unJourUnHoraire, Patient unPatient)
        {
            this.ADomicile = aDomicile;
            this.EstDocteurTraitant = estDocteurTraitant;
            this.UnDocteur = unDocteur;
            this.UnJourUnHoraire = DateTime.Parse(unJourUnHoraire);
            this.UnPatient = unPatient;
        }

        public bool ADomicile
        {
            get
            {
                return aDomicile;
            }

            set
            {
                aDomicile = value;
            }
        }

        public bool EstDocteurTraitant
        {
            get
            {
                return estDocteurTraitant;
            }

            set
            {
                estDocteurTraitant = value;
            }
        }

        public Docteur UnDocteur
        {
            get
            {
                return unDocteur;
            }

            set
            {
                unDocteur = value;
            }
        }

        public DateTime UnJourUnHoraire
        {
            get
            {
                return unJourUnHoraire;
            }

            set
            {
                unJourUnHoraire = value;
            }
        }

        public Patient UnPatient
        {
            get
            {
                return this.unPatient;
            }

            set
            {
                this.unPatient = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Consultation consultation &&
                   this.ADomicile == consultation.ADomicile &&
                   this.EstDocteurTraitant == consultation.EstDocteurTraitant &&
                   EqualityComparer<Docteur>.Default.Equals(this.UnDocteur, consultation.UnDocteur) &&
                   this.UnJourUnHoraire == consultation.UnJourUnHoraire &&
                   EqualityComparer<Patient>.Default.Equals(this.UnPatient, consultation.UnPatient);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ADomicile, this.EstDocteurTraitant, this.UnDocteur, this.UnJourUnHoraire, this.UnPatient);
        }

        public override string? ToString()
        {
            if (ADomicile)
            {
                if (EstDocteurTraitant)
                {
                    return $"le docteur traitant {UnDocteur.UnNom} s'occupe du patient {UnPatient.Nom} a domicile le {UnJourUnHoraire}";
                }

                return $"le docteur {UnDocteur.UnNom} s'occupe du patient {UnPatient.Nom} a domicile le {UnJourUnHoraire}";
            }
            if (EstDocteurTraitant)
            {
                return $"le docteur traitant {UnDocteur.UnNom} s'occupe du patient {UnPatient.Nom} le {UnJourUnHoraire}";
            }
            return $"le docteur {UnDocteur.UnNom} s'occupe du patient {UnPatient.Nom} le {UnJourUnHoraire}";
        }

        public static bool operator ==(Consultation? left, Consultation? right)
        {
            return EqualityComparer<Consultation>.Default.Equals(left, right);
        }

        public static bool operator !=(Consultation? left, Consultation? right)
        {
            return !(left == right);
        }

        public double CalculePrixConsultation()
        {
            double res = UnDocteur.DonneSonTarif();
            if (UnPatient.Age <= AGE_MAX_TRES_JEUNE_ENFANT)
            {
                res += SUPP_TRES_JEUNE_ENFANT;
            }
            else if (UnPatient.Age <= AGE_MAX_JEUNE_ENFANT)
            {
                res += SUPP_JEUNE_ENFANT;
            }
            if (UnJourUnHoraire.DayOfWeek == DayOfWeek.Sunday)
            {
                res += SUPP_DIMANCHE;
            }
            if (ADomicile)
            {
                res += SUPP_DEPLACEMENT;
            }
            return res;
        }

        public double CalculeRemboursementSecu()
        {
            double res = this.CalculePrixConsultation();
            if (EstDocteurTraitant)
            {
                return TAUX_REMBOURSEMENT_DOC_TRAITANT * res;
            }
            return TAUX_REMBOURSEMENT_DOC_NON_TRAITANT * res;
        }
    }
}
