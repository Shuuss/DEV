using Newtonsoft.Json;
using System.Xml;

namespace CabinetMedical
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string pathname = "lesConsultations.json";
            Agenda agenda = new Agenda(pathname);

            bool encore = true;
            while (encore)
            {
                Console.Clear();
                Console.WriteLine("0. Quitter et sauvegarder");
                Console.WriteLine("1. Voir toutes consultations ");
                Console.WriteLine("2. Ajouter une consultation");
                Console.WriteLine("3. Voir les consultations du jour");
                Console.WriteLine("4. Voir les Consultations d’un docteur ");
                Console.WriteLine("5. Voir les Consultations Triées par date ");
                Console.WriteLine("6. Voir les Consultations Triées par prix ");
                Console.WriteLine("7. Voir les Consultations Triées par docteur ");
                int.TryParse(Console.ReadLine(), out int rep);
                if (rep < 0 || rep > 7)
                {
                    Console.WriteLine("le nombre doit être entre 0 et 7");
                    continue;
                }
                switch (rep)
                {
                    case 0:
                        encore = false;
                        agenda.SauvegardeJson<Consultation>();
                        break;
                    case 1:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("TOUTES LES CONSULTATIONS");
                        Console.WriteLine("--------------------------------");
                        foreach (Consultation c in agenda.LesConsultations)
                        {
                            Console.WriteLine(c.ToString());
                            Console.WriteLine("--------------------------------");
                        }
                        break;
                    case 2:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("AJOUTER UNE CONSULTATION");
                        Console.WriteLine("--------------------------------");
                        agenda.AjouterConsultation();
                        break;
                    case 3:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("CONSULTATIONS DU JOUR");
                        Console.WriteLine("--------------------------------");
                        foreach  (Consultation c in agenda.ConsultationsDuJour())
                        {
                            Console.WriteLine(c.ToString());
                            Console.WriteLine("--------------------------------");
                        }
                        break;
                    case 4:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("CONSULTATIONS D'UN DOCTEUR");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Quel docteur ?");
                        string nomDocteur = Console.ReadLine().ToUpper();
                        Docteur docteur = new Docteur();
                        foreach (Docteur d in agenda.LesDocteurs)
                        {
                            if (d.UnNom.ToUpper() == nomDocteur)
                            {
                                docteur = d;
                            }
                        }
                        foreach (Consultation c in agenda.LesConsultations)
                        {
                            if (c.UnDocteur == docteur)
                            {
                                Console.WriteLine(c.ToString());
                                Console.WriteLine("--------------------------------");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("TRI PAR DATE");
                        Console.WriteLine("--------------------------------");
                        agenda.TriParDate();
                        break;
                    case 6:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("TRI PAR PRIX");
                        Console.WriteLine("--------------------------------");
                        agenda.TriParPrix();
                        break;
                    case 7:
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("TRI PAR DOCTEUR");
                        Console.WriteLine("--------------------------------");
                        agenda.TriParDocteur();
                        break;

                    default:
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}