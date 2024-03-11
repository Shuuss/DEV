using System.Text;

namespace TD1_Association
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            List<Salarie> lesSalaries = new List<Salarie>();
            lesSalaries.Add(new Salarie("Ralon", "Mat", 2));
            lesSalaries.Add(new Salarie("Moula", "Franck", 6));
            lesSalaries.Add(new Salarie("Rapin", "José", 12));

            Console.WriteLine("EXERCICE 1\n-----------------------------");
            foreach (Salarie s in lesSalaries)
            {
                Console.WriteLine(s + "\n-----------------------------");
            }

            
            List<Tache> lesTaches = new List<Tache>();
            lesTaches.Add(new Tache("Cahier des charges", new TimeSpan(10, 0, 0, 0), lesSalaries[2]));
            lesTaches.Add(new Tache("Creation Script SQL", new TimeSpan(6, 0, 0), lesSalaries[0]));
            lesTaches.Add(new Tache("Définition architecture", new TimeSpan(5, 4, 0, 0), true, lesSalaries[1]));

            Console.WriteLine("\n\n\nEXERCICE 2\n-----------------------------");
            foreach (Tache t in lesTaches)
            {
                Console.WriteLine(t + "\n-----------------------------");
            }


            Projet unProjet = new Projet("Projet super bien");
            foreach (Tache t in lesTaches)
            {
                unProjet.AjouteTache(t);
            }
            Console.WriteLine($"\n\n\nEXERCICE 3" +
                $"\n-----------------------------" +
                $"\nINFOS PROJET" +
                $"\n-----------------------------" +
                $"\nCOUT TOTAL du projet : {unProjet.CalculeCoutProjet()} euros" +
                $"\nPourcentage réalisé par des juniors : {unProjet.CalculePourcentageTachesRealiseesPar(Qualification.Junior)} %" +
                $"\nNb de Taches complexes : {unProjet.RechercheTacheComplexes().Count}" +
                $"\n-----------------------------");

            TriTachesParDuree(lesTaches);
            Console.WriteLine("\n\n\nTri taches par durée\n-----------------------------");
            foreach (Tache t in lesTaches)
            {
                Console.WriteLine(t + "\n-----------------------------");
            }
        }

        public static void TriTachesParDuree(List<Tache> desTaches)
        {
            desTaches.Sort((x, y) => (x.Duree).CompareTo(y.Duree));
        }
    }
}