using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionReservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionReservations.Tests
{
    [TestClass()]
    public class ResaTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestDateInvalide()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 26), new DateTime(2024, 3, 1), 2, Hotels.PLAZZA, "nat@gmail.fr", Voitures.AUCUNE, 0);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestMailInvalide()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 2, Hotels.PLAZZA, "natgmail.fr", Voitures.AUCUNE, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestNbJoursVoitureNegatif()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 2, Hotels.PLAZZA, "nat@gmail.fr", Voitures.AUCUNE, -2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestAucuneVoitureNbJoursVoitureNonNul()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 2, Hotels.PLAZZA, "nat@gmail.fr", Voitures.AUCUNE, 2);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestNbJoursVoitureNul()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 2, Hotels.PLAZZA, "nat@gmail.fr", Voitures.LUXE, 0);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestNbJoursVoitureSuperieurNbJours()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 2, Hotels.PLAZZA, "nat@gmail.fr", Voitures.ORDINAIRE, 15);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ResaTestNbPersonnesInvalide()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 0, Hotels.PLAZZA, "nat@gmail.fr", Voitures.AUCUNE, 0);

        }

        [TestMethod()]
        public void ResaTest()
        {
            Resa reservation = new Resa(new DateTime(2024, 3, 1), new DateTime(2024, 3, 9), 2, Hotels.PLAZZA, "nat@gmail.fr", Voitures.AUCUNE, 0);
            Assert.IsNotNull(reservation);
        }

        [TestMethod()]
        public void ResaTest1()
        {

        }

        [TestMethod()]
        public void CalculePrixVolTest()
        {

        }

        [TestMethod()]
        public void CalculePrixHotelTest()
        {

        }

        [TestMethod()]
        public void CalculePrixVoitureTest()
        {

        }

        [TestMethod()]
        public void CalculePrixTotalTest()
        {

        }

        [TestMethod()]
        public void EqualsTest()
        {

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {

        }

        [TestMethod()]
        public void ToStringTest()
        {

        }
    }
}