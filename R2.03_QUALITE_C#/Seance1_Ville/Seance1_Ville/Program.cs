using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Seance1_Ville
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Ville> lesVilles = new List<Ville>();
            lesVilles.Add(new Ville("74000", "Annecy", 128199, 66.93));
            lesVilles.Add(new Ville("74200", "Thonon", 35241, 16.21));
            lesVilles.Add( new Ville("73000", "Chambery", 58833, 20.99));
            lesVilles.Add(new Ville("73200", "Albertville", 19214, 17.54));
            //Array.Sort(lesVilles);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine(" MENU");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("0.quitter");
                Console.WriteLine("1.Afficher toutes les  villes");
                Console.WriteLine("2.Afficher les villes d’un département ");
                Console.WriteLine("3.Afficher une ville ");
                Console.WriteLine("4.Voir la plus grande ville");
                Console.WriteLine("5.Voir la ville ayant la plus grande densité");
                Console.WriteLine("6.Voir la ville ayant la plus grande superficie");

                int choix = Program.SaisieNb(0, 6);
                if (choix == 0)
                    break;
                switch (choix)
                {
                    case 1: 
                        Program.Affiche(lesVilles);
                        break;

                    case 2:
                        Console.WriteLine("Entrez un departement : (1-95)");
                        int dep = Program.SaisieNb(1, 95);
                        Program.Affiche(lesVilles, dep);
                        break;

                    case 3:
                        Console.WriteLine("Entrez le nom de la ville");
                        String nom = Console.ReadLine();
                        Program.AfficheUneVille(lesVilles, nom);
                        break;

                    case 4: 
                        Program.AfficheLaPlusGrande(lesVilles); 
                        break;

                    case 5:
                        Program.AfficheLaPlusGrandeDensite(lesVilles); 
                        break;

                    case 6: 
                        Program.AfficheLaPlusGrandeSuperficie(lesVilles); 
                        break;
                }
                Console.ReadLine();

            }
        }

        public static int SaisieNb(int min, int max)
        {
            String saisie = Console.ReadLine();
            int nb;
            while (!(int.TryParse(saisie, out nb) && nb >= min && nb <= max))
            {
                Console.WriteLine("Erreur de saisie.");
                Console.WriteLine($"Choix compris entre {min} et {max}:");
                saisie = Console.ReadLine();
            }
            return nb;
        }

        private static void AfficheUneVille(List<Ville> lesVilles, string nom)
        {
            Console.WriteLine("-----------------------------");
            for (int i = 0; i < lesVilles.Count; i++)
            {
                if (lesVilles[i].Nom.ToUpper() == nom.ToUpper())
                {
                    Console.WriteLine(lesVilles[i]);
                }
            }
        }

        private static void AfficheLaPlusGrandeDensite(List <Ville> lesVilles)
        {

            Console.WriteLine("-----------------------------");
            Console.WriteLine("LA VILLE LA PLUS DENSE");
            Console.WriteLine("-----------------------------");
            Ville max = lesVilles[0];
            for (int i = 1; i < lesVilles.Count; i++)
            {
                if (lesVilles[i].EstPlusDense(max))
                    max = lesVilles[i];
            }
            Console.WriteLine(max);

        }

        private static void AfficheLaPlusGrandeSuperficie( List <Ville> lesVilles)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("LA VILLE AYANT LE PLUS GRANDE SUPERFICIE");
            Console.WriteLine("-----------------------------");
            Ville max = lesVilles[0];
            for (int i = 1; i < lesVilles.Count; i++)
            {
                if (lesVilles[i].APlusDeSuperficie(max))
                    max = lesVilles[i];
            }
            Console.WriteLine(max);
        }

        public static void Affiche(List<Ville> lesVilles, int dep)
        {
            int nb = 0;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("LES VILLES DU " + dep);
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < lesVilles.Count; i++)
            {
                if (lesVilles[i].Departement == dep)
                {
                    Console.WriteLine(lesVilles[i]);
                    Console.WriteLine("--------------");
                    nb++;
                }

            }
            if (nb == 0)
                Console.WriteLine("Aucune ville trouvee pour ce departement");

        }

        public static void Affiche(List<Ville> lesVilles)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("TOUTES LES VILLES");
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < lesVilles.Count; i++)
            {
                Console.WriteLine(lesVilles[i]);
                Console.WriteLine("--------------");

            }

        }

        public static void AfficheLaPlusGrande(List<Ville> lesVilles)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("LA PLUS GRANDE VILLE");
            Console.WriteLine("-----------------------------");
            Ville max = lesVilles[0];
            for (int i = 1; i < lesVilles.Count; i++)
            {
                if (lesVilles[i] > max)
                    max = lesVilles[i];

            }
            Console.WriteLine(max);

        }

      

    }
}
