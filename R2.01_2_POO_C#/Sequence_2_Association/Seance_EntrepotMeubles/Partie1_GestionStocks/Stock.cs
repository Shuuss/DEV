using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1_GestionStocks
{
    public class Stock
    {
        private int laQuantite;
        private Meuble leMeuble;

        public Stock(int laQuantite, Meuble leMeuble)
        {
            LaQuantite = laQuantite;
            LeMeuble = leMeuble;
        }

        public Stock(int laQuantite, double hauteur, double largeur, double profondeur, string laReference, double lePrix)
        {
            LaQuantite = laQuantite;
            LeMeuble = new Meuble(hauteur, largeur, profondeur, laReference, lePrix);
        }

        public Stock()
        {

        }

        public int LaQuantite { get => laQuantite; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("la valeur doit être positive ou nulle");
                }
                laQuantite = value;
            }
        }
        public Meuble LeMeuble { get => leMeuble; set => leMeuble = value; }

        public override bool Equals(object? obj)
        {
            return obj is Stock stock &&
                   this.LaQuantite == stock.LaQuantite &&
                   EqualityComparer<Meuble>.Default.Equals(this.LeMeuble, stock.LeMeuble);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LaQuantite, this.LeMeuble);
        }

        public override string? ToString()
        {
            return $"{LeMeuble.ToString()}" +
                $"\nQuantite : {LaQuantite}";
        }

        public void AjouteStock(int nb)
        {
            if (nb < 0)
            {
                throw new ArgumentException("le nombre est négatif, utilisez plutôt RetireStock()");

            }
            this.LaQuantite += nb;
        }

        public bool RetireStock(int nb)
        {
            if (nb < 0)
            {
                throw new ArgumentException("le nombre est négatif, utilisez plutôt AjouteStock()");

            }
            if (this.LaQuantite >= nb)
            {
                this.LaQuantite -= nb;
                return true;
            }
            return false;
            
        }

        public double CalculeMontant()
        {
            return this.LeMeuble.LePrix * this.LaQuantite;
        }

        public double CalculeVolume()
        {
            return this.LeMeuble.CalculeVolume() * this.LaQuantite;
        }
    }
}
