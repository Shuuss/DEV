namespace Exo2_FormatCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pathData = @"data\Scores.csv";
            // ou String pathData = "data\\joueurs.txt";
            // liste pour charger les données du fichier en mémoire
            List<Score> lesScores = new List<Score>();
            // Chargement des données
            try
            {
                StreamReader reader = new StreamReader(pathData);
                // ou StreamReader reader = new StreamReader(pathData, System.Text.Encoding.UTF8);
                while (!reader.EndOfStream) // reader.EndOfStream == false
                {
                    String? ligne = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(ligne))
                    {
                        String[] data = ligne.Split(';');
                        Score unScore = new Score(int.Parse(data[0]), data[1]);
                        lesScores.Add(unScore);
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Probleme avec le fichier \n" + e);
                Environment.Exit(2);
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

            // Enregistrement des données en mémoire dans le fichier
            try
            {
                StreamWriter writer = new StreamWriter(pathData);
                foreach (Score unScore in lesScores)
                {
                    writer.WriteLine($"{unScore.NbPoints};{unScore.Prenom}");
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Probleme avec le fichier \n" + e);
                Environment.Exit(2);
            }
        }
    }
}