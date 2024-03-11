using Partie1_UnCompte;
using System.Text;

namespace Partie_2_DesComptes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Client simon = new Client("Simon");
            simon.AjouteCompte(new Compte(500));
            simon.AjouteCompte(new CompteBloque(500,-20));
            simon.AjouteCompte(new CompteEpargne(500,0.02,1000));

            int choix;
            do
            {
                Console.WriteLine("0.Quitter");
                Console.WriteLine("1.voir la synthèse des comptes");
                Console.WriteLine("2.Créditer");
                Console.WriteLine("3.Débiter");
                Console.WriteLine("4.Ouvrir un compte");
                Console.WriteLine("5.Faire un Virement entre 2 comptes");
                choix = Program.SaisieInt(0, 5);
                switch (choix)
                {
                    case 0:
                        Console.WriteLine("Au revoir.");
                        break;
                    case 1:
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("SYNTHESE COMPTE :");
                        Console.WriteLine("------------------------------");
                        foreach (Compte c in simon.SesComptes)
                        {
                            Console.WriteLine(c);
                            Console.WriteLine("------------------------------");
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("CREDITER :");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("numéro de compte à créditer :");
                            int.TryParse(Console.ReadLine(),out int numero);
                            simon.Recherche(numero);
                            Console.WriteLine("Montant à crediter :");
                            double mt = Program.SaisieDoublePositif();
                            Console.WriteLine("Ajouter une description de l'opération :");
                            string description = Console.ReadLine();
                            if (!simon.Recherche(numero).Debiter(mt, description))
                            {
                                Console.WriteLine("Vous ne pouvez pas créditer ce montant, votre solde dépasserait le seuil autorisé");
                            }
                            simon.Recherche(numero).Crediter(mt, description);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("DEBITER :");
                            Console.WriteLine("------------------------------");

                            Console.WriteLine("numéro de compte à débiter :");
                            int.TryParse(Console.ReadLine(), out int numero);
                            simon.Recherche(numero);

                            Console.WriteLine("Montant à débiter :");
                            double mt = Program.SaisieDoublePositif();

                            Console.WriteLine("Ajouter une description de l'opération :");
                            string description = Console.ReadLine();
                            if (!simon.Recherche(numero).Debiter(mt, description))
                            {
                                Console.WriteLine("Vous ne pouvez pas débiter ce montant, votre solde dépasserait le seuil autorisé");
                            }
                            simon.Recherche(numero).Debiter(mt, description);
                            break;
                        }
                    case 4:
                        {
                            Compte c = null;
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("OUVRIR UN COMPTE :");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("1.Compte normal tranquillement quoi");
                            Console.WriteLine("2.Compte bloqué avec un seuil minimal");
                            Console.WriteLine("3.Compte Epargne avec un taux d'épargne, un seuil maximal et un seuil minimal de 0");
                            choix = Program.SaisieInt(1, 3);
                            switch (choix)
                            {
                                case 1:
                                    Console.WriteLine("Quel est le solde du compte ?");
                                    double solde = SaisieDoublePositif();
                                    c = new Compte(solde);
                                    break;
                                case 2:
                                    Console.WriteLine("Quel est le solde du compte ?");
                                    solde = SaisieDoublePositif();
                                    Console.WriteLine("Quel est le seuil minimal du compte ?");
                                    double seuilMin = SaisieDoublePositif();
                                    c = new CompteBloque(solde, seuilMin);
                                    break;
                                case 3:
                                    Console.WriteLine("Quel est le solde du compte ?");
                                    solde = SaisieDoublePositif();
                                    Console.WriteLine("Quel est le taux d'épargne du compte ?");
                                    double.TryParse(Console.ReadLine(), out double txEpargne);
                                    Console.WriteLine("Quel est le seuil maximal du compte ?");
                                    double seuilMax = SaisieDoublePositif();
                                    c = new CompteEpargne(solde, txEpargne, seuilMax);
                                    break;
                            }
                            simon.AjouteCompte(c);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("FAIRE UN VIREMENT :");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("De quel compte ?");
                            int.TryParse(Console.ReadLine(), out int nbCompteDebite);
                            simon.Recherche(nbCompteDebite);
                            Console.WriteLine("A quel compte ?");
                            int.TryParse(Console.ReadLine(), out int nbCompteCredite);
                            simon.Recherche(nbCompteCredite);
                            Console.WriteLine("De quel montant ?");
                            double montantVirement = SaisieDoublePositif();
                            if (!(simon.Debiter(nbCompteDebite, montantVirement, "")&& simon.Crediter(nbCompteCredite, montantVirement, "")))
                            {
                                Console.WriteLine("le virment n'a pas pu être effectué");
                            }
                        }
                        break;
                }
                Console.WriteLine("appuyez sur une touche...");
                Console.ReadLine();
                Console.Clear();
            } while (choix != 0);
        }
        public static double SaisieDoublePositif()
        {
            string saisie = Console.ReadLine();
            double nb;
            while (!(double.TryParse(saisie, out nb) && nb >= 0))
            {
                Console.WriteLine("Erreur. Nb >= 0");
                saisie = Console.ReadLine();
            }
            return nb;
        }
        public static int SaisieInt(int min, int max)
        {
            string saisie = Console.ReadLine();
            int nb;
            while (!(int.TryParse(saisie, out nb) && nb >= min && nb <= max))
            {
                Console.WriteLine($"Erreur. Nb >= {min} et nb <= {max}");
                saisie = Console.ReadLine();
            }
            return nb;
        }
    }
}