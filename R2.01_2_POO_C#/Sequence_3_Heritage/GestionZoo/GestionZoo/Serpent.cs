using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionZoo
{
    public enum EspeceSerpent 
    { 
        Crotale,
        A_sonette,
        Cornu,
        Echidé,
        Autre 
    }

    internal class Serpent : Animal, ICarnivore
    {
        public const int AGE_ADULTE = 2;
        
        private EspeceSerpent espece;
        private bool venimeux;

        public Serpent(SexeAnimal sexe, string nom, int anneeNaissance, double poids, double taille, EspeceSerpent espece, bool venimeux) : base(sexe, nom, anneeNaissance, poids, taille)
        {
            Espece = espece;
            Venimeux = venimeux;
        }

        public EspeceSerpent Espece
        {
            get
            {
                return espece;
            }

            set
            {
                espece = value;
            }
        }

        public bool Venimeux
        {
            get
            {
                return this.venimeux;
            }

            set
            {
                this.venimeux = value;
            }
        }

        public override string Cri()
        {
            if (Espece == EspeceSerpent.Crotale || Espece == EspeceSerpent.A_sonette)
            {
                if (EstAdulte())
                {
                    return "DRIIIIIIIIIIIIIIIIING";
                }
                return "driiing";
            }
            if (Espece == EspeceSerpent.Cornu || Espece == EspeceSerpent.Echidé)
            {
                if (EstAdulte())
                {
                    return "FRRRRRRRRRRRRRRRRRRRRRRRRR";
                }
                return "frrrrrrrrrrrrrr";
            }
            if (EstAdulte())
            {
                return "SSSSSSSSSSSSSSSSSSSSSS";
            }
            return "ssssssssssssss";
        }

        public override bool EstAdulte()
        {
            return Age > AGE_ADULTE;
        }

        public int NbProieSemaine()
        {
            if (Age < 2)
            {
                return 2;
            }
            return 1;
        }

        public string ProiePreferee()
        {
            if (Age<1)
            {
                return "Souriceaux ou équivalents";
            }
            if (Age < 2)
            {
                return "Souris ou équivalents";
            }
            return "Cochon d'inde ou équivalents";
        }

        public override string? ToString()
        {
            if (venimeux)
            {
                return base.ToString()+$"nous avons là un beau serpent {espece} venimeux";
            }
            return base.ToString() + $"nous avons là un beau serpent {espece}";
        }

        public string Tue()
        {
            return "étouffe sa proie";
        }
    }
}
