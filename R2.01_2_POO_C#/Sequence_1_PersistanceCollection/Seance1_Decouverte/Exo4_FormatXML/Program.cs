using System.Xml.Serialization;

namespace Exo4_FormatXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Score> lesScores = new List<Score>();
            XmlSerializer xs = new XmlSerializer(typeof(List< Score >));
            try
            {
                StreamReader reader = new StreamReader("Scores.xml");
                lesScores = xs.Deserialize(reader) as List<Score>;
                reader.Close();
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
                StreamWriter writer = new StreamWriter("Scores.xml");
                xs.Serialize(writer, lesScores);
                writer.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            
        }
    }
}