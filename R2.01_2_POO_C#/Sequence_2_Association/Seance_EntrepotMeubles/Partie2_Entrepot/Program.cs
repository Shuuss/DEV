using Newtonsoft.Json;
using Partie1_GestionStocks;

namespace Partie2_Entrepot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pathName = "stocks.json";
            Entrepot entrepot = new Entrepot(pathName);
            bool encore = true;
            while (encore)
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("0.Quitter");
                Console.WriteLine("1.Voir tous les stocks");
                Console.WriteLine("2.Voir les stocks épuisés ");
                Console.WriteLine("3.Info stocks : montant et volume ");
                Console.WriteLine("4.Voir/modifier un stock ");
                Console.WriteLine("5.Enregistrer tous les stocks ");
                Console.WriteLine("---------------------");
                int rep = SaisieInt(0, 5);
                switch (rep)
                {
                    case 0: encore = false; break;
                    case 1:
                        
                            Console.WriteLine(entrepot.TousLesStocksToString());
                        break;
                    case 2:
                        Console.WriteLine("---------------------");
                        Console.WriteLine("TOUS LES STOCKS EPUISES");
                        Console.WriteLine("---------------------");
                        List<Stock> stocksEpuises = entrepot.StocksEpuises();
                        if (stocksEpuises.Count >= 0)
                        {
                            Console.WriteLine("Aucun stock n'est épuisé");
                            Console.WriteLine("---------------------");
                        }
                        else
                        {
                            foreach (Stock stock in stocksEpuises)
                            {
                                if (stock.LaQuantite <= 0)
                                {
                                    Console.WriteLine(stock.ToString());
                                    Console.WriteLine("---------------------");
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(entrepot.InfoStocks());

                        break;
                    case 4:
                        entrepot.ModificationStock();
                       
                        break;
                    case 5:
                        entrepot.Sauvegarde();
                        break;
                }
                // pour faire une pause avant le clear
                Console.ReadLine();
            }

            // SAUVEGARDE DES STOCKS : A FAIRE
        }
        public static int SaisieInt(int min, int max)
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