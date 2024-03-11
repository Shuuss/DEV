using System.Text;

namespace Partie1_UnCompte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Compte c = null;
            string pathData = "Comptes.json";
            int choix;

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
                        c = new CompteBloque(solde,seuilMin);
                        break;
                    case 3:
                        Console.WriteLine("Quel est le solde du compte ?");
                        solde = SaisieDoublePositif();
                        Console.WriteLine("Quel est le taux d'épargne du compte ?");
                        double.TryParse(Console.ReadLine(), out double txEpargne);
                        Console.WriteLine("Quel est le seuil maximal du compte ?");
                        double seuilMax = SaisieDoublePositif();
                        c = new CompteEpargne(solde, txEpargne,seuilMax);
                        break;
                    default:
                        break;
                }
            do
            {
                Console.WriteLine("0.Quitter et sauvegarder les opérations");
                Console.WriteLine("1.Créditer");
                Console.WriteLine("2.Débiter");
                Console.WriteLine("3.Consulter le solde");
                Console.WriteLine("4.Consulter les opérations");
                if (c is CompteEpargne)
                {
                    Console.WriteLine("5.Calcul du futur montant");
                    Console.WriteLine("6.Calcul d'intérêts");
                    Console.WriteLine("7.Estimation d'années pour atteindre montant");
                    choix = SaisieInt(0, 7);
                }
                else
                {
                    choix = Program.SaisieInt(0, 4);
                }
                switch (choix)
                {
                    case 0:
                        Console.WriteLine("Au revoir.");
                        c.SauvegardeJson<Operation>(pathData);
                        break;
                    case 1:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("CREDITER :");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Montant à crediter :");
                            double mt = Program.SaisieDoublePositif();
                            Console.WriteLine("Ajouter une description de l'opération :");
                            string description = Console.ReadLine();
                            if (!c.Debiter(mt, description))
                            {
                                Console.WriteLine("Vous ne pouvez pas créditer ce montant, votre solde dépasserait le seuil autorisé");
                            }
                            c.Crediter(mt,description);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("DEBITER :");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("Montant à débiter :");
                            double mt = Program.SaisieDoublePositif();
                            Console.WriteLine("Ajouter une description de l'opération :");
                            string description = Console.ReadLine();
                            if (!c.Debiter(mt,description))
                            {
                                Console.WriteLine("Vous ne pouvez pas retirer ce montant, votre solde descendrait en dessous du seuil autorisé");
                            }
                            else
                            {
                                c.Debiter(mt, description);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("CONSULTER LE SOLDE :");
                            Console.WriteLine("------------------------------");
                            Console.WriteLine(c);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("------------------------------");
                            Console.WriteLine("CONSULTER LES OPERATIONS :");
                            Console.WriteLine("------------------------------");
                            foreach (Operation o in c.LesOperations)
                            {
                                Console.WriteLine(o);
                                Console.WriteLine("------------------------------");
                            }
                            break;
                        }
                    case 5:
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("CALCUL FUTUR MONTANT :");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("dans combien d'années ?");
                        int nbAnnees = (int)Program.SaisieDoublePositif();
                        Console.WriteLine($"dans {nbAnnees} ans, vous aurez {Math.Round(((CompteEpargne)c).CalculFuturMontant(nbAnnees),2)} {Compte.MONNAIE}");
                        break;
                    case 6:
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("CALCUL INTERETS :");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("dans combien d'années ?");
                        nbAnnees = (int)Program.SaisieDoublePositif();
                        Console.WriteLine($"dans {nbAnnees} ans, vous aurez gagné {Math.Round(((CompteEpargne)c).CalculInteret(nbAnnees), 2)} {Compte.MONNAIE}");
                        break;
                    case 7:
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("ESTIMATION ANNEES NECESSAIRES POUR ATTEINDRE MONTANT :");
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("quel montant ?");
                        double montant = Program.SaisieDoublePositif();
                        Console.WriteLine($"pour atteindre {montant} euros, il vous faudra {((CompteEpargne)c).CalculNbAnnee(montant)} ans");
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