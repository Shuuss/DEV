using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie1_UnCompte
{
    internal class CompteEpargne : CompteBloque
    {
        private double txEpargne;
        private double seuilMax;

        public CompteEpargne(double solde, double txEpargne, double seuilMax) : base(solde, 0)
        {
            if (solde > seuilMax)
            {
                throw new ArgumentException("le solde ne peut pas dépasser le seuil maximum");
            }
            TxEpargne = txEpargne;
            SeuilMax = seuilMax;
        }

        public CompteEpargne(double txEpargne, double seuilMax) : this(0,txEpargne,seuilMax)
        {

        }

        public double TxEpargne
        {
            get
            {
                return txEpargne;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("le taux doit être entre 0 et 1");
                }
                txEpargne = value;
            }
        }

        public double SeuilMax
        {
            get
            {
                return this.seuilMax;
            }

            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("le seuil max doit être plus grand que 0");
                }
                this.seuilMax = value;
            }
        }

        public override bool Crediter(double montant, string description)
        {
            if (Solde + montant > SeuilMax)
            {
                return false;
            }
            return base.Crediter(montant, description);
        }

        public override string? ToString()
        {
            return base.ToString() + "\nSeuil max : " + this.SeuilMax;
        }

        public double CalculFuturMontant(int nbAnnee)
        {
            return Solde * Math.Pow((1 + TxEpargne), nbAnnee);
        }

        public double CalculInteret(int nbAnnee)
        {
            return CalculFuturMontant(nbAnnee) - Solde;
        }

        public int CalculNbAnnee(double montantAAtteindre)
        {
            return (int)(Math.Log(montantAAtteindre / Solde) / (Math.Log(1 + TxEpargne)));
        }
    }
}
