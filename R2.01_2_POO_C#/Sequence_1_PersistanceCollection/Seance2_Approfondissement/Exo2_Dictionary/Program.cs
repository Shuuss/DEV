using Newtonsoft.Json;

namespace Exo2_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pathData = @"regions.csv";

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

            Dictionary<String, Departement> lesDepartements = new Dictionary<string, Departement>();
            try
            {
                String contenuFichier = File.ReadAllText(@"departementsExo2.json");
                lesDepartements = JsonConvert.DeserializeObject<Dictionary<string,Departement>>(contenuFichier);
            }
            catch (Exception e) { Console.WriteLine(e); }

            foreach  (Departement departement in lesDepartements.Values)
            {
                Console.WriteLine(departement.ToString());
            }

            int choix;
            int cpt;
            String numRegion;
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
                switch (choix)
                {
                    case 0: break;
                    case 1:
                        Console.WriteLine("Numéro du departement ?");
                        String numDep = Console.ReadLine();
                        Console.WriteLine("----------------------------------------------");
                        lesDepartements.TryGetValue(numDep, out Departement departementOption1);
                        Console.WriteLine(departementOption1.ToString());
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
                        List<Departement> res = new List<Departement>();
                        foreach (Departement dep in lesDepartements.Values)
                        {
                            if (dep.Region == lesRegions[int.Parse(numRegion) - 1])
                            {
                                res.Add(dep);
                            }
                        }    
                        foreach (Departement departement in res)
                        {
                            Console.WriteLine(departement.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("----------------------");
                        lesDepartements.TryGetValue("1", out Departement departementOption3_1);
                        double minSuperficie = departementOption3_1.Superficie;
                        double maxSuperficie = departementOption3_1.Superficie;
                        double minPopulation = departementOption3_1.Population;
                        double maxPopulation = departementOption3_1.Population; ;
                        double moyenneSuperficie = 0;
                        double moyennePopulation = 0;

                        foreach (Departement departementOption3 in lesDepartements.Values)
                        {
                            if (departementOption3.Superficie < minSuperficie)
                            {
                                minSuperficie = departementOption3 .Superficie;
                            }
                            if (departementOption3.Superficie > maxSuperficie)
                            {
                                maxSuperficie = departementOption3.Superficie;
                            }
                            if (departementOption3.Population < minPopulation)
                            {
                                minPopulation = departementOption3.Population;
                            }
                            if (departementOption3.Population > maxPopulation)
                            {
                                maxPopulation = departementOption3.Population;
                            }
                            moyenneSuperficie += departementOption3.Superficie;
                            moyennePopulation += departementOption3.Population;
                        }

                        moyenneSuperficie /= lesDepartements.Count;
                        moyennePopulation /= lesDepartements.Count;

                        Console.WriteLine($"Superficie moyenne : {Math.Round(moyenneSuperficie)} ( min : {minSuperficie} - max : {maxSuperficie} )");
                        Console.WriteLine($"Population moyenne : {Math.Round(moyennePopulation)} ( min : {minPopulation} - max : {maxPopulation} )");
                        break;
                    case 4:
                        Dictionary<String, Departement> lesDepartementsTri = lesDepartements.OrderBy(x => x.Value.Population).ToDictionary(x => x.Key, x => x.Value);
                        Console.WriteLine("les 10 départements les plus habités\n----------------------------");
                        cpt = 0;
                        int length = lesDepartementsTri.Count-1;
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"{i + 1}.{lesDepartementsTri.ElementAt(length-i).Value.Nom}-{lesDepartementsTri.ElementAt(length-i).Value.Population}");
                        }
                        break;
                    case 5:
                        lesDepartementsTri = lesDepartements.OrderBy(x => x.Value.Population).ToDictionary(x => x.Key, x => x.Value);
                        Console.WriteLine("les 10 départements les moins habités\n----------------------------");
                        cpt = 0;
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"{i + 1}.{lesDepartementsTri.ElementAt(i).Value.Nom}-{lesDepartementsTri.ElementAt(i).Value.Population}");
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
            int nb = 0; bool ok;
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
            return nb;
        }
    }
}