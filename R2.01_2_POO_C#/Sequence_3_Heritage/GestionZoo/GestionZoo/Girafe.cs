using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    internal class Girafe : Animal, IHerbivore
    {
        public const int AGE_ADULTE = 4;

        public Girafe(SexeAnimal sexe, string nom, int anneeNaissance, double poids, double taille) : base(sexe, nom, anneeNaissance, poids, taille)
        {
        }

        public override string Cri()
        {
            if (EstAdulte())
            {
                return "MEEEEEEEEEE";
            }
            return "Meee";
        }

        public override bool EstAdulte()
        {
            return Age > AGE_ADULTE;
        }

        public string HerbePreferee()
        {
            if (Age < 2)
            {
                return "lait maternel";
            }
            return "acacia";
        }

        public double QteHerbeJour()
        {
            return Poids*0.05;
        }

        public override string? ToString()
        {
            return base.ToString() + "\nNous avons là une belle girafe";
        }
    }
}
