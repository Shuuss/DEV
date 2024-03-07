

using Newtonsoft.Json;

namespace Partie1_GestionStocks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Dimension dimension = new Dimension(200, 120, 55);
            Meuble meubleRAZA = new Meuble(dimension,"RAZA",59.99);
            Stock stockRAZA = new Stock(100, meubleRAZA);

            Stock stockTIKKA = new Stock(120,100,50,45,"TIKKA",45.99);

            Console.WriteLine(stockRAZA.ToString());

            Console.WriteLine(stockTIKKA.CalculeMontant() + " euros");
            Console.WriteLine(stockTIKKA.CalculeVolume() + " " + Dimension.UNITE_VOLUME);*/

            // CHARGEMENT DES STOCKS
            String pathName = "stocks.json";
            List<Stock> lesStocks = null;
            bool encore = true;
            try
            {
                lesStocks = Program.Charge<Stock>(pathName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Probleme lors du chargement des stocks ");
                Console.WriteLine(e);
                Environment.Exit(2);
            }
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
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("TOUS LES STOCKS");
                            Console.WriteLine("---------------------");
                            foreach (Stock stock in lesStocks)
                            {
                                Console.WriteLine(stock.ToString());
                                Console.WriteLine("---------------------");
                            }
                            break;
                        }
                    case 2:
                        Console.WriteLine("---------------------");
                        Console.WriteLine("TOUS LES STOCKS EPUISES");
                        Console.WriteLine("---------------------");
                        int nbStockEpuise = 0;
                        foreach (Stock stock in lesStocks)
                        {
                            if (stock.LaQuantite <= 0)
                            {
                                Console.WriteLine(stock.ToString());
                                Console.WriteLine("---------------------");
                                nbStockEpuise++;
                            }
                        }
                        if (nbStockEpuise == 0)
                        {
                            Console.WriteLine("Aucun stock n'est épuisé");
                            Console.WriteLine("---------------------");
                        }
                        break;
                    case 3:
                        Console.WriteLine("---------------------");
                        Console.WriteLine("INFO STOCKS");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("MONTANT");
                        Console.WriteLine("---------------------");
                        double montantTotal = 0;
                        foreach (Stock stock in lesStocks)
                        {
                            double montantStock = stock.CalculeMontant();
                            Console.WriteLine($"{stock.LeMeuble.LaReference} {stock.LaQuantite} x {stock.LeMeuble.LePrix} = {Math.Round(montantStock,2)}");
                            montantTotal += montantStock;
                        }
                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Montant total : {Math.Round(montantTotal,2)} {Meuble.MONNAIE}");

                        Console.WriteLine("---------------------");
                        Console.WriteLine("VOLUME");
                        Console.WriteLine("---------------------");
                        double volumeTotal = 0;
                        foreach (Stock stock in lesStocks)
                        {
                            double volumeStock = stock.CalculeVolume();
                            Console.WriteLine($"{stock.LeMeuble.LaReference} {stock.LaQuantite} x {stock.LeMeuble.CalculeVolume()} = {Math.Round(volumeStock,2)}");
                            volumeTotal += volumeStock;
                        }
                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Volume total : {Math.Round(volumeTotal,2)} {Dimension.UNITE_VOLUME}");
                        break;
                    case 4:
                        Console.WriteLine("---------------------");
                        Console.WriteLine("MODIFICATION DE STOCK");
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Référence du meuble?");
                        string reference = Console.ReadLine();
                        bool found = false;
                        foreach (Stock stock in lesStocks)
                        {
                            if (stock.LeMeuble.LaReference == reference.ToUpper())
                            {
                                found = true;
                                string choix = "";
                                while (choix != "+" && choix != "-")
                                {
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Voulez vous ajouter ou retirer des meubles? ( + / - )");
                                    choix = Console.ReadLine();
                                }
                                if (choix == "+")
                                {
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Combien de meubles voulez vous ajouter ?");
                                    int.TryParse(Console.ReadLine(), out int quantiteAjoutee);
                                    stock.AjouteStock(quantiteAjoutee);
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine($"Il y a désormais {stock.LaQuantite} meubles {reference.ToUpper()} en stock");
                                }
                                else
                                {
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine("Combien de meubles voulez vous retirer ?");
                                    int.TryParse(Console.ReadLine(), out int quantiteRetiree);
                                    stock.RetireStock(quantiteRetiree);
                                    Console.WriteLine("---------------------");
                                    Console.WriteLine($"Il y a désormais {stock.LaQuantite} meubles {reference.ToUpper()} en stock");
                                }
                            }
                        }
                        if (!found)
                        {
                            throw new ArgumentException("la référence spécifiée ne correspond à aucun meuble");
                        }
                        
                        break;
                    case 5:
                        Sauvegarde<Stock>(lesStocks, pathName);
                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Les stocks ont bien été enregistrés dans le fichier {pathName}");
                        break;
                }
                // pour faire une pause avant le clear
                Console.ReadLine();
            }

            // SAUVEGARDE DES STOCKS : A FAIRE
        }
        public static void AfficheListe(List<Stock> liste)
        {
            foreach (Stock unStock in liste)
                Console.WriteLine(unStock);
        }
        private static List<T> Charge<T>(String pathName)
        {
            List<T> lesInfos = null;
            try
            {
                String contenuFichier = File.ReadAllText(pathName);
                lesInfos = JsonConvert.DeserializeObject<List<T>>(contenuFichier);
            }
            catch (Exception e) { throw e; } 

            return lesInfos;
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
        private static void Sauvegarde<T>(List<T> lesInfos, String pathName)
        {
            try
            {
                String res = JsonConvert.SerializeObject(lesInfos, Formatting.Indented);
                File.WriteAllText(pathName,res);
            }
            catch (Exception e) { throw e; }
        }
    }
}