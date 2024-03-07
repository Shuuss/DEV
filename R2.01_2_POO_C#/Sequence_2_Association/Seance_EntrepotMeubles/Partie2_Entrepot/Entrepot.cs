using Newtonsoft.Json;
using Partie1_GestionStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Partie2_Entrepot
{
    internal class Entrepot
    {
        private DateTime dateDernierMAJ;
        private List<Stock> lesStocks;
        private string pathName;

        public Entrepot(string pathName)
        {
            this.DateDernierMAJ = DateTime.Now;
            List<Stock> lesInfos = null;
            try
            {
                String contenuFichier = File.ReadAllText(pathName);
                lesInfos = JsonConvert.DeserializeObject<List<Stock>>(contenuFichier);
            }
            catch (Exception e) { throw e; }
            this.LesStocks = lesInfos;
            this.PathName = pathName;
        }

        public DateTime DateDernierMAJ
        {
            get
            {
                return dateDernierMAJ;
            }

            set
            {
                dateDernierMAJ = value;
            }
        }

        public List<Stock> LesStocks
        {
            get
            {
                return lesStocks;
            }

            set
            {
                lesStocks = value;
            }
        }

        public string PathName
        {
            get
            {
                return this.pathName;
            }

            set
            {
                this.pathName = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Entrepot entrepot &&
                   this.DateDernierMAJ == entrepot.DateDernierMAJ &&
                   EqualityComparer<List<Stock>>.Default.Equals(this.LesStocks, entrepot.LesStocks) &&
                   this.PathName == entrepot.PathName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.DateDernierMAJ, this.LesStocks, this.PathName);
        }

        public override string? ToString()
        {
            string res = "---------------\nMEUBLES EN STOCK";
            foreach (Stock stock in LesStocks)
            {
                res += "---------------";
                res += stock.LeMeuble.LaReference;
            }
            return base.ToString();
        }

        public string TousLesStocksToString()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("TOUS LES STOCKS");
            Console.WriteLine("---------------------");
            string res = "";
            foreach (Stock stock in LesStocks)
            {
                res += $"{stock.ToString()}\n---------------------\n";
            }
            return res;
        }

        public List<Stock> StocksEpuises()
        {
            List<Stock> res = new List<Stock>();
            foreach (Stock stock in lesStocks)
            {
                if (stock.LaQuantite <= 0)
                {
                    res.Add(stock);
                }
            }
            return res;
        }

        public string InfoStocks()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("INFO STOCKS");
            Console.WriteLine("---------------------");
            Console.WriteLine("MONTANT");
            Console.WriteLine("---------------------");
            double montantTotal = 0;
            string res = "";
            foreach (Stock stock in lesStocks)
            {
                double montantStock = stock.CalculeMontant();
                res += $"{stock.LeMeuble.LaReference} {stock.LaQuantite} x {stock.LeMeuble.LePrix} = {Math.Round(montantStock, 2)}\n";
                montantTotal += montantStock;
            }
            res += $"---------------------\nMontant total : {Math.Round(montantTotal, 2)} {Meuble.MONNAIE}\n";

            res += "---------------------\n";
            res += "VOLUME\n";
            res += "---------------------\n";
            double volumeTotal = 0;
            foreach (Stock stock in lesStocks)
            {
                double volumeStock = stock.CalculeVolume();
                res += $"{stock.LeMeuble.LaReference} {stock.LaQuantite} x {stock.LeMeuble.CalculeVolume()} = {Math.Round(volumeStock, 2)}\n";
                volumeTotal += volumeStock;
            }
            res += "---------------------\n";
            res += $"Volume total : {Math.Round(volumeTotal, 2)} {Dimension.UNITE_VOLUME}\n";
            return res;
        }

        public void ModificationStock()
        {
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
        }

        public void Sauvegarde()
        {
            try
            {
                String res = JsonConvert.SerializeObject(LesStocks, Formatting.Indented);
                File.WriteAllText(pathName, res);
            }
            catch (Exception e) { throw e; }
            DateDernierMAJ = DateTime.Now;
            Console.WriteLine("---------------------");
            Console.WriteLine($"Les stocks ont bien été enregistrés dans le fichier {pathName}");
        }
    }
}
