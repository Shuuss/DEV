using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo1_List_Departements
{
    internal class Departement
    {
        private string chefLieu;
        private string nom;
        private string numero;
        private double population;
        private string region;
        private double superficie;

        public Departement(string chefLieu, string nom, string numero, double population, string region, double superficie)
        {
            ChefLieu = chefLieu;
            Nom = nom;
            Numero = numero;
            Population = population;
            Region = region;
            Superficie = superficie;
        }

        public string ChefLieu { get => chefLieu; set => chefLieu = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Numero { get => numero; set => numero = value; }
        public double Population { get => population; set => population = value; }
        public string Region { get => region; set => region = value; }
        public double Superficie { get => superficie; set => superficie = value; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"----------------" +
                   $"\nChef Lieu : {ChefLieu}" +
                   $"\nNom : {Nom}" +
                   $"\nNumero : {Numero}" +
                   $"\nPopulation : {Population}" +
                   $"\nRegion : {Region}" +
                   $"\nSuperficie : {this.Superficie:n0}" +
                   $"\n----------------";
        }
        
        public static int CompareDepartementParPopulation(Departement d1, Departement d2)
        {
            return d1.Population.CompareTo(d2.Population);
        }
        
    }
}
