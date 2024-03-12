namespace GestionZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> lesAnimaux = new List<Animal>();
            lesAnimaux.Add(new Elephant(SexeAnimal.Masculin, "Simon", 1988, 200, 2.54, Continent.Afrique));
            lesAnimaux.Add(new Elephant(SexeAnimal.Feminin, "Feyza", 2018, 150, 1.7, Continent.Asie));
            lesAnimaux.Add(new Girafe(SexeAnimal.Feminin, "Sophie", 2004,1000, 4.2));
            lesAnimaux.Add(new Girafe(SexeAnimal.Masculin, "Lucas", 2022, 1000, 4.2));
            lesAnimaux.Add(new Serpent(SexeAnimal.Masculin, "Kaa", 2004, 20,3,EspeceSerpent.A_sonette,true));
            lesAnimaux.Add(new Ours(SexeAnimal.Masculin, "Bouba", 2004, 200, 2.40, EspeceOurs.Brun));

            Zoo monZoo = new Zoo(lesAnimaux);


            String choix;
            do
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("MENU ZOO");
                Console.WriteLine("-------------------------");
                Console.WriteLine("0. Quitter");
                Console.WriteLine("1. Presentation des animaux");
                Console.WriteLine("2. Cri des animaux");
                Console.WriteLine("3. Repas d'un animal");
                Console.WriteLine("4. Tuerie de carnivore");
                Console.WriteLine("5. Suppression d'un animal");
                Console.WriteLine("6. Trier les animaux par age");
                Console.WriteLine("-------------------------");
                choix = Console.ReadLine();
                Console.WriteLine("-------------------------");
                switch (choix)
                {
                    case "0":
                        Console.WriteLine("Le zoo vous souhaite une bonne journée");
                        break;
                    case "1":
                        Console.WriteLine("LES HABITANTS DU ZOO");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine(monZoo.PresenteSesAnimaux());
                        break;
                    case "2":
                        Console.WriteLine("CRIS");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine(monZoo.FaitCrierSesAnimaux());
                        break;
                    case "3":
                        Console.WriteLine("REPAS");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Quel animal ?");
                        String nom = Console.ReadLine();
                        Animal a = monZoo.Recherche(nom.ToUpper());
                        if (a == null)
                            Console.WriteLine(nom + " n'existe pas.");
                        else
                        {
                            Console.WriteLine(monZoo.NourritUnAnimal(a));
                        }
                        break;
                    case "4":
                        Console.WriteLine("TUERIE DE CARNIVORE");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Quel animal ?");
                        String nomCarnivore = Console.ReadLine();
                        Animal carnivore = monZoo.Recherche(nomCarnivore.ToUpper());
                        Console.WriteLine(monZoo.Tuerie(carnivore));
                        break;
                    case "5":
                        Console.WriteLine("SUPRESSION");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Quel animal ?");
                        nom = Console.ReadLine();
                        Animal animalASupprimer = monZoo.Recherche(nom.ToUpper());
                        if (animalASupprimer == null)
                            Console.WriteLine(nom + " n'existe pas.");
                        else
                        {
                            monZoo.SupprimeAnimal(animalASupprimer);
                        }
                        break;
                    case "6":
                        Console.WriteLine("DU PLUS JEUNE AU PLUS VIEUX");
                        Console.WriteLine("-------------------------");
                        monZoo.TrieParAge();
                        Console.WriteLine(monZoo.PresenteSesAnimaux());
                        break;
                    default:
                        Console.WriteLine("Mauvais choix !");
                        break;
                }
                Console.WriteLine("appuie sur une touche");
                Console.ReadLine();
                Console.Clear();
            }
            while (!choix.Equals("0"));
        }
    }
}