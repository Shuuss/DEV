using GestionPension;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using static GestionPension.Chien;

namespace GestionPensionTest
{
    [TestClass]
    public class ChienTest
    {
        [TestMethod]
        public void TestDonneCategorie()
        {
            Chien chienPetit = new Chien(nom: "Simon", nomMaitre: "Tanguy", poids: 5);
            Chien chienMoyenLimite = new Chien(nom: "Simon", nomMaitre: "Tanguy", poids: 10);
            Chien chienMoyen = new Chien(nom: "Simon", nomMaitre: "Tanguy", poids: 15);
            Chien chienGrosLimite = new Chien(nom: "Simon", nomMaitre: "Tanguy", poids: 25);
            Chien chienGros = new Chien(nom: "Simon", nomMaitre: "Tanguy", poids: 30);

            Assert.AreEqual(Categorie.Petit, chienPetit.DonneCategorie(),"chien petit médiane");
            Assert.AreEqual(Categorie.Moyen, chienMoyenLimite.DonneCategorie(), "chien moyen limite");
            Assert.AreEqual(Categorie.Moyen, chienMoyen.DonneCategorie(), "chien moyen médiane");
            Assert.AreEqual(Categorie.Gros, chienGrosLimite.DonneCategorie(), "chien gros limite");
            Assert.AreEqual(Categorie.Gros, chienGros.DonneCategorie(), "chien gros médiane");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestChienNomNull()
        {
            Chien Chiengue = new Chien("", "Tanguy", 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestChienNomProprietaireNull()
        {
            Chien Chiengue = new Chien("Simon", "", 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChienPoidsNul()
        {
            Chien Chiengue = new Chien("Simon", "Tanguy", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChienPoidsNegatif()
        {
            Chien Chiengue = new Chien("Simon", "Tanguy", -25);
        }

        [TestMethod]
        public void TestChien()
        {
            Chien Chiengue = new Chien("Simon", "Tanguy", 15);
            Assert.IsNotNull(Chiengue);
        }
    }
}