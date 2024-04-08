using GestionPension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPensionTest
{
    [TestClass]
    public class PensionTest
    {
        [TestMethod]
        public void TestPension()
        {
            Pension unePension = new Pension(nom: "la pension");
            Assert.IsNotNull(unePension);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPensionNomNul()
        {
            Pension unePension = new Pension("");
        }

        [TestMethod]
        public void TestAjouteUnSejour()
        {
            Pension unePension = new Pension(nom: "la pension");
            Sejour sejour = new Sejour(premierJour: new DateTime(2024, 04, 08), dernierJour: new DateTime(2024, 04, 10), unBox: new Box(1, false, false), unChien: new Chien("Simon", "Tanguy", 15));
            unePension.AjouteUnSejour(sejour);
            Assert.IsNotNull(unePension.LesSejours[0]);
        }
    }
}
