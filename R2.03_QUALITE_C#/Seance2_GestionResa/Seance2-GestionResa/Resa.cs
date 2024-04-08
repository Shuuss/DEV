using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;


namespace GestionReservations
{
    public enum Hotels { PLAZZA = 0, RIVIERA = 1 };
    public enum Voitures { ORDINAIRE = 0, LUXE = 1, AUCUNE = 2 };
    public class Resa
    {
        // Dans le code , on préfixe  explicitement par :
        //  - this : les champs d'instances (les champs appartenant à l'objet ) et les appels aux méthodes d'instance
        //  - Resa : les champs statiques (les champs appartement à la classe)
        //  - rien : les variables locales et paramètres

        public static double PRIX_VOL = 500;
        public static double[] PRIX_HOTELS = new double[] { 50, 80 };
        public static double[,] PRIX_VOITURES = new double[,] { { 29, 27,0 }, { 33, 30,0 } };


        private DateTime dateDepart;
        private DateTime dateRetour;
        private int nbPersonnes;
        private Hotels choixHotel;
        private Voitures choixVoiture;
        private int nbJoursVoiture;
        private String emailClient;

        public Resa(DateTime dateDepart, DateTime dateRetour, int nbPersonnes, Hotels choixHotel, string emailClient)
            : this(dateDepart, dateRetour, nbPersonnes, choixHotel, emailClient, Voitures.AUCUNE, 0)
        { } // ici réutilisation du constructeur ci-dessous ! évite de copier coller le code

        public Resa(DateTime dateDepart, DateTime dateRetour, int nbPersonnes, Hotels choixHotel, string emailClient, Voitures choixVoiture, int nbJoursVoiture)
        {
         
            this.DateDepart = dateDepart;
            this.DateRetour = dateRetour;
            this.NbPersonnes = nbPersonnes;
            this.ChoixHotel = choixHotel;
            this.ChoixVoiture = choixVoiture;
            this.NbJoursVoiture = nbJoursVoiture;
            this.EmailClient = emailClient;
        }


        public DateTime DateDepart
        {
            get
            {
                return this.dateDepart;
            }

            set
            {
                
                this.dateDepart = value;
            }
        }
        public DateTime DateRetour
        {
            get
            {
                return this.dateRetour;
            }

            set
            {

                if (value<this.DateDepart)
                {
                    throw new ArgumentException();
                }
                this.dateRetour = value;

            }
        }

        public int NbPersonnes
        {
            get
            {
                return this.nbPersonnes;
            }

            set
            {
                if (value < 1)
                    throw new ArgumentException("pb il faut au moins 1 personne ");
                this.nbPersonnes = value;
            }
        }



        public Hotels ChoixHotel
        {
            get
            {
                return this.choixHotel;
            }

            set
            {
                this.choixHotel = value;
            }
        }

        public Voitures ChoixVoiture
        {
            get
            {
                return this.choixVoiture;
            }

            set
            {
                if (NbJours==0 && value != Voitures.AUCUNE)
                {
                    throw new ArgumentException();
                }
                this.choixVoiture = value;
            }
        }



        public int NbJoursVoiture
        {
            get
            {
                return this.nbJoursVoiture;
            }

            set
            {
             
                if (value < 0)
                    throw new ArgumentException("nb jours de voiture doit être >= 0 ");
                if (value == 0 && this.ChoixVoiture != Voitures.AUCUNE)
                {
                    throw new ArgumentException();
                }
                if (value>0 && this.choixVoiture == Voitures.AUCUNE)
                {
                    throw new ArgumentException();
                }
                if (value > NbJours)
                    throw new ArgumentException();
                this.nbJoursVoiture = value;
            }
        }

        public string EmailClient
        {
            get
            {
                return this.emailClient;
            }

            set
            {
                EmailAddressAttribute verifEmail = new EmailAddressAttribute();
                if (!verifEmail.IsValid(value))
                    throw new ArgumentException("Email non valide");
                this.emailClient = value;
            }
        }

        public int NbJours
        {
            get
            {
                int nbJours = 0;
                TimeSpan duree = this.DateRetour - this.DateDepart;
                nbJours = (int)Math.Floor(duree.TotalDays);
                return nbJours;
            }
        }

        public int NbNuits
        {
            get
            {
                return NbJours - 1;
            }
        }

    

    public double CalculePrixVol()
        {
            return this.NbPersonnes * Resa.PRIX_VOL;
        }
        public double CalculePrixHotel()
        {
            double prix = Resa.PRIX_HOTELS[(int)this.ChoixHotel]  * this.NbJours;
            return prix;

        }
        public double CalculePrixVoiture()
        {
            double prix = 0;
            if (NbJoursVoiture != 0)
                prix = Resa.PRIX_VOITURES[(int)this.ChoixHotel, (int)this.ChoixVoiture] * this.NbJoursVoiture;

            return prix;

        }

        public double CalculePrixTotal()
        { return this.CalculePrixVol() + this.CalculePrixHotel(); }

        public override bool Equals(object obj)
        {
            return obj is Resa resa &&
                   this.DateDepart == resa.DateDepart &&
                   this.EmailClient == resa.EmailClient;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.DateDepart, this.DateRetour, this.EmailClient);
        }

        public override string ToString()
        {
            String txt = "------------------------------------\n" + "RESA " + this.ChoixHotel;
            if (this.NbJoursVoiture != 0)
                txt += " AVEC VOITURE " + this.ChoixVoiture;

            txt += "\n" + "------------------------------------\n" +
               "Client : " + this.EmailClient + "\n" +
               "Date départ : " + this.DateDepart.ToShortDateString() + "\n" +
               "Date retour : " + this.DateRetour.ToShortDateString() + "\n" +
               "Nb personnes : " + this.NbPersonnes + "\n";

            if (this.NbJoursVoiture != 0)
                txt += "Nb jours réservés pour la voiture  : " + this.NbJoursVoiture + "\n";

            return txt;
        }

        public static bool operator ==(Resa left, Resa right)
        {
            return EqualityComparer<Resa>.Default.Equals(left, right);
        }

        public static bool operator !=(Resa left, Resa right)
        {
            return !(left == right);
        }


    }
}
