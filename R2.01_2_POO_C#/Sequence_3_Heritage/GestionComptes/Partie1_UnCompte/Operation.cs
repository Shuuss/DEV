using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1_UnCompte
{
    public enum TypeOperation { Debit = 0, Credit = 1}
    
    internal class Operation
    {
        private DateTime dateHeure;
        private string description;
        private double montant;
        private TypeOperation typeOp;

        public Operation(DateTime dateHeure, string description, double montant, TypeOperation typeOp)
        {
            this.DateHeure = dateHeure;
            this.Description = description;
            this.Montant = montant;
            this.TypeOp = typeOp;
        }

        public DateTime DateHeure
        {
            get
            {
                return dateHeure;
            }

            set
            {
                dateHeure = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public double Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
            }
        }

        public TypeOperation TypeOp
        {
            get
            {
                return this.typeOp;
            }

            set
            {
                this.typeOp = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Operation operation &&
                   this.DateHeure == operation.DateHeure &&
                   this.Description == operation.Description &&
                   this.Montant == operation.Montant &&
                   this.TypeOp == operation.TypeOp;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.DateHeure, this.Description, this.Montant, this.TypeOp);
        }

        public override string? ToString()
        {
            return $"{DateHeure} {TypeOp} {montant} {Compte.MONNAIE} {Description}";
        }

        public static bool operator ==(Operation? left, Operation? right)
        {
            return EqualityComparer<Operation>.Default.Equals(left, right);
        }

        public static bool operator !=(Operation? left, Operation? right)
        {
            return !(left == right);
        }
    }
}
