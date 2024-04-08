namespace GestionPension
{
    public class Chien
    {
        private string nom;
        private string nomMaitre;
        private int poids;

        public enum Categorie
        {
            Petit,
            Moyen,
            Gros
        }
        
        public Chien(string nom, string nomMaitre, int poids)
        {
            this.Nom = nom;
            this.NomMaitre = nomMaitre;
            this.Poids = poids;
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
                    throw new ArgumentNullException("il a pas de nom le  chiengue");
                }
                nom = value;
            }
        }

        public string NomMaitre
        {
            get
            {
                return nomMaitre;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("il a pas de maitre le  chiengue");
                }
                nomMaitre = value;
            }
        }

        public int Poids
        {
            get
            {
                return this.poids;
            }

            set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("il a rien dans le bidou le chiengue");
                }
                this.poids = value;
            }
        }

        public Categorie DonneCategorie()
        {
            if (Poids<10)
            {
                return Categorie.Petit;
            }
            if (poids<25)
            {
                return Categorie.Moyen;
            }
            return Categorie.Gros;
        }
    }
}