using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1_GestionStocks
{
    public class Dimension
    {
        private double hauteur;
        private double largeur;
        private double profondeur;
        public const String UNITE_MESURE = "cm";
        public const String UNITE_VOLUME= "m3";

        public double Hauteur 
        { 
            get => hauteur; 

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("la valeur doit être positive ou nulle");
                }
                hauteur = value; 
            } 
        }
        public double Largeur { get => largeur; set
            {
                if (value < 0)
                {
                    throw new ArgumentException("la valeur doit être positive ou nulle");
                }
                largeur = value;
            }
        }
        public double Profondeur { get => this.profondeur; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("la valeur doit être positive ou nulle");
                }
                profondeur = value;
            }
        }

        public Dimension(double hauteur, double largeur, double profondeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
            Profondeur = profondeur;
        }

        public Dimension()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is Dimension dimension &&
                   this.Hauteur == dimension.Hauteur &&
                   this.Largeur == dimension.Largeur &&
                   this.Profondeur == dimension.Profondeur;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Hauteur, this.Largeur, this.Profondeur);
        }

        public override string? ToString()
        {
            return $"Dimension : {Hauteur}x{Largeur}x{Profondeur}{UNITE_MESURE}";
        }

        public double CalculeVolume()
        {
            return Hauteur * Largeur * Profondeur / 1000000;
        }
    }
}
