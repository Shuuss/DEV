namespace Exo1_FormatTxt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pathData = @"data\joueurs.txt";
            // ou String pathData = "data\\joueurs.txt";
            // liste pour charger les données du fichier en mémoire
            List<String> lesJoueurs = new List<string>();
            // Chargement des données
            try
            {
                StreamReader reader = new StreamReader(pathData);
                // ou StreamReader reader = new StreamReader(pathData, System.Text.Encoding.UTF8);
                while (!reader.EndOfStream) // reader.EndOfStream == false
                {
                    String? unJoueur = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(unJoueur))
                        lesJoueurs.Add(unJoueur);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Probleme avec le fichier \n" + e);
                Environment.Exit(2);
            }
            foreach (String unJoueur in lesJoueurs)
            {
                Console.WriteLine(unJoueur);
            }

            String prenom = "";
            while (prenom != "s")
            {
                Console.WriteLine("Nouveau prénom? s pour stopper");
                prenom = Console.ReadLine();
                if (prenom != "s")
                {
                    if (lesJoueurs.Contains(prenom))
                    {
                        Console.WriteLine("Attention, ce prénom existe déjà.");
                    }
                    else
                    {
                        lesJoueurs.Add(prenom);
                    }
                }
            }
            
            lesJoueurs.Sort();

            // Enregistrement des données en mémoire dans le fichier
            try
            {
                StreamWriter writer = new StreamWriter(pathData);
                foreach (String unJoueur in lesJoueurs)
                {
                    writer.WriteLine(unJoueur);
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