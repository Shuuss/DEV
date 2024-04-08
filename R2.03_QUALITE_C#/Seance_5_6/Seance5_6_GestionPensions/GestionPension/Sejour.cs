using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;

namespace GestionPension
{
    public class Sejour
    {
        private DateTime premierJour;
        private DateTime dernierJour;
        private Box unBox;
        private Chien unChien;

        public const double PRIX_NOURRITURE_GROS_CHIEN = 10;
        public const double PRIX_NOURRITURE_MOYEN_CHIEN = 6;
        public const double PRIX_NOURRITURE_PETIT_CHIEN = 3;

        public Sejour(DateTime premierJour, DateTime dernierJour, Box unBox, Chien unChien)
        {
            this.PremierJour = premierJour;
            this.DernierJour = dernierJour;
            this.UnBox = unBox;
            this.UnChien = unChien;
        }

        public DateTime PremierJour
        {
            get
            {
                return premierJour;
            }

            set
            {
                premierJour = value;
            }
        }

        public DateTime DernierJour
        {
            get
            {
                return dernierJour;
            }

            set
            {
                if (value<=this.PremierJour)
                {
                    throw new ArgumentException();
                }
                dernierJour = value;
            }
        }

        public Box UnBox
        {
            get
            {
                return unBox;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentException();
                }
                unBox = value;
            }
        }

        public Chien UnChien
        {
            get
            {
                return this.unChien;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentException();
                }
                this.unChien = value;
            }
        }

        public double CalculePrixBox()
        {
            return UnBox.CalculePrixBase()*(DernierJour-PremierJour).TotalDays;
        }

        public double CalculeNourriture()
        {
            double res;
            if (UnChien.DonneCategorie()==Chien.Categorie.Petit)
            {
                res = PRIX_NOURRITURE_PETIT_CHIEN;
            }
            else if (UnChien.DonneCategorie() == Chien.Categorie.Moyen)
            {
                res = PRIX_NOURRITURE_MOYEN_CHIEN;
            }
            else
            {
                res = PRIX_NOURRITURE_GROS_CHIEN;
            
            }
            return res * (DernierJour - PremierJour).TotalDays;
        }

        public double CalculePrixTotal()
        {
            return CalculePrixBox() + CalculeNourriture();
        }
    }
}