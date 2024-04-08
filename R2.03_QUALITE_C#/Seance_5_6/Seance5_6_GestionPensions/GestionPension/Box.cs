namespace GestionPension
{
    public class Box
    {
        private int numero;
        private bool estIndividuel;
        private bool avecTerrasse;

        public const int NB_PLACES_MAX_PAR_BOX = 2;
        public const double SUPPLEMENT_TERRASSE = 8;
        public const double TARIF_BOX = 18;
        public const double TARIF_BOX_INDIVIDUEL = 28;

        public Box(int numero, bool estIndividuel, bool avecTerrasse)
        {
            this.Numero = numero;
            this.EstIndividuel = estIndividuel;
            this.AvecTerrasse = avecTerrasse;
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                numero = value;
            }
        }

        public bool EstIndividuel
        {
            get
            {
                return estIndividuel;
            }

            set
            {
                estIndividuel = value;
            }
        }

        public bool AvecTerrasse
        {
            get
            {
                return this.avecTerrasse;
            }

            set
            {
                this.avecTerrasse = value;
            }
        }

        public double CalculePrixBase()
        {
            double res = 0;
            if (EstIndividuel)
            {
                res += TARIF_BOX_INDIVIDUEL;
            }
            else
            {
                res += TARIF_BOX;
            }
            if (AvecTerrasse)
            {
                res += SUPPLEMENT_TERRASSE;
            }
            return res;
        }
    }
}