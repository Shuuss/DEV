using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetMedical
{
    internal class Agenda
    {
        private List<Consultation> lesConsultations;
        private string pathFichierData;
        private List<Docteur> lesDocteurs;
        private List<Patient> lesPatients;

        public Agenda()
        {
        }

        public Agenda(string pathFichierData)
        {
            this.PathFichierData = pathFichierData; 
            this.LesConsultations = ChargeJson<Consultation>();
            this.LesDocteurs = new List<Docteur>();
            this.LesPatients = new List<Patient>();
            this.LesDocteurs.Add(new Docteur(CategorieDocteur.Generaliste, "Simon"));
            this.LesDocteurs.Add(new Docteur(CategorieDocteur.Specialiste, "Yannick"));
            this.LesDocteurs.Add(new Docteur(CategorieDocteur.Specialiste_Complexe, "Marius"));
            this.LesDocteurs.Add(new Docteur(CategorieDocteur.Specialiste_Tres_Complexe, "Mohamed"));
            this.LesPatients.Add(new Patient("02/01/2004", "Hutrel", "Leo"));
            this.LesPatients.Add(new Patient("12/05/2004", "Abdoulvaid", "Tanguy"));
        }

        public List<Consultation> LesConsultations
        {
            get
            {
                return lesConsultations;
            }

            set
            {
                lesConsultations = value;
            }
        }

        public string PathFichierData
        {
            get
            {
                return this.pathFichierData;
            }

            set
            {
                this.pathFichierData = value;
            }
        }

        public List<Docteur> LesDocteurs
        {
            get
            {
                return lesDocteurs;
            }

            set
            {
                lesDocteurs = value;
            }
        }

        public List<Patient> LesPatients
        {
            get
            {
                return this.lesPatients;
            }

            set
            {
                this.lesPatients = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Agenda agenda &&
                   EqualityComparer<List<Consultation>>.Default.Equals(this.LesConsultations, agenda.LesConsultations) &&
                   this.PathFichierData == agenda.PathFichierData;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LesConsultations, this.PathFichierData);
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(Agenda? left, Agenda? right)
        {
            return EqualityComparer<Agenda>.Default.Equals(left, right);
        }

        public static bool operator !=(Agenda? left, Agenda? right)
        {
            return !(left == right);
        }
        private List<T> ChargeJson<T>()
        {
            List<T> liste = null;
            try
            {
                String contenuFichier = File.ReadAllText(PathFichierData);
                liste = JsonConvert.DeserializeObject<List<T>>(contenuFichier);
            }
            catch (Exception e) { throw; }
            return liste;
        }
        public void SauvegardeJson<T>()
        {
            try
            {
                string result = JsonConvert.SerializeObject(lesConsultations, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(pathFichierData, result);
            }
            catch (Exception e) { throw; }
        }
        public void AjouterConsultation()
        {
            Console.WriteLine("Avec quel docteur voulez vous prendre rendez vous ?");
            string nomDocteur = Console.ReadLine().ToUpper();
            Docteur docteur = new Docteur();
            foreach (Docteur d in LesDocteurs)
            {
                if (d.UnNom.ToUpper() == nomDocteur)
                {
                    docteur = d;
                }
            }
            Console.WriteLine("Etes vous patient chez nous ? (o/n)");
            string estPatient = Console.ReadLine().ToLower();
            while (estPatient != "o" && estPatient != "n")
            {
                Console.WriteLine("répondre o pour oui ou n pour non");
                estPatient = Console.ReadLine().ToLower();
            }
            Patient patient = new Patient();
            if (estPatient == "o")
            {
                Console.WriteLine("Quel est votre nom de famille ?");
                string nomPatient = Console.ReadLine().ToUpper();
                foreach (Patient p in LesPatients)
                {
                    if (p.Nom.ToUpper() == nomPatient)
                    {
                        patient = p;
                    }
                }
            }
            else
            {
                Console.WriteLine("Quel est votre nom de famille ?");
                string nomPatient = Console.ReadLine();
                Console.WriteLine("Quel est votre prénom ?");
                string prenomPatient = Console.ReadLine();
                Console.WriteLine("quelle est votre date de naissance ? (jj/mm/aaaa)");
                string dateNaissancePatient = Console.ReadLine();
                patient = new Patient(dateNaissancePatient, nomPatient, prenomPatient);
                LesPatients.Add(patient);
            }
            Console.WriteLine($"Le docteur {docteur.UnNom} est il votre médecin traitant? (o/n)]");
            string repTraitant = Console.ReadLine().ToLower();
            while (repTraitant != "o" && repTraitant != "n")
            {
                Console.WriteLine("répondre o pour oui ou n pour non");
                repTraitant = Console.ReadLine().ToLower();
            }
            bool estTraitant = false;
            if (repTraitant == "o")
            {
                estTraitant = true;
            }
            Console.WriteLine($"Le docteur {docteur.UnNom} devra se rendre à votre domicile ? (o/n)]");
            string repDomicile = Console.ReadLine().ToLower();
            while (repDomicile != "o" && repDomicile != "n")
            {
                Console.WriteLine("répondre o pour oui ou n pour non");
                repDomicile = Console.ReadLine().ToLower();
            }
            bool estADomicile = false;
            if (repDomicile == "o")
            {
                estADomicile = true;
            }
            Console.WriteLine("A quelle date et quelle heure voulez vous prendre rendez vous? (jj/mm/aaaa hh:mm)");
            string dateEtHeure = Console.ReadLine();
            Consultation nouvelleConsultation = new Consultation(estADomicile, estTraitant, docteur, dateEtHeure, patient);
            LesConsultations.Add(nouvelleConsultation);
        }
        public List<Consultation> ConsultationsDuJour()
        {
            List<Consultation> res = new List<Consultation>();
            foreach (Consultation c in lesConsultations)
            {
                if (c.UnJourUnHoraire.Date == DateTime.Today)
                {
                    res.Add(c);
                }
            }
            return res;
        }
        public List<Consultation> ConsultationsDuJour(DateTime jour)
        {
            List<Consultation> res = new List<Consultation>();
            foreach (Consultation c in lesConsultations)
            {
                if (c.UnJourUnHoraire.Date == jour)
                {
                    res.Add(c);
                }
            }
            return res;
        }
        public void TriParDate()
        {
            lesConsultations.Sort((x, y) => x.UnJourUnHoraire.CompareTo(y.UnJourUnHoraire));
        }
        public void TriParDocteur()
        {
            lesConsultations.Sort((x, y) => x.UnDocteur.UnNom.CompareTo(y.UnDocteur.UnNom));
        }
        public void TriParPrix()
        {
            lesConsultations.Sort((x, y) => (x.CalculePrixConsultation() - x.CalculeRemboursementSecu()).CompareTo((y.CalculePrixConsultation() - y.CalculeRemboursementSecu())));
        }
    }
}
