using GestionPension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPensionTest
{
    [TestClass]
    public class SejourTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testSejourDateInvalide()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 07), unBox: new Box(1, false, false), unChien: new Chien("Simon", "Tanguy", 15));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testSejourBoxNull()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: null, unChien: new Chien("Simon", "Tanguy", 15));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testSejourChienNull()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: new Box(1, false, false), unChien: null);
        }
        [TestMethod]
        public void testSejour()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: new Box(1, false, false), unChien: new Chien("Simon", "Tanguy", 15));
            Assert.IsNotNull(unSejour);
        }

        [TestMethod]
        public void TestCalculePrixBox()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: new Box(1, false, false), unChien: new Chien("Simon", "Tanguy", 15));
            Assert.AreEqual(36, unSejour.CalculePrixBox());
        }
        [TestMethod]
        public void TestCalculePrixNourriture()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: new Box(1, false, false), unChien: new Chien("Simon", "Tanguy", 15));
            Assert.AreEqual(12, unSejour.CalculeNourriture());
        }
        [TestMethod]
        public void TestCalculePrixTotal()
        {
            Sejour unSejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: new Box(1, false, false), unChien: new Chien("Simon", "Tanguy", 15));
            Assert.AreEqual(48, unSejour.CalculePrixTotal());
        }

    }
}
