using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1_GestionStocks
{
    public class Meuble
    {
        private Dimension laDimension;
        private string laReference;
        private double lePrix;
        public const String MONNAIE = "euro(s)";

        public Meuble(Dimension laDimension, string laReference, double lePrix)
        {
            LaDimension = laDimension;
            LaReference = laReference;
            LePrix = lePrix;
        }

        public Meuble(double hauteur, double largeur, double profondeur, string laReference, double lePrix)
        {
            LaDimension = new Dimension(hauteur,largeur,profondeur);
            LaReference = laReference;
            LePrix = lePrix;
        }

        public Meuble()
        { 
        
        }

        public Dimension LaDimension { get => laDimension; set => laDimension = value; }
        public string LaReference { get => laReference; set => laReference = value; }
        public double LePrix { get => lePrix; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("la valeur doit être positive ou nulle");
                }
                lePrix = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Meuble meuble &&
                   EqualityComparer<Dimension>.Default.Equals(this.LaDimension, meuble.LaDimension) &&
                   this.LaReference == meuble.LaReference &&
                   this.LePrix == meuble.LePrix;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LaDimension, this.LaReference, this.LePrix);
        }

        public override string? ToString()
        {
            return $"Reference : {LaReference}" +
                $"\nPrix : {lePrix} {MONNAIE}" +
                $"\n{LaDimension.ToString()}";
        }
        public double CalculeVolume()
        {
            return LaDimension.CalculeVolume();
        }
    }
}
