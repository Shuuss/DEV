using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Association
{
    internal class Tache
    {
        public static readonly double TAUX_MAJORATION_TACHE_COMPLEXE= 0.2;
        public static readonly int NB_HEURES_JOUR = 7;

        private string nom;
        private TimeSpan duree;
        private bool complexe;
        private Salarie unSalarie;

        public Tache( string nom, TimeSpan duree,bool complexe, Salarie unSalarie)
        {
            this.Complexe = complexe;
            this.Duree = duree;
            this.Nom = nom;
            this.UnSalarie = unSalarie;
        }

        public Tache(string nom, TimeSpan duree, Salarie unSalarie):this(nom,duree,false,unSalarie)
        {

        }

        public Tache(string nom, TimeSpan duree, bool complexe, string nomSalarie, string prenomSalarie, int nbAnneesSalarie)
        {
            this.Complexe = complexe;
            this.Duree = duree;
            this.Nom = nom;
            this.UnSalarie = new Salarie(nomSalarie,prenomSalarie,nbAnneesSalarie);
        }

        public Tache(string nom, TimeSpan duree, string nomSalarie, string prenomSalarie, int nbAnneesSalarie) : this(nom, duree, false, nomSalarie, prenomSalarie, nbAnneesSalarie)
        {

        }

        public bool Complexe
        {
            get
            {
                return complexe;
            }

            set
            {
                complexe = value;
            }
        }

        public TimeSpan Duree
        {
            get
            {
                return duree;
            }

            set
            {
                duree = value;
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

        internal Salarie UnSalarie
        {
            get
            {
                return this.unSalarie;
            }

            set
            {
                this.unSalarie = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Tache tache &&
                   this.Complexe == tache.Complexe &&
                   this.Duree.Equals(tache.Duree) &&
                   this.Nom == tache.Nom &&
                   EqualityComparer<Salarie>.Default.Equals(this.UnSalarie, tache.UnSalarie);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Complexe, this.Duree, this.Nom, this.UnSalarie);
        }

        public double CalculeCoutTache()
        {
            double res = 0;
            res += Duree.Days * NB_HEURES_JOUR * UnSalarie.DonneCoutHoraire();
            res += Duree.Hours * UnSalarie.DonneCoutHoraire();
            if (complexe)
            {
                res += res * TAUX_MAJORATION_TACHE_COMPLEXE;
            }
            return res;
        }

        public override string? ToString()
        {
            return $"Nom : {Nom}" +
                $"\nDuree : {Duree}" +
                $"\nSalarie : \n{UnSalarie}" +
                $"\nComplexe : {Complexe}" +
                $"\nCout : {this.CalculeCoutTache()}";
        }
    }
}
