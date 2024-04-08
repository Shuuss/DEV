using GestionPension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestionPension.Box;

namespace GestionPensionTest
{
    [TestClass]
    public class BoxTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestBoxNumeroNegatif()
        {
            Box unBox = new Box(numero: -1, estIndividuel: true, avecTerrasse: false);
        }
        [TestMethod]
        public void TestBox()
        {
            Box unBox = new Box(numero: 0, estIndividuel: true, avecTerrasse: false);
            Assert.IsNotNull(unBox);
        }
        [TestMethod]
        public void TestCalculPrixBase()
        {
            Box unBoxVF = new Box(numero: 0, estIndividuel: true, avecTerrasse: false);
            Box unBoxVV = new Box(numero: 0, estIndividuel: true, avecTerrasse: true);
            Box unBoxFV = new Box(numero: 0, estIndividuel: false, avecTerrasse: true);
            Box unBoxFF = new Box(numero: 0, estIndividuel: false, avecTerrasse: false);
            Assert.AreEqual(28, unBoxVF.CalculePrixBase());
            Assert.AreEqual(36, unBoxVV.CalculePrixBase());
            Assert.AreEqual(26, unBoxFV.CalculePrixBase());
            Assert.AreEqual(18, unBoxFF.CalculePrixBase());
        }
    }
}
