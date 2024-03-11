using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1_Association
{
    internal class Projet
    {
        private List<Tache> desTaches;
        private string nom;

        public Projet(string nom)
        {
            this.Nom = nom;
            this.DesTaches = new List<Tache>();
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

        internal List<Tache> DesTaches
        {
            get
            {
                return desTaches;
            }

            set
            {
                desTaches = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Projet projet &&
                   this.Nom == projet.Nom &&
                   EqualityComparer<List<Tache>>.Default.Equals(this.DesTaches, projet.DesTaches);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Nom, this.DesTaches);
        }

        public void AjouteTache(Tache uneTache)
        {
            DesTaches.Add(uneTache);
        }

        public double CalculeCoutProjet()
        {
            double res = 0;
            foreach (Tache t in DesTaches)
            {
                res += t.CalculeCoutTache();
            }
            return res;
        }

        public double CalculePourcentageTachesRealiseesPar(Qualification qualification)
        {
            int cpt = 0;
            foreach (Tache t in DesTaches)
            {
                if (t.UnSalarie.DonneQualification() == qualification)
                {
                    cpt++;
                }
            }
            return Math.Round(cpt*100/(double)DesTaches.Count,2);
        }

        public List<Tache> RechercheTacheComplexes()
        {
            List<Tache> res = new List<Tache>();
            foreach (Tache t in DesTaches)
            {
                if (t.Complexe)
                {
                    res.Add(t);
                }
            }
            return res;
        }
    }
}
