using Microsoft.VisualStudio.TestTools.UnitTesting;
using libCommerciaux;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getMesNotesFrais()
        {
            //Arranger:
            Commercial c;
            NoteFrais f0, f1;
            c = new Commercial("Jean", "Dupond", "A", 25);

            //Agir:
            f0 = new NoteFrais(new System.DateTime(2022, 11, 12), c);
            f1 = new NoteFrais(new System.DateTime(2022, 11, 15), c);

            //Auditer:
            Assert.AreEqual(2, c.getMesNotesFrais().Count);

        }
        [TestMethod]
        public void nbFraisNonRembourses()
        {
            //Arranger
            ServiceCommercial sc = new ServiceCommercial();
            NoteFrais f0, f1, f2, f3, f4;
            Commercial c0 = new Commercial("Dupond", "Jean", "A", 8);
            Commercial c1 = new Commercial("Duval", "René", "A", 6);

            sc.ajouterCommercial(c0);
            sc.ajouterCommercial(c1);

            f0 = new NoteFrais(new System.DateTime(2022, 10, 12), c0);
            f1 = new NoteFrais(new System.DateTime(2022, 10, 15), c0);
            f2 = new NoteFrais(new System.DateTime(2022, 10, 18), c1);
            f3 = new NoteFrais(new System.DateTime(2022, 10, 21), c1);
            f4 = new NoteFrais(new System.DateTime(2022, 10, 25), c1);

            //Agir
            f1.setRembourse();
            f3.setRembourse();
            f4.setRembourse();

            //Auditer
            Assert.AreEqual(2, sc.nbFraisNonRembourses());

        }
        [TestMethod]
        public void calculMontantARembourserTestTransport()
        {
            //Arranger
            Commercial c;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            FraisTransport t0 = new FraisTransport(new System.DateTime(2022, 11, 12), c, 250);
            //Auditer
            Assert.AreEqual(50, t0.calculMontantARembourser());
        }

        [TestMethod]
        public void calculMontantARembourserTestRepas()
        {
            //Arranger
            Commercial c;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            RepasMidi rp = new RepasMidi(new System.DateTime(2022, 11, 12), c, 15);
            //Auditer
            Assert.AreEqual(15, rp.calculMontantARembourser());
        }

        [TestMethod]
        public void calculMontantARembourserTestNuite()
        {
            //Arranger
            Commercial c;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            Nuite n = new Nuite(new System.DateTime(2022, 11, 12), c, 3, 80);
            //Auditer
            Assert.AreEqual(74.75, n.calculMontantARembourser());
        }

        [TestMethod]
        public void nbNotesFraisNonRembourseesTest()
        {
            Commercial c, c1;
            ServiceCommercial sc;
            sc = new ServiceCommercial();
            c = new Commercial("Jean", "Dupond", "A", 25);
            c1 = new Commercial("Paul", "Duval", "B", 10);
            sc.ajouterCommercial(c);
            sc.ajouterCommercial(c1);

            NoteFrais f, f1, f2, f3, f4;
            f = new NoteFrais(new System.DateTime(2013, 11, 12), c);
            f1 = new NoteFrais(new System.DateTime(2013, 11, 15), c);
            f1.setRembourse();
            f2 = new NoteFrais(new System.DateTime(2013, 11, 18), c1);
            f3 = new NoteFrais(new System.DateTime(2013, 11, 22), c1);
            f3.setRembourse();
            f4 = new NoteFrais(new System.DateTime(2013, 11, 25), c1);
            f4.setRembourse();
            Assert.AreEqual(2, sc.nbFraisNonRembourses());
        }
        [TestMethod]
        public void TestSauve()
        {
            ServiceCommercial sc = new ServiceCommercial();
            Commercial c = new Commercial("Jean", "Dupond", "A", 25);
            sc.ajouterCommercial(c);
            string attendu = sc.getLstCommerciaux()[0].GetPrenom;
            PersisteCommercial.sauve(sc);
            PersisteCommercial.charge();
            Assert.AreEqual("Jean", attendu);
        }
    }
}
