using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1_UnCompte
{
    internal class CompteBloque : Compte
    {
        private double seuilMin;

        public CompteBloque(double solde,double seuilMin) : base(solde)
        {
            this.SeuilMin = seuilMin;
        }

        public CompteBloque(double seuilMin) : this(0, seuilMin)
        { 
        
        }

        public CompteBloque() : this(0,0)
        {

        }

        public double SeuilMin
        {
            get
            {
                return this.seuilMin;
            }

            set
            {
                if (value > 0)
                {
                    throw new ArgumentException("Le seuil doit être nul ou négatif");
                }
                this.seuilMin = value;
            }
        }

        public override string? ToString()
        {
            return base.ToString() + "\nSeuil min : " + this.SeuilMin;
        }

        public override bool Debiter(double montant, string description)
        {
            if (Solde-montant<SeuilMin)
            {
                return false;
            }
            return base.Debiter(montant, description);
        }
    }
}
