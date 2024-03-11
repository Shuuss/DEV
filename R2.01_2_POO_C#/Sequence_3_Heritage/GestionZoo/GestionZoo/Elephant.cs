using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    public enum Continent
    { Asie,
      Afrique 
    }

    internal class Elephant : Animal, IHerbivore
    {
        public const int AGE_ADULTE = 13;

        private Continent origine;

        public Elephant(SexeAnimal sexe, string nom, int anneeNaissance, double poids, double taille, Continent origine) : base(sexe, nom, anneeNaissance, poids, taille)
        {
            Origine = origine;
        }

        public Continent Origine
        {
            get
            {
                return this.origine;
            }

            set
            {
                this.origine = value;
            }
        }

        public override string Cri()
        {
            if (EstAdulte())
            {
                return ("HUUUUMMMMM");
            }
            return "huuummmm";
        }

        public override bool EstAdulte()
        {
            return Age > AGE_ADULTE;
        }

        public string HerbePreferee()
        {
            if (Age < 5)
            {
                return "lait maternel";
            }
            if (Origine == Continent.Afrique)
            {
                return "feuillages/arbustes";
            }
            return "herbes";
        }

        public double QteHerbeJour()
        {
            return Poids / 4; ;
        }

        public override string? ToString()
        {
            if (Origine == Continent.Asie)
            {
                return base.ToString() + $"\nEléphant d'Asie avec de petites oreilles sans défenses";
            }
            return base.ToString() + $"\nEléphant d'Afrique avec de grandes oreilles et défenses";
        }
    }
}
