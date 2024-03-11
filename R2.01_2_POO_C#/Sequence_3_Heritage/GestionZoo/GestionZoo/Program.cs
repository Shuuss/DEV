namespace GestionZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> Zoo = new List<Animal>();
            Zoo.Add(new Elephant(SexeAnimal.Masculin, "Simon", 1988, 200, 2.54, Continent.Afrique));
            Zoo.Add(new Elephant(SexeAnimal.Feminin, "Feyza", 2018, 150, 1.7, Continent.Asie));
            Zoo.Add(new Girafe(SexeAnimal.Feminin, "Sophie", 2004,1000, 4.2));
            Zoo.Add(new Girafe(SexeAnimal.Masculin, "Lucas", 2022, 1000, 4.2));
            Zoo.Add(new Serpent(SexeAnimal.Masculin, "Kaa", 2004, 20,3,EspeceSerpent.A_sonette,true));
            Zoo.Add(new Ours(SexeAnimal.Masculin, "Bouba", 2004, 200, 2.40, EspeceOurs.Brun));

            foreach (Animal animal in Zoo)
            {
                Console.WriteLine(animal);
            }
        }
    }
}