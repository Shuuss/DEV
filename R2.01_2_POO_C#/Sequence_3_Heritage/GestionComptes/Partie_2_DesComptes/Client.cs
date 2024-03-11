using Partie1_UnCompte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie_2_DesComptes
{
    internal class Client
    {
        private string nom;
        private List<Compte> sesComptes;

        public Client(string nom)
        {
            this.Nom = nom;
            this.SesComptes = new List<Compte>();
        }

        public Client(string nom, List<Compte> sesComptes)
        {
            this.Nom = nom;
            this.SesComptes = sesComptes;
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public List<Compte> SesComptes
        {
            get
            {
                return this.sesComptes;
            }

            set
            {
                this.sesComptes = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   this.Nom == client.Nom &&
                   EqualityComparer<List<Compte>>.Default.Equals(this.SesComptes, client.SesComptes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Nom, this.SesComptes);
        }

        public Compte Recherche(int numero)
        {
            if (numero > SesComptes.Count || numero <=0)
            {
                throw new ArgumentException("Le Compte recherché n'existe pas");
            }
            return SesComptes.Find(x => x.NumCpt == numero);
        }

        public bool Crediter(int numero, double montant, string description)
        {
            return Recherche(numero).Crediter(montant, description);
        }
        public bool Debiter(int numero, double montant, string description)
        {
            return Recherche(numero).Debiter(montant, description);
        }
        public void AjouteCompte(Compte c)
        {
            SesComptes.Add(c);
        }
    }
}
