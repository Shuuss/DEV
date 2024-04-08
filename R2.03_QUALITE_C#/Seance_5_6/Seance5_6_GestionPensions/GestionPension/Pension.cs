namespace GestionPension
{
    public class Pension
    {
        private string nom;
        private List<Box> lesBoxs;
        private List<Sejour> lesSejours;

        public Pension(string nom)
        {
            this.Nom = nom;
            this.LesSejours = new List<Sejour>();
            this.LesBoxs = new List<Box>();
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                this.nom = value;
            }
        }

        public List<Box> LesBoxs
        {
            get
            {
                return lesBoxs;
            }

            set
            {
                lesBoxs = value;
            }
        }

        public List<Sejour> LesSejours
        {
            get
            {
                return this.lesSejours;
            }

            set
            {
                this.lesSejours = value;
            }
        }

        public void AjouteUnSejour(Sejour sejour)
        {
            LesSejours.Add(sejour);
        }
    }
}