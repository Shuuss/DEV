using Newtonsoft.Json;

namespace Exo3_FormatJSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Score> lesScores = new List<Score>();
            try
            {
                String contenuFichier = File.ReadAllText("Scores.json");
                lesScores = JsonConvert.DeserializeObject<List<Score>>(contenuFichier);
            }
            catch (Exception e) { Console.WriteLine(e); }

            foreach (Score score in lesScores)
            {
                Console.WriteLine(score.ToString());
            }

            Console.WriteLine("---------------------------------");
            foreach (Score unScore in lesScores)
            {
                Console.WriteLine(unScore.ToString());
            }
            Console.WriteLine("---------------------------------");

            String nbPoints = "";
            while (nbPoints != "s")
            {
                Console.WriteLine("Nouveau Score? s pour stopper");
                nbPoints = Console.ReadLine();
                if (nbPoints != "s")
                {
                    Console.WriteLine("Nouveau prenom?");
                    String prenom = Console.ReadLine();
                    Score score = new Score(int.Parse(nbPoints), prenom);
                    if (lesScores.Contains(score))
                    {
                        Console.WriteLine("Attention, ce score existe déjà");
                    }
                    else
                    {
                        lesScores.Add(score);
                    }
                }
            }
            lesScores.Sort();
            lesScores.Reverse();

            Console.WriteLine("---------------------------------");
            foreach (Score unScore in lesScores)
            {
                Console.WriteLine(unScore.ToString());
            }
            Console.WriteLine("---------------------------------");

            try
            {
                string result = JsonConvert.SerializeObject(lesScores, Formatting.Indented);
                File.WriteAllText("Scores.json", result);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}