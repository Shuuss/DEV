using Microsoft.VisualStudio.TestTools.UnitTesting;
using Seance1_Ville;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seance1_Ville.Tests
{
    [TestClass()]
    public class VilleTests
    {
        private Ville vAnnecy;
        [TestInitialize()]
        public void Init()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vAnnecy2 = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vEpagny = new Ville("74330", "Epagny", 4118, 6.74);
        }

            [TestMethod()]
        public void VilleTest()
        {
            Ville v = new Ville("74000", "Annecy", 131730, 66.93);
            Assert.AreEqual("Annecy", v.Nom);
            Assert.AreEqual("74000", v.CodePostal);
            Assert.AreEqual(131730, v.NbHabitants);
            Assert.AreEqual(66.93, v.Superficie);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vAnnecy2 = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vEpagny = new Ville("74330", "Epagny", 4118, 6.74);
            bool vAnnecyEqualsvAnnecy2 = vAnnecy.Equals(vAnnecy2);
            bool vAnnecyEqualsvEpagny = vAnnecy.Equals(vEpagny);
            Assert.IsTrue(vAnnecyEqualsvAnnecy2, "deux villes égales");
            Assert.IsFalse(vAnnecyEqualsvEpagny, "deux villes pas égales");
        }

        [TestMethod()]
        public void CalculDensiteTest()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            double densite = vAnnecy.CalculDensite();
            Assert.AreEqual(1968.2, densite, "ville d’Annecy");
            // cette ligne vérifie que le calcul renvoie bien le résultat attendu 
        }

        [TestMethod()]
        public void EstDansLeDepartementTest()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            int hauteSavoie = 74;
            int rhone = 69;
            bool vAnnecyDepvHauteSavoie = vAnnecy.EstDansLeDepartement(hauteSavoie);
            bool vAnnecyDepvRhone = vAnnecy.EstDansLeDepartement(rhone);
            Assert.IsTrue(vAnnecyDepvHauteSavoie, "une ville et son département");
            Assert.IsFalse(vAnnecyDepvRhone, "une ville et un autre département");
        }

        [TestMethod()]
        public void EstPlusDenseTest()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vEpagny = new Ville("74330", "Epagny", 4118, 6.74);
            Ville vChambery = new Ville("73000", "Chambery", 59856, 20.99);
            bool vAnnecyPlusDensevEpagny = vAnnecy.EstPlusDense(vEpagny);
            bool vAnnecyPlusDensevChambery = vAnnecy.EstPlusDense(vChambery);
            bool vAnnecyPlusDensevAnnecy = vAnnecy.EstPlusDense(vAnnecy);
            Assert.IsTrue(vAnnecyPlusDensevEpagny, "une ville ayant plus de densité qu'une autre");
            Assert.IsFalse(vAnnecyPlusDensevChambery, "une ville ayant moins de densité qu'une autre");
            Assert.IsFalse(vAnnecyPlusDensevAnnecy, "deux villes ayant la même densité");
        }

        [TestMethod()]
        public void EstDansLeMemeDepartementTest()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vEpagny = new Ville("74330", "Epagny", 4118, 6.74);
            Ville vChambery = new Ville("73000", "Chambery", 59856, 20.99);
            bool vAnnecyMemeDepvEpagny = vAnnecy.EstDansLeMemeDepartement(vEpagny);
            bool vAnnecyMemeDepvChambery = vAnnecy.EstDansLeMemeDepartement(vChambery);
            Assert.IsTrue(vAnnecyMemeDepvEpagny, "2 villes de même département");
            Assert.IsFalse(vAnnecyMemeDepvChambery, "2 villes départements différents");
        }

        [TestMethod()]
        public void APlusDeSuperficieTest()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            Ville vEpagny = new Ville("74330", "Epagny", 4118, 6.74);
            Ville vChambery = new Ville("73000", "Chambery", 59856, 20.99);
            bool vAnnecyPlusDeSuperficievEpagny = vAnnecy.APlusDeSuperficie(vEpagny);
            bool vChamberyPlusDeSuperficievAnnecy = vChambery.APlusDeSuperficie(vAnnecy);
            bool vAnnecyPlusDeSuperficievAnnecy = vAnnecy.APlusDeSuperficie(vAnnecy);
            Assert.IsTrue(vAnnecyPlusDeSuperficievEpagny, "une ville ayant plus de superficie qu'une autre");
            Assert.IsFalse(vChamberyPlusDeSuperficievAnnecy, "une ville ayant moins de superficie qu'une autre");
            Assert.IsFalse(vAnnecyPlusDeSuperficievAnnecy, "deux villes ayant la même superficie");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EstDansLeDepartement_avecUnDepIncorrect_Test()
        {
            Ville vAnnecy = new Ville("74000", "Annecy", 131730, 66.93);
            vAnnecy.EstDansLeDepartement(98); // la valeur 98 sert à déclencher une exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ville_NomVilleVide_Test()
        {
            Ville v1 = new Ville("74000", "", 52000, 16);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ville_CodePostalVide_Test()
        {
            Ville v1 = new Ville("", "Annecy", 52000, 16);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ville_CodePostalMauvaisFormat_Test()
        {
            Ville v1 = new Ville("7400000", "Annecy", 52000, 16);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ville_NbHabitantsNegatif_Test()
        {
            Ville v1 = new Ville("74000", "Annecy", -52000, 16);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ville_SuperficieNegative_Test()
        {
            Ville v1 = new Ville("74000", "Annecy", 52000, -16);
        }
    }
}