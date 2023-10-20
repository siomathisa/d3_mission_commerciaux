using Microsoft.VisualStudio.TestTools.UnitTesting;
using libCommerciaux;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getMesNptesFrais()
        {
            //Arranger:
            Commercial c;
            NoteFrais f0, f1;
            c = new Commercial("Jean", "Dupond", "A", 25);

            //Agir:
            f0 = new NoteFrais(1, new System.DateTime(2022, 11, 12), c);
            f1 = new NoteFrais(2, new System.DateTime(2022, 11, 15), c);
            c.getMesNotesFrais().Add(f0);
            c.getMesNotesFrais().Add(f1);

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

            f0 = new NoteFrais(3, new System.DateTime(2022, 10, 12), c0);
            f1 = new NoteFrais(4, new System.DateTime(2022, 10, 15), c0);
            f2 = new NoteFrais(5, new System.DateTime(2022, 10, 18), c1);
            f3 = new NoteFrais(6, new System.DateTime(2022, 10, 21), c1);
            f4 = new NoteFrais(7, new System.DateTime(2022, 10, 25), c1);

            c0.ajouterNoteFrais(f0);
            c0.ajouterNoteFrais(f4);
            c1.ajouterNoteFrais(f1);
            c1.ajouterNoteFrais(f2);
            c1.ajouterNoteFrais(f3);

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
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            FraisTransport t0 = new FraisTransport(8, new System.DateTime(2022, 11, 12), c, 250);
            //Auditer
            Assert.AreEqual(50, t0.calculMontantARembourser());
        }

        [TestMethod]
        public void calculMontantARembourserTestRepas()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            RepasMidi rp = new RepasMidi(9, new System.DateTime(2022, 11, 12), c, 15);
            //Auditer
            Assert.AreEqual(15, rp.calculMontantARembourser());
        }

        [TestMethod]
        public void calculMontantARembourserTestNuite()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            Nuite n = new Nuite(10, new System.DateTime(2022, 11, 12), c, 3, 80);
            //Auditer
            Assert.AreEqual(74.75, n.calculMontantARembourser());
        }

    }
}
