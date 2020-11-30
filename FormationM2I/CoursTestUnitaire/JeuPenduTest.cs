using CoursCSharpObjetPartie1.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursTestUnitaire
{
    [TestClass]
    class JeuPenduTest
    {
        private IGenerateur g = Mock.Of<IGenerateur>();

        [TestMethod]
        public void GenererMasqueTest()
        {
            //Arrange
            //FakeGenerateurMot g = new FakeGenerateurMot();
            //IGenerateur g = Mock.Of<IGenerateur>();
            Mock.Get(g).Setup(o => o.Generer()).Returns("bonjour");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            jeu.GenererMasque();
            //Assert
            Assert.AreEqual("*******", jeu.Masque);
        }

        [TestMethod]
        public void TestCharTest()
        {
            //Arrange
            Mock.Get(g).Setup(o => o.Generer()).Returns("coucou");
            JeuPendu jeu = new JeuPendu(g);
            //Act
            bool result = jeu.TestChar('c');
            //Assert
            Assert.IsTrue(result);
        }
    }
}
