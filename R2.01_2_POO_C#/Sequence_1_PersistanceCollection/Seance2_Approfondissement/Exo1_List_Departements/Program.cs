using Newtonsoft.Json;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace Exo1_List_Departements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pathData = @"RessourcesSeance2\regions.csv";
            
            List<String> lesRegions = new List<String>();
            
            try
            {
                StreamReader reader = new StreamReader(pathData);
                while (!reader.EndOfStream)
                {
                    lesRegions.Add(reader.ReadLine());
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Probleme avec le fichier \n" + e);
                Environment.Exit(2);
            }

            List<Departement> lesDepartements = new List<Departement>();
            try
            {
                String contenuFichier = File.ReadAllText(@"RessourcesSeance2\departementsExo1.json");
                lesDepartements = JsonConvert.DeserializeObject<List<Departement>>(contenuFichier);
            }
            catch (Exception e) { Console.WriteLine(e); }

            int choix;
            do
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine(" 0. Quitter");
                Console.WriteLine(" 1. Voir en détail un departement");
                Console.WriteLine(" 2. Voir les départements d'une région ");
                Console.WriteLine(" 3. Voir les stats: superficie et population moyenne, min et max");
                Console.WriteLine(" 4. Voir les 10 départements les plus habités ");
                Console.WriteLine(" 5. Voir les 10 départements les plus grands ");
                Console.WriteLine("----------------------------------------------");
                choix = Program.SaisieInt(0, 5);
                int cpt;
                string numRegion;
                switch (choix)
                {
                    case 0: break;
                    case 1:
                        Console.WriteLine("Numéro du departement ?");
                        String numDep = Console.ReadLine();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine((lesDepartements.Find(x => x.Numero == numDep)).ToString());
                        break;
                    case 2: 
                        Console.WriteLine("----------------------");
                        cpt = 1;
                        foreach (string region in lesRegions)
                        {
                            Console.WriteLine($"{cpt} . {region}");
                            cpt++;
                        }
                        numRegion = Console.ReadLine();
                        List<Departement> res =lesDepartements.FindAll(x => x.Region == lesRegions[int.Parse(numRegion)-1]);
                        foreach (Departement departement in res)
                        {
                            Console.WriteLine(departement.ToString());
                        }
                        break;
                    case 3: 
                        double minSuperficie = lesDepartements[0].Superficie;
                        double maxSuperficie = lesDepartements[0].Superficie;
                        double minPopulation = lesDepartements[0].Population;
                        double maxPopulation = lesDepartements[0].Population;
                        double moyenneSuperficie = lesDepartements[0].Superficie;
                        double moyennePopulation = lesDepartements[0].Population;
                        for (int i = 1; i < lesDepartements.Count; i++)
                        {
                            if (lesDepartements[i].Superficie < minSuperficie)
                            {
                                minSuperficie = lesDepartements[i].Superficie;
                            }
                            if (lesDepartements[i].Superficie > maxSuperficie)
                            {
                                maxSuperficie = lesDepartements[i].Superficie;
                            }
                            if (lesDepartements[i].Population < minPopulation)
                            {
                                minPopulation = lesDepartements[i].Population;
                            }
                            if (lesDepartements[i].Population > maxPopulation)
                            {
                                maxPopulation = lesDepartements[i].Population;
                            }

                            moyenneSuperficie += lesDepartements[i].Superficie;
                            moyennePopulation += lesDepartements[i].Population;
                        }

                        
                        moyenneSuperficie /= lesDepartements.Count;
                        moyennePopulation /= lesDepartements.Count;

                        Console.WriteLine($"Superficie moyenne : {Math.Round(moyenneSuperficie)} ( min : {minSuperficie} - max : {maxSuperficie} )");
                        Console.WriteLine($"Population moyenne : {Math.Round(moyennePopulation)} ( min : {minPopulation} - max : {maxPopulation} )");
                        break;
                    case 4: 
                        lesDepartements.Sort(Departement.CompareDepartementParPopulation);
                        lesDepartements.Reverse();
                        Console.WriteLine("les 10 départements les plus habités\n----------------------------");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"{i+1}.{lesDepartements[i].Nom}-{lesDepartements[i].Population}");
                        } 
                        break;
                    case 5: 
                        lesDepartements.Sort(Departement.CompareDepartementParPopulation);
                        Console.WriteLine("les 10 départements les plus habités\n----------------------------");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"{i+1}.{lesDepartements[i].Nom}-{lesDepartements[i].Population}");
                        } 
                        break;
                }
                if (choix != 0)
                {
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (choix != 0);
            Console.WriteLine("FIN"); 
        }
        
        private static int SaisieInt(int min, int max)
        {
            int nb =0; bool ok;
            String choix = Console.ReadLine();
            do
            {
                ok = true;
                if (!(int.TryParse(choix, out nb) && nb >= min && nb <= max))
                {
                    Console.WriteLine($"Erreur- Choix entre {min} et {max} :");
                    choix = Console.ReadLine();
                    ok = false;
                }
            } while (!ok);
            return nb; }
    }
}