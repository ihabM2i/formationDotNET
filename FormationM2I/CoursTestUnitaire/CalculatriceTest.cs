using CoursCSharpObjetPartie1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursTestUnitaire
{
    [TestClass]
    public class CalculatriceTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            //Arrange
            Calculatrice c = new Calculatrice();

            //Act
            double result = c.Addition(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
