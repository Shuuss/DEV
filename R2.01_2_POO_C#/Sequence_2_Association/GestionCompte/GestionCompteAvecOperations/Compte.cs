using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompteAvecOperations
{
    internal class Compte
    {
        private int numCpt;
        private double solde;
        private static int numAuto = 0;
        public const string MONNAIE = "€";
        private List<Operation> lesOperations;

        public int NumCpt
        {
            get
            {
                return numCpt;
            }

            private set
            {
                numCpt = value;
            }
        }

        public double Solde
        {
            get
            {
                return solde;
            }

            private set
            {
                solde = value;
            }
        }

        public static int NumAuto
        {
            get
            {
                return numAuto;
            }

            private set
            {
                numAuto = value;
            }
        }

        internal List<Operation> LesOperations
        {
            get
            {
                return this.lesOperations;
            }

            set
            {
                this.lesOperations = value;
            }
        }

        public Compte(double solde)
        {
            if (solde<0)
            {
                throw new ArgumentException("le solde du compte ne peut pas être négatif à la création");
            }
            Solde = solde;
            NumAuto++;
            NumCpt = NumAuto;
            LesOperations = new List<Operation>();
        }
        public Compte():this(0)
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Compte compte &&
                   this.NumCpt == compte.NumCpt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumCpt);
        }

        public override string? ToString()
        {
            return $"Le compte numéro {NumCpt} a un solde de {Solde}{MONNAIE}.";
        }

        public static bool operator ==(Compte? left, Compte? right)
        {
            return EqualityComparer<Compte>.Default.Equals(left, right);
        }

        public static bool operator !=(Compte? left, Compte? right)
        {
            return !(left == right);
        }

        public bool Crediter(double montant)
        {
            if (montant<0)
            {
                throw new ArgumentException("le montant crédité ne prut pas être négatif, utilisez plutôt la méthode Debiter()");
            }
            solde += montant;
            Console.WriteLine("Ajouter une description de l'opération :");
            string description = Console.ReadLine();
            LesOperations.Add(new Operation(DateTime.Now, description, montant, TypeOperation.Credit));
            return true;
        }

        public bool Debiter(double montant)
        {
            if (montant < 0)
            {
                throw new ArgumentException("le montant débité ne prut pas être négatif, utilisez plutôt la méthode Crediter()");
            }
            solde -= montant;
            Console.WriteLine("Ajouter une description de l'opération :");
            string description = Console.ReadLine();
            LesOperations.Add(new Operation(DateTime.Now, description, montant, TypeOperation.Debit));
            return true;
        }

        public void SauvegardeJson<T>(string pathData)
        {
            try
            {
                string result = JsonConvert.SerializeObject(LesOperations, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(pathData, result);
            }
            catch (Exception e) { throw; }
        }


    }
}
