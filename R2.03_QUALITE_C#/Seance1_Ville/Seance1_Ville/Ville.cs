using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Seance1_Ville
{

    /// <summary>
    /// Stocke 4 informations :
    /// 2 chaines : le nom et le code postal d'une ville
    /// 1 entier : le nombre d'habitants d'une ville
    /// 1 double : la superficie d'une ville en km2
    /// </summary> 
    public class Ville
    {
        private String codePostal;
        private String nom;
        private int nbHabitants;
        private double superficie;
        private int departement;



      

        /// <summary>
        /// initialise une nouvelle instance de la classe ville avec le code postal, le nom, le nombre d'habitants et la superficie
        /// </summary>
        /// <param name="codePostal"></param>
        /// <param name="nom"></param>
        /// <param name="nbHabitants"></param>
        /// <param name="superficie"></param>
        public Ville(string codePostal, string nom, int nbHabitants, double superficie)
        {
            this.CodePostal = codePostal;
            this.Nom = nom;
            this.NbHabitants = nbHabitants;
            this.Superficie = superficie;            
        }


        /// <summary>
        /// Obtient ou définit le code postal de cette ville –
        /// Le code postal doit être composé de 5 chiffres
        /// </summary>
        /// <exception cref="ArgumentException"> Envoyée si le code postal ne serait pas composé de 5 chiffres</exception>
        public string CodePostal
        {
            get
            {
                return this.codePostal;
            }

            set
            {
                if (value==null)
                    throw new ArgumentException("Le code postal est obligatoire ");
              
               
                Match m = Regex.Match(value, "^[0-9]{5}$");
                if (!m.Success)
                    throw new ArgumentException("attention, code postal sur 5 chiffres");
                 this.codePostal = value;
                 this.Departement = Int32.Parse(value.Substring(0, 2));
            }
        }

        /// <summary>
        /// obtient ou définit le nom de cette ville
        /// le nom ne doit être ni nul ni vide
        /// </summary>
        /// <exception cref="ArgumentException"> Envoyée si le nom est nul ou vide</exception>
        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Le nom de la ville est obligatoire : ni nul, ni vide");
                this.nom = value;
            }
        }

        /// <summary>
        /// obtient ou définit le nombre d'habitants de cette ville
        /// le nombre d'habitants doit être positif
        /// </summary>
        /// <exception cref="ArgumentException"> Envoyée si le nombre d'habitants est négatif</exception>
        public int NbHabitants
        {
            get
            {
                return this.nbHabitants;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("Le nombre d'habitant doit être positif");
                this.nbHabitants = value;
            }
        }

        /// <summary>
        /// obtient ou définit la superficie de cette ville
        /// la superficie doit être positive
        /// </summary>
        /// <exception cref="ArgumentException"> Envoyée si la superficie est négatif</exception>
        public double Superficie
        {
            get
            {
                return this.superficie;
            }

            set
            {
                if (value <= 0)
                    throw new ArgumentException("Le nombre d'habitant doit être positif");
                this.superficie = value;
            }
        }

        public int Departement
        {
            get
            {
                return this.departement;
            }

           private set
            {
                this.departement = value;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1005801993;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.CodePostal);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Nom);
            hashCode = hashCode * -1521134295 + this.NbHabitants.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Superficie.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Code postal : " + this.CodePostal
                   + "\nNom : " + this.Nom
                   + "\nSuperficie : " + this.Superficie + " km2"
                   + "\nNb habitants : " + this.NbHabitants + " habitants"
                   +"\nDensite : " + this.CalculDensite() +"hab/km2";
        }


        /// <summary>
        /// Calcule la densité à partir du nombre d'habitants et de la
        /// superficie de cette ville
        /// </summary>
        /// <returns>la densité arrondie à un chiffre après la virgule</returns>
        public double CalculDensite()
        {
            double densite = this.NbHabitants / this.Superficie;
            return Math.Round(densite,1);
        }
     
        /// <summary>
 /// teste si la ville fait partie du département dont le numero est passé en paramètre </summary>
 /// <param name="numero"> un entier compris entre 1 et 95</param>
 /// <returns> true si la ville fait partie du département , false sinon</returns>
 /// <exception cref="ArgumentOutOfRangeException">envoyée si le numéro n'est pas compris entre 1 et 95</exception>
        public bool EstDansLeDepartement(int numero)
        {
            if (numero < 0 || numero > 95)
                throw new ArgumentOutOfRangeException(" le numero doit etre compris entre 1 et 95");
          
            return this.Departement == numero;
        }
        
        /// <summary>
        /// teste si la ville est plus dense que la ville passée en paramètre
        /// </summary>
        /// <param name="v"></param>
        /// <returns>true si la ville est plus dense que celle en paramètre; false sinon</returns>
        public bool EstPlusDense(Ville v)
        {
            return this.CalculDensite() > v.CalculDensite();
        }
        public bool EstDansLeMemeDepartement(Ville v)
        {
            
            return this.Departement == v.Departement;
        }

        public bool APlusDeSuperficie(Ville max)
        {
            return this.Superficie > max.Superficie;
        }

        public override bool Equals(object? obj)
        {
            return obj is Ville ville &&
                   CodePostal == ville.CodePostal &&
                   Nom == ville.Nom;
        }

        public static bool operator >(Ville left, Ville right)
        {
            return left.NbHabitants > right.NbHabitants;

        }
        public static bool operator <(Ville left, Ville right)
        {
            return left.NbHabitants < right.NbHabitants;

        }
        public static bool operator >=(Ville left, Ville right)
        {
            return left.NbHabitants >= right.NbHabitants;

        }
        public static bool operator <=(Ville left, Ville right)
        {
            return left.NbHabitants <= right.NbHabitants;

        }

        public static Ville operator +(Ville left, Ville right)
        {
            return new Ville(left.CodePostal, left.Nom + "-"+right.Nom, left.NbHabitants + right.NbHabitants, left.Superficie + right.Superficie
       );
           

        }


    }
}
