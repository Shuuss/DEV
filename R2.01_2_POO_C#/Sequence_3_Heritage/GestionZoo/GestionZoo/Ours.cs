using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    public enum EspeceOurs
    {
        Polaire,
        Brun,
        Noir
    }

    internal class Ours : Animal, ICarnivore, IHerbivore
    {
        public const int AGE_ADULTE_BRUN = 4;
        public const int AGE_ADULTE_AUTRE = 3;
        
        private EspeceOurs espece;

        public Ours(SexeAnimal sexe, string nom, int anneeNaissance, double poids, double taille, EspeceOurs espece) : base(sexe, nom, anneeNaissance, poids, taille)
        {
            Espece = espece;
        }

        public EspeceOurs Espece
        {
            get
            {
                return this.espece;
            }

            set
            {
                this.espece = value;
            }
        }

        public override string Cri()
        {
            if (EstAdulte())
            {
                return "GRRRRRRRRRRRRRRRRR";
            }
            return "grrrrrrr";
        }

        public override bool EstAdulte()
        {
            if (Espece == EspeceOurs.Brun)
            {
                return Age > AGE_ADULTE_BRUN;
            }
            return Age > AGE_ADULTE_AUTRE;
        }

        public string HerbePreferee()
        {
            return "écorce,feuilles,racines,fruits,baies";
        }

        public int NbProieSemaine()
        {
            return 100;
        }

        public string ProiePreferee()
        {
            return "saumon";
        }

        public double QteHerbeJour()
        {
            return 10;
        }

        public string Tue()
        {
            return "frappe, griffe et mord";
        }
    }
}
